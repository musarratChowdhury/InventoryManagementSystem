using IMS.BusinessModel.Dto.Customer;
using IMS.BusinessModel.Dto.GridData;
using IMS.BusinessModel.Entity;
using IMS.Dao;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using IMS.BusinessModel.Dto.CommonDtos;
using IMS.BusinessModel.Entity.Common;

namespace IMS.Services.SecondaryServices
{
    public class BaseSecondaryService<TEntity> where TEntity :class, IBaseEntity
    {
        private readonly IBaseDao<TEntity> _baseDao;

        protected BaseSecondaryService()
        {
            _baseDao = new BaseDao<TEntity>();
        }

        // public List<CustomerDto> GetAll(ISession session, DataRequest dataRequest)
        // {
        //     try
        //     {
        //         var entities = _baseDao.GetAll(session, dataRequest);
        //         return (from t in entities let dto = new CustomerDto() select MapToDto(t, dto)).ToList();
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine(e);
        //         throw;
        //     }
        // }

        public int GetTotalCount(ISession session)
        {
            var result = _baseDao.GetTotalCount(session);
            return result;
        }

        // public void Create(CustomerFormDto customerFormDto, long userId, ISession session)
        // {
        //     using (var transaction = session.BeginTransaction())
        //     {
        //         try
        //         {
        //             var customer = new Customer();
        //             var mappedCustomer = MapToEntity(customerFormDto, customer);
        //             mappedCustomer.Rank = GetNextRank(session);
        //             mappedCustomer.CreatedBy = userId;
        //             mappedCustomer.CreationDate = DateTime.Now;
        //             _baseDao.Create(mappedCustomer, session);
        //             transaction.Commit();
        //         }
        //         catch (Exception ex)
        //         {
        //             transaction.Rollback();
        //             throw;
        //         }
        //     }
        // }
        //
        // public void Update(CustomerDto customerDto, long modifiedById, ISession sess)
        // {
        //     using (var transaction = sess.BeginTransaction())
        //     {
        //         try
        //         {
        //             var customer = new Customer();
        //             var mappedCustomer = MapToEntity(customerDto, customer);
        //             mappedCustomer.ModificationDate = DateTime.Now;
        //             mappedCustomer.ModifiedBy = modifiedById;
        //             
        //             _baseDao.Update(mappedCustomer, sess);
        //             
        //             transaction.Commit();
        //         }
        //         catch (Exception)
        //         {
        //             transaction.Rollback();
        //             throw;
        //         }
        //     }
        // }

        public void UpdateRank(ChangeRankDto changeRankDto, ISession sess)
        {
            using (var transaction = sess.BeginTransaction())
            {
                try
                {
                    if (changeRankDto.OldRank > changeRankDto.NewRank)
                    {
                        _baseDao.UpdateRank(sess,true, 
                            changeRankDto.OldRank, changeRankDto.NewRank, changeRankDto.Id);
                    }
                    else if(changeRankDto.OldRank < changeRankDto.NewRank)
                    {
                        _baseDao.UpdateRank(sess,false, 
                            changeRankDto.OldRank, changeRankDto.NewRank, changeRankDto.Id);
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Delete(long entityId, ISession sess)
        {
            using (var transaction = sess.BeginTransaction())
            {
                try
                {
                    var entity = _baseDao.GetById(entityId, sess);
                    if (entity != null)
                    {
                        _baseDao.Delete(entity, sess);
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        protected int GetNextRank(ISession session)
        {
            try
            {
                var highestRank = _baseDao.GetHighestRank(session);
                return highestRank + 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
