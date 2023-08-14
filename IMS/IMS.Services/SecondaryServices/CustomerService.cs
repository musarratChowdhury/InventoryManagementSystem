using FluentNHibernate.Data;
using IMS.BusinessModel.Dto.CommonDtos;
using IMS.BusinessModel.Dto.Customer;
using IMS.BusinessModel.Dto.GridData;
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
    public class CustomerService : ICustomerService
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

        //For pagination with certain amount of data
        public List<CustomerDto> GetAll(ISession session, int skip, int take)
        {
            try
            {
                var entities = _BaseDao.GetDataBySkipTake(skip, take, session);
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

        public List<CustomerDto> GetAll(ISession session, DataRequest dataRequest)
        {
            try
            {
                var entities = _BaseDao.GetAllSorted(dataRequest, session);
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

        public int GetTotalCount(ISession session)
        {
            try
            {
                var result = _BaseDao.GetTotalCount(session);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Create(CustomerFormDto customerFormDto, long userId, ISession session)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    var customer = new Customer();
                    var mappedCustomer = MapToEntity(customerFormDto, customer);
                    mappedCustomer.Rank = GetNextRank(session);
                    mappedCustomer.CreatedBy = userId;
                    mappedCustomer.CreationDate = DateTime.Now;
                    _BaseDao.Create(mappedCustomer, session);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public void Update(CustomerDto customerDto, long userId, ISession sess)
        {
            using (var transaction = sess.BeginTransaction())
            {
                try
                {
                    var customer = new Customer();
                    var mappedCustomer = MapToEntity(customerDto, customer);
                    mappedCustomer.ModificationDate = DateTime.Now;
                    mappedCustomer.ModifiedBy = userId;
                    _BaseDao.Update(mappedCustomer, sess);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public void Delete(long entityId, ISession sess)
        {
            using (var transaction = sess.BeginTransaction())
            {
                try
                {
                    var entity = _BaseDao.GetById(entityId, sess);
                    if (entity != null)
                    {
                        _BaseDao.Delete(entity, sess);
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

        protected Customer MapToEntity(CustomerFormDto dto, Customer customer)
        {
            customer.CustomerTypeId = dto.CustomerTypeId;
            customer.FirstName = dto.FirstName;
            customer.LastName = dto.LastName;
            customer.Email = dto.Email;
            customer.Phone = dto.Phone;
            customer.Address = dto.Address;
            customer.Version = 1;
            customer.BusinessId = "IMS-1";
            customer.Status = 1;

            return customer;
        }

        //for update action
        protected Customer MapToEntity(CustomerDto dto, Customer customer)
        {
            customer.Id = dto.Id;
            customer.CreatedBy = dto.CreatedBy;
            customer.CreationDate = dto.CreationDate;
            customer.Rank = dto.Rank;
            customer.CustomerTypeId = dto.CustomerTypeId;
            customer.FirstName = dto.FirstName;
            customer.LastName = dto.LastName;
            customer.Email = dto.Email;
            customer.Phone = dto.Phone;
            customer.Address = dto.Address;
            customer.Version = 1;
            customer.BusinessId = "IMS-1";
            customer.Status = 1;

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
