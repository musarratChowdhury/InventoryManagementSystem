
using IMS.Dao;
using NHibernate;
using System;
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

        public int GetTotalCount(ISession session)
        {
            var result = _baseDao.GetTotalCount(session);
            return result;
        }

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
                catch (Exception)
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
                catch (Exception)
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}
