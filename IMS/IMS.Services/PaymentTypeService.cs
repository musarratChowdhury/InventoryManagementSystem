using IMS.BusinessModel.Dto.Configuration;
using IMS.BusinessModel.Entity;
using IMS.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Services
{
    public interface IPaymentTypeService
    {
        IEnumerable<PaymentTypeDto> GetAllPaymentTypes();
        PaymentTypeDto GetPaymentTypeById(long id);
        void AddPaymentType(PaymentTypeDto paymentTypeDto);
        void UpdatePaymentType(PaymentTypeDto paymentTypeDto);
        void DeletePaymentType(long id);
    }


    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly IPaymentTypeDao _paymentTypeDao;

        public PaymentTypeService(IPaymentTypeDao paymentTypeDao)
        {
            _paymentTypeDao = paymentTypeDao;
        }

        public IEnumerable<PaymentTypeDto> GetAllPaymentTypes()
        {
            // Assuming the Dao returns the entities, you need to map them to DTOs
            var paymentTypes = _paymentTypeDao.GetAll();
            return paymentTypes.Select(MapToDto);
        }

        public PaymentTypeDto GetPaymentTypeById(long id)
        {
            var paymentType = _paymentTypeDao.GetById(id);
            return MapToDto(paymentType);
        }

        public void AddPaymentType(PaymentTypeDto paymentTypeDto)
        {
            var paymentType = MapToEntity(paymentTypeDto);
            _paymentTypeDao.Add(paymentType);
        }

        public void UpdatePaymentType(PaymentTypeDto paymentTypeDto)
        {
            var paymentType = MapToEntity(paymentTypeDto);
            _paymentTypeDao.Update(paymentType);
        }

        public void DeletePaymentType(long id)
        {
            var paymentType = _paymentTypeDao.GetById(id);
            if (paymentType != null)
            {
                _paymentTypeDao.Delete(paymentType);
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
