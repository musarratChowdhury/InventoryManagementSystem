using IMS.BusinessModel.Entity.Common;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace IMS.Dao
{
    public interface IBaseDao<TEntity> where TEntity : BaseEntity
    {
        //TEntity GetById(long id);
        IEnumerable<TEntity> GetAll(ISession Session);
        //void Add(TEntity entity);
        //void Update(TEntity entity);
        //void Delete(TEntity entity);
    }

    public class BaseDao<TEntity> : IBaseDao<TEntity> where TEntity : BaseEntity
    {
        //private readonly ISession _session;

        public BaseDao()
        {
          
        }

        //public TEntity GetById(long id)
        //{
        //    return _session.Get<TEntity>(id);
        //}

        public IEnumerable<TEntity> GetAll(ISession session)
        {
            return session.Query<TEntity>().ToList();
        }

        //public void Add(TEntity entity)
        //{
        //    _session.Save(entity);
        //}

        //public void Update(TEntity entity)
        //{
        //    _session.Update(entity);
        //}

        //public void Delete(TEntity entity)
        //{
        //    _session.Delete(entity);
        //}
    }

}
