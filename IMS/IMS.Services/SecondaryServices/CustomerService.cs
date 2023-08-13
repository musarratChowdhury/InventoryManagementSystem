using FluentNHibernate.Data;
using IMS.BusinessModel.Dto.CommonDtos;
using IMS.BusinessModel.Dto.Customer;
using IMS.BusinessModel.Entity;
using IMS.Dao;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Transactions;

namespace IMS.Services.SecondaryServices
{
    public class CustomerService
    {
        private IBaseDao<Customer> _BaseDao;
        private long _currentUserId;
        public CustomerService()
        {
            _BaseDao = new BaseDao<Customer>();
            _currentUserId = Int64.Parse(ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value);
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

        public void Create(CustomerFormDto customerFormDto, ISession session)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    var customer = new Customer();
                    var mappedCustomer = MapToEntity(customerFormDto, customer);
                    mappedCustomer.Rank = GetNextRank(session);
                    _BaseDao.Create(mappedCustomer, session);
                    transaction.Commit();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }


        public CustomerDto MapToDto(Customer entity, CustomerDto dto)
        {

            dto.Id = entity.Id;
            dto.CustomerTypeId = entity.CustomerTypeId;
            dto.CustomerTypeName = entity.CustomerType.Name;
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

        public Customer MapToEntity(CustomerFormDto dto, Customer customer)
        {
            customer.Id = dto.Id;
            customer.CustomerTypeId = dto.CustomerTypeId;
            customer.FirstName = dto.FirstName;
            customer.LastName = dto.LastName;
            customer.Email = dto.Email;
            customer.Phone = dto.Phone;
            customer.Rank = dto.Rank;
            customer.Address = dto.Address;
            customer.CreatedBy = _currentUserId;
            customer.CreationDate = DateTime.Now;
            customer.ModificationDate = DateTime.Now;
            customer.ModifiedBy = 1;
            customer.Version = 1;
            customer.BusinessId = "IMS-1";

            return customer;
        }

        protected int GetNextRank(ISession session)
        {
            try
            {
                var highestRank = _BaseDao.GetHighestRank(session);
                return highestRank + 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
