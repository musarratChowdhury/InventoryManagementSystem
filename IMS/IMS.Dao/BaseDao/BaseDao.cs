using IMS.BusinessModel.Dto.GridData;
using IMS.BusinessModel.Entity.Common;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMS.Dao
{
    public interface IBaseDao<TEntity> where TEntity : IBaseEntity
    {
        TEntity GetById(long id, ISession session);
        IList<TEntity> GetAll(ISession Session);
        void Create(TEntity entity, ISession session);
        void Update(TEntity entity, ISession session);
        void Delete(TEntity entity, ISession session);
        int GetTotalCount(ISession session);
        IList<TEntity> GetDataBySkipTake(int skip, int take, ISession session);
        IList<TEntity> GetAllSorted(DataRequest sortRequest, ISession session);
        int GetHighestRank(ISession session);
    }

    public class BaseDao<TEntity> : IBaseDao<TEntity> where TEntity :class, IBaseEntity
    {
        //private readonly ISession _session;

        public BaseDao()
        {
          
        }

        public TEntity GetById(long id, ISession session)
        {
            return session.Get<TEntity>(id);
        }

        public IList<TEntity> GetAll(ISession session)
        {
            return session.Query<TEntity>().ToList();
        }

        public void Create(TEntity entity, ISession session)
        {
            session.Save(entity);
        }


        public void Update(TEntity entity, ISession session)
        {
            session.Update(entity);
        }


        public void Delete(TEntity entity, ISession session)
        {
            session.Delete(entity);
        }

        public int GetTotalCount(ISession session)
        {
            return session.Query<TEntity>().Count();
        }

        public IList<TEntity> GetDataBySkipTake(int skip, int take, ISession session)
        {
            return session.Query<TEntity>().Skip(skip).Take(take).ToList();
        }

        public IList<TEntity> GetAllSorted(DataRequest sortRequest, ISession session)
        {
            ICriteria criteria = session.CreateCriteria<TEntity>();

            foreach (var sortInfo in sortRequest.Sorted)
            {
                if (sortInfo.Direction.Equals("ascending", StringComparison.OrdinalIgnoreCase))
                {
                    criteria.AddOrder(Order.Asc(sortInfo.Name));
                }
                else if (sortInfo.Direction.Equals("descending", StringComparison.OrdinalIgnoreCase))
                {
                    criteria.AddOrder(Order.Desc(sortInfo.Name));
                }
            }

            criteria.SetFirstResult(sortRequest.skip)
                    .SetMaxResults(sortRequest.take);

            return criteria.List<TEntity>();
        }


        public int GetHighestRank(ISession session)
        {
            if(session.Query<TEntity>().ToList().Count!=0)
            {
                return session.Query<TEntity>()
                              .Select(b => b.Rank)
                              .Max();
            }
            else
            {
                return 0;
            }
        }

    }

}
