using IMS.BusinessModel.Dto.Configuration;
using IMS.BusinessModel.Entity.Configuration;
using IMS.Dao;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Services
{
    public interface IPaymentTypeService
    {
        IEnumerable<PaymentTypeDto> GetAllPaymentTypes(ISession session);
        void CreatePaymentType(PaymentTypeFormData paymentTypeFormData, ISession session);
        void UpdatePaymentType(PaymentTypeFormData paymentTypeFormData, ISession session);
        void DeletePaymentType(long paymentTypeId, ISession session);
    }



    public class PaymentTypeService : IPaymentTypeService
    {
        private IPaymentTypeDao _paymentTypeDao;
        public PaymentTypeService()
        {
            
        }
        public PaymentTypeService(IPaymentTypeDao paymentTypeDao)
        {
            _paymentTypeDao = paymentTypeDao;
        }

        public IEnumerable<PaymentTypeDto> GetAllPaymentTypes(ISession session)
        {
            // Assuming the Dao returns the entities, you need to map them to DTOs
            _paymentTypeDao = new PaymentTypeDao();
            var paymentTypes = _paymentTypeDao.GetAll(session);
            return paymentTypes.Select(MapToDto);
        }

        public void CreatePaymentType(PaymentTypeFormData paymentTypeFormData, ISession session)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    // Map the DTO to the entity
                    var paymentTypeEntity = MapToEntity(paymentTypeFormData);
                    _paymentTypeDao = new PaymentTypeDao();

                    // Call the DAO to save the new PaymentType entity to the database
                    _paymentTypeDao.Create(paymentTypeEntity, session);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public void UpdatePaymentType(PaymentTypeFormData paymentTypeFormData, ISession session)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    // Map the DTO to the entity
                    var paymentTypeEntity = MapToEntity(paymentTypeFormData);
                    _paymentTypeDao = new PaymentTypeDao();

                    // Call the DAO to save the new PaymentType entity to the database
                    _paymentTypeDao.Update(paymentTypeEntity, session);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public void DeletePaymentType(long paymentTypeId, ISession session)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    _paymentTypeDao = new PaymentTypeDao();
                    var paymentTypeEntity = _paymentTypeDao.GetById(paymentTypeId, session);
                    if (paymentTypeEntity != null)
                    {
                        _paymentTypeDao.Delete(paymentTypeEntity, session);
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }        
        }

        // Helper methods to map between DTO and entity
        private PaymentTypeDto MapToDto(PaymentType paymentType)
        {
            return new PaymentTypeDto
            {
                Id = paymentType.Id,
                Name = paymentType.Name,
                Description = paymentType.Description,
                Status = paymentType.Status,
                Rank = paymentType.Rank,
                CreatedBy = paymentType.CreatedBy,  
                CreationDate = paymentType.CreationDate,
                Version = paymentType.Version,
                BusinessId = paymentType.BusinessId,
                // Map other properties as needed
            };
        }

        private PaymentType MapToEntity(PaymentTypeDto paymentTypeDto)
        {
            return new PaymentType
            {
                Id = paymentTypeDto.Id,
                Name = paymentTypeDto.Name,
                Description = paymentTypeDto.Description,
                Status = paymentTypeDto.Status,
                CreationDate = paymentTypeDto.CreationDate,
                CreatedBy = paymentTypeDto.CreatedBy,
                Version = paymentTypeDto.Version,
                BusinessId = paymentTypeDto.BusinessId,
                Rank = paymentTypeDto.Rank,
                // Map other properties as needed
            };
        }

        private PaymentType MapToEntity(PaymentTypeFormData paymentTypeFormData)
        {
            return new PaymentType
            {
                Id = paymentTypeFormData.Id,
                Name = paymentTypeFormData.Name,
                Description = paymentTypeFormData.Description,
                Status = paymentTypeFormData.Status,
                CreationDate = DateTime.Now,
                CreatedBy = 1,
                Version = 1,
                BusinessId = "IMS-1",
                Rank = paymentTypeFormData.Rank,
                // Map other properties as needed
            };
        }
    }


}
