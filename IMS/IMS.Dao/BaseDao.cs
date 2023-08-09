using IMS.BusinessModel.Entity.Common;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace IMS.Dao
{
    public interface IBaseDao<TEntity> 
    {
        TEntity GetById(long id, ISession session);
        IList<TEntity> GetAll(ISession Session);
        void Create(TEntity entity, ISession session);
        void Update(TEntity entity, ISession session);
        void Delete(TEntity entity, ISession session);
    }

    public class BaseDao<TEntity> : IBaseDao<TEntity> 
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

    }

}
