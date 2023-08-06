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
        void CreatePaymentType(PaymentTypeDto paymentTypeDto, ISession session);
        void UpdatePaymentType(PaymentTypeDto paymentTypeDto, ISession session);
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

        public void CreatePaymentType(PaymentTypeDto paymentTypeDto, ISession session)
        {
            // Map the DTO to the entity
            var paymentTypeEntity = MapToEntity(paymentTypeDto);
            _paymentTypeDao = new PaymentTypeDao();

            // Call the DAO to save the new PaymentType entity to the database
            _paymentTypeDao.Create(paymentTypeEntity, session);
        }


        public void UpdatePaymentType(PaymentTypeDto paymentTypeDto, ISession session)
        {
            var paymentTypeEntity = MapToEntity(paymentTypeDto);
            _paymentTypeDao = new PaymentTypeDao();
            _paymentTypeDao.Update(paymentTypeEntity, session);
        }

        public void DeletePaymentType(long paymentTypeId, ISession session)
        {
            var paymentTypeEntity = _paymentTypeDao.GetById(paymentTypeId, session);
            if (paymentTypeEntity != null)
            {
                _paymentTypeDao = new PaymentTypeDao();
                _paymentTypeDao.Delete(paymentTypeEntity, session);
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
                Status = paymentType.Status
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
                Status = paymentTypeDto.Status
                // Map other properties as needed
            };
        }
    }


}
