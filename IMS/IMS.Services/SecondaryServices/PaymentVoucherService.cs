using System;
using System.Collections.Generic;
using System.Linq;
using IMS.BusinessModel.Dto.GridData;
using IMS.BusinessModel.Dto.PaymentVoucher;
using IMS.BusinessModel.Entity;
using IMS.Dao;
using NHibernate;

namespace IMS.Services.SecondaryServices
{
    public class PaymentVoucherService : BaseSecondaryService<PaymentVoucher>
    {
        private readonly IBaseDao<PaymentVoucher> _baseDao;
        public PaymentVoucherService()
        {
            _baseDao = new BaseDao<PaymentVoucher>();
        }

        public List<PaymentVoucherDto> GetAll(ISession session, DataRequest dataRequest)
        {
            try
            {
                var entities = _baseDao.GetAll(session, dataRequest);
                return (from t in entities let dto = new PaymentVoucherDto() select MapToDto(t, dto)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Create(PaymentVoucherFormDto paymentVoucherFormDto, long userId, ISession session)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    var paymentVoucher = new PaymentVoucher();
                    var mappedPaymentVoucher = MapToEntity(paymentVoucherFormDto, paymentVoucher);
                    mappedPaymentVoucher.Rank = GetNextRank(session);
                    mappedPaymentVoucher.CreatedBy = userId;
                    mappedPaymentVoucher.CreationDate = DateTime.Now;
                    _baseDao.Create(mappedPaymentVoucher, session);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Update(PaymentVoucherDto paymentVoucherDto, long modifiedById, ISession sess)
        {
            using (var transaction = sess.BeginTransaction())
            {
                try
                {
                    var paymentVoucher = new PaymentVoucher();
                    var mappedPaymentVoucher = MapToEntity(paymentVoucherDto, paymentVoucher);
                    mappedPaymentVoucher.ModificationDate = DateTime.Now;
                    mappedPaymentVoucher.ModifiedBy = modifiedById;
                    
                    _baseDao.Update(mappedPaymentVoucher, sess);
                    
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        private PaymentVoucherDto MapToDto(PaymentVoucher entity, PaymentVoucherDto dto)
        {

            dto.Id = entity.Id;
            dto.SerialNumber = $"#PV{entity.Id}BL{entity.BillId}";
            dto.PaymentDate = entity.PaymentDate;
            dto.PaymentAmount = entity.PaymentAmount;
            dto.BillId = entity.BillId;
            dto.BillSerialNumber = $"#BL{entity.Bill.Id}PO{entity.Bill.PurchaseOrderId}";
            dto.PaymentTypeId = entity.PaymentTypeId;
            dto.PaymentTypeName = entity.PaymentType.Name;
            dto.CashBankId = entity.CashBankId;
            dto.CashBankName = entity.CashBank.Name;
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
        private PaymentVoucher MapToEntity(PaymentVoucherFormDto dto, PaymentVoucher paymentVoucher)
        {
            paymentVoucher.PaymentDate = dto.PaymentDate;
            paymentVoucher.PaymentAmount = dto.PaymentAmount;
            paymentVoucher.BillId = dto.BillId;
            paymentVoucher.PaymentTypeId = dto.PaymentTypeId;
            paymentVoucher.CashBankId = dto.CashBankId;
            paymentVoucher.Version = 1;
            paymentVoucher.BusinessId = "IMS-1";
            paymentVoucher.Status = 1;

            return paymentVoucher;
        }

        //for update action
        private PaymentVoucher MapToEntity(PaymentVoucherDto dto, PaymentVoucher paymentVoucher)
        {
            paymentVoucher.Id = dto.Id;
            paymentVoucher.CreatedBy = dto.CreatedBy;
            paymentVoucher.CreationDate = dto.CreationDate;
            paymentVoucher.Rank = dto.Rank;
            paymentVoucher.PaymentDate = dto.PaymentDate;
            paymentVoucher.PaymentAmount = dto.PaymentAmount;
            paymentVoucher.BillId = dto.BillId;
            paymentVoucher.CashBankId = dto.CashBankId;
            paymentVoucher.PaymentTypeId = dto.PaymentTypeId;
            paymentVoucher.Version = 1;
            paymentVoucher.BusinessId = "IMS-1";
            paymentVoucher.Status = dto.Status;

            return paymentVoucher;
        }
    }
}