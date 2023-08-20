﻿using IMS.BusinessModel.Dto.Customer;
using IMS.BusinessModel.Dto.GridData;
using IMS.BusinessModel.Entity;
using IMS.Dao;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using IMS.BusinessModel.Dto.CommonDtos;

namespace IMS.Services.SecondaryServices
{
    public class CustomerService : BaseSecondaryService<Customer>
    {
        private readonly IBaseDao<Customer> _baseDao;
        public CustomerService()
        {
            _baseDao = new BaseDao<Customer>();
        }

        public List<CustomerDto> GetAll(ISession session, DataRequest dataRequest)
        {
            try
            {
                var entities = _baseDao.GetAll(session, dataRequest);
                return (from t in entities let dto = new CustomerDto() select MapToDto(t, dto)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public List<DropDownDto> GetDropDownList(ISession session)
        {
            try
            {
                var entities = _baseDao.GetAll(session);
                var result = new List<DropDownDto>();
                for (int i = 0; i < entities.Count; i++)
                {
                    var dto = new DropDownDto();
                    result.Add(MapToDropDownDto(entities[i], dto));
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DropDownDto MapToDropDownDto(Customer entity, DropDownDto dto)
        {
            dto.Id = entity.Id;
            dto.FullName = entity.FirstName +" "+ entity.LastName;

            return dto;
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
                    _baseDao.Create(mappedCustomer, session);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Update(CustomerDto customerDto, long modifiedById, ISession sess)
        {
            using (var transaction = sess.BeginTransaction())
            {
                try
                {
                    var customer = new Customer();
                    var mappedCustomer = MapToEntity(customerDto, customer);
                    mappedCustomer.ModificationDate = DateTime.Now;
                    mappedCustomer.ModifiedBy = modifiedById;
                    
                    _baseDao.Update(mappedCustomer, sess);
                    
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
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

        //for create operation
        private Customer MapToEntity(CustomerFormDto dto, Customer customer)
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
        private Customer MapToEntity(CustomerDto dto, Customer customer)
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
            customer.Status = dto.Status;

            return customer;
        }
    }
}
