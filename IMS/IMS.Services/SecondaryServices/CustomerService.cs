using FluentNHibernate.Data;
using IMS.BusinessModel.Dto.CommonDtos;
using IMS.BusinessModel.Dto.Customer;
using IMS.BusinessModel.Entity;
using IMS.Dao;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMS.Services.SecondaryServices
{
    public class CustomerService
    {
        private IBaseDao<Customer> _BaseDao;
        public CustomerService()
        {
            _BaseDao = new BaseDao<Customer>();
        }

        public IEnumerable<CustomerDto> GetAll(ISession session)
        {
            try
            {
                var entities = _BaseDao.GetAll(session);
                var result = new List<CustomerDto>();
                for (int i = 0; i < entities.Count; i++)
                {
                    var dto = new CustomerDto();
                    result.Add(MapToDto(entities[i], dto));
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public CustomerDto MapToDto(Customer entity, CustomerDto dto)
        {

            dto.Id = entity.Id;
            dto.FirstName = entity.FirstName;
            dto.LastName = entity.LastName;
            dto.Email = entity.Email;
            dto.Phone = entity.Phone;
            dto.Address = entity.Address;
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
    }
}
