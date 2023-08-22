using System;
using System.Collections.Generic;
using System.Linq;
using IMS.BusinessModel.Dto.CommonDtos;
using IMS.BusinessModel.Dto.GridData;
using IMS.BusinessModel.Dto.Invoice;
using IMS.BusinessModel.Entity;
using IMS.Dao;
using NHibernate;

namespace IMS.Services.SecondaryServices
{
    public class InvoiceService : BaseSecondaryService<Invoice>
    {
         private readonly IBaseDao<Invoice> _baseDao;
        public InvoiceService()
        {
            _baseDao = new BaseDao<Invoice>();
        }

        public List<InvoiceDto> GetAll(ISession session, DataRequest dataRequest)
        {
            try
            {
                var entities = _baseDao.GetAll(session, dataRequest);
                return (from t in entities let dto = new InvoiceDto() select MapToDto(t, dto)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Create(InvoiceFormDto invoiceFormDto, long userId, ISession session)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    var invoice = new Invoice();
                    var mappedInvoice = MapToEntity(invoiceFormDto, invoice);
                    mappedInvoice.Rank = GetNextRank(session);
                    mappedInvoice.CreatedBy = userId;
                    mappedInvoice.CreationDate = DateTime.Now;
                    _baseDao.Create(mappedInvoice, session);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Update(InvoiceDto invoiceDto, long modifiedById, ISession sess)
        {
            using (var transaction = sess.BeginTransaction())
            {
                try
                {
                    var invoice = new Invoice();
                    var mappedInvoice = MapToEntity(invoiceDto, invoice);
                    mappedInvoice.ModificationDate = DateTime.Now;
                    mappedInvoice.ModifiedBy = modifiedById;
                    
                    _baseDao.Update(mappedInvoice, sess);
                    
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        
        public List<DropDownDto> GetDropDownList(ISession session)
        {
            try
            {
                var entities = _baseDao.GetAll(session);
                return (from t in entities let dto = new DropDownDto() select MapToDropDownDto(t, dto)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        private DropDownDto MapToDropDownDto(Invoice entity, DropDownDto dto)
        {
            dto.Id = entity.Id;
            dto.SerialNumber = $"#IN{entity.Id}SO{entity.SalesOrderId}";
            return dto;
        }

        private InvoiceDto MapToDto(Invoice entity, InvoiceDto dto)
        {

            dto.Id = entity.Id;
            dto.SerialNumber = $"IN{entity.Id}SO{entity.SalesOrderId}";
            dto.InvoiceDueDate = entity.InvoiceDueDate;
            dto.InvoiceTypeId = entity.InvoiceTypeId;
            dto.InvoiceTypeName = entity.InvoiceType.Name;
            dto.InvoiceDate = entity.InvoiceDate;
            dto.SalesOrderId = entity.SalesOrderId;
            dto.SalesOrderSerialNumber = $"#SO{entity.SalesOrder.Id}C{entity.SalesOrder.CustomerId}";
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
        private Invoice MapToEntity(InvoiceFormDto dto, Invoice invoice)
        {
            invoice.InvoiceTypeId = dto.InvoiceTypeId;
            invoice.InvoiceDate = dto.InvoiceDate;
            invoice.InvoiceDueDate = dto.InvoiceDueDate;
            invoice.SalesOrderId = dto.SalesOrderId;
            invoice.Version = 1;
            invoice.BusinessId = "IMS-1";
            invoice.Status = 1;

            return invoice;
        }

        //for update action
        private Invoice MapToEntity(InvoiceDto dto, Invoice invoice)
        {
            invoice.Id = dto.Id;
            invoice.CreatedBy = dto.CreatedBy;
            invoice.CreationDate = dto.CreationDate;
            invoice.Rank = dto.Rank;
            invoice.InvoiceTypeId = dto.InvoiceTypeId;
            invoice.InvoiceDate = dto.InvoiceDate;
            invoice.InvoiceDueDate = dto.InvoiceDueDate;
            invoice.SalesOrderId = dto.SalesOrderId;
            invoice.Version = 1;
            invoice.BusinessId = "IMS-1";
            invoice.Status = dto.Status;

            return invoice;
        }
    }
}