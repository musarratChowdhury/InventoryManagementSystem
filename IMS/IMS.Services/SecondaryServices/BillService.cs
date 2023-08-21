using System;
using System.Collections.Generic;
using System.Linq;
using IMS.BusinessModel.Dto.Bill;
using IMS.BusinessModel.Dto.GridData;
using IMS.BusinessModel.Entity;
using IMS.Dao;
using NHibernate;

namespace IMS.Services.SecondaryServices
{
    public class BillService : BaseSecondaryService<Bill>
    {
          private readonly IBaseDao<Bill> _baseDao;
        public BillService()
        {
            _baseDao = new BaseDao<Bill>();
        }

        public List<BillDto> GetAll(ISession session, DataRequest dataRequest)
        {
            try
            {
                var entities = _baseDao.GetAll(session, dataRequest);
                return (from t in entities let dto = new BillDto() select MapToDto(t, dto)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Create(BillFormDto billFormDto, long userId, ISession session)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    var bill = new Bill();
                    var mappedbill = MapToEntity(billFormDto, bill);
                    mappedbill.Rank = GetNextRank(session);
                    mappedbill.CreatedBy = userId;
                    mappedbill.CreationDate = DateTime.Now;
                    _baseDao.Create(mappedbill, session);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Update(BillDto billDto, long modifiedById, ISession sess)
        {
            using (var transaction = sess.BeginTransaction())
            {
                try
                {
                    var bill = new Bill();
                    var mappedbill = MapToEntity(billDto, bill);
                    mappedbill.ModificationDate = DateTime.Now;
                    mappedbill.ModifiedBy = modifiedById;
                    
                    _baseDao.Update(mappedbill, sess);
                    
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        private BillDto MapToDto(Bill entity, BillDto dto)
        {

            dto.Id = entity.Id;
            dto.SerialNumber = $"BL{entity.Id}PO{entity.PurchaseOrderId}";
            dto.BillDate = entity.BillDate;
            dto.BillTypeId = entity.BillTypeId;
            dto.BillTypeName = entity.BillType.Name;
            dto.BillDueDate = entity.BillDueDate;
            dto.PurchaseOrderId = entity.PurchaseOrderId;
            dto.PurchaseOrderSerialNumber = $"#PO{entity.PurchaseOrder.Id}V{entity.PurchaseOrder.VendorId}";
            dto.Status = entity.Status;
            dto.Rank = entity.Rank;
            dto.CreatedBy = entity.CreatedBy;
            dto.CreationDate = entity.CreationDate;
            dto.ModifiedBy = entity.ModifiedBy;
            dto.ModificationDate = entity.ModificationDate;
            dto.Version = entity.Version;
            dto.BusinessId = entity.BusinessId;

            return dto;
        }

        //for create operation
        private Bill MapToEntity(BillFormDto dto, Bill bill)
        {
            bill.BillTypeId = dto.BillTypeId;
            bill.BillDate = dto.BillDate;
            bill.BillDueDate = dto.BillDueDate;
            bill.PurchaseOrderId = dto.PurchaseOrderId;
            bill.Version = 1;
            bill.BusinessId = "IMS-1";
            bill.Status = 1;

            return bill;
        }

        //for update action
        private Bill MapToEntity(BillDto dto, Bill bill)
        {
            bill.Id = dto.Id;
            bill.CreatedBy = dto.CreatedBy;
            bill.CreationDate = dto.CreationDate;
            bill.Rank = dto.Rank;
            bill.BillTypeId = dto.BillTypeId;
            bill.BillDate = dto.BillDate;
            bill.BillDueDate = dto.BillDueDate;
            bill.PurchaseOrderId = dto.PurchaseOrderId;
            bill.Version = 1;
            bill.BusinessId = "IMS-1";
            bill.Status = dto.Status;

            return bill;
        }
    }
}