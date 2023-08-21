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
        IList<TEntity> GetAll(ISession session);
        void Create(TEntity entity, ISession session);
        void Update(TEntity entity, ISession session);
        void Delete(TEntity entity, ISession session);
        int GetTotalCount(ISession session);
        IList<TEntity> GetAll( ISession session, DataRequest dataRequest);
        IList<TEntity> ExecuteRawSqlQuery(ISession session, string sqlQuery);
        void ExecuteRawSqlQuery(ISession session, string sqlQuery, object[] parameters, Type T);
        void UpdateRank(ISession session, bool isPromoted, int oldRank, int newRank, long id);
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

        public IList<TEntity> GetAll(ISession session, DataRequest dataRequest)
        {
            var criteria = session.CreateCriteria<TEntity>();
            if (dataRequest.Sorted!=null)
            {
                foreach (var sortInfo in dataRequest.Sorted)
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
            }
            

            criteria.SetFirstResult(dataRequest.Skip)
                    .SetMaxResults(dataRequest.Take);

            return criteria.List<TEntity>();
        }
        
        public IList<TEntity> ExecuteRawSqlQuery(ISession session, string sqlQuery)
        {
            IQuery query = session.CreateSQLQuery(sqlQuery).AddEntity(typeof(TEntity));

            return query.List<TEntity>();
        }
        
        public void ExecuteRawSqlQuery(ISession session, string sqlQuery, object[] parameters, Type T)
        {
            IQuery query = session.CreateSQLQuery(sqlQuery).AddEntity(T);

            for (int i = 0; i < parameters.Length; i++)
            {
                query.SetParameter(i + 1, parameters[i]);
            }
        }

        public void UpdateRank(ISession session,bool isPromoted, int oldRank, int newRank, long id)
        {
            var  sql = isPromoted ? $@"
                UPDATE {typeof(TEntity).Name}
                SET Rank = Rank + 1
                WHERE Rank >= {newRank} AND Rank < {oldRank};
                UPDATE {typeof(TEntity).Name}
                SET Rank = {newRank}
                WHERE Id = {id}
            " : $@"
                UPDATE {typeof(TEntity).Name}
                SET Rank = Rank - 1
                WHERE Rank <= {newRank} AND Rank > {oldRank};
                UPDATE {typeof(TEntity).Name}
                SET Rank = {newRank}
                WHERE Id = {id}
            ";
            IQuery query = session.CreateSQLQuery(sql);
            
            query.ExecuteUpdate();
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
