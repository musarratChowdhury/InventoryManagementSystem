using IMS.BusinessModel.Dto.Configuration;
using IMS.BusinessModel.Entity.Configuration;
using IMS.Dao;
using NHibernate;
using System;
using IMS.Services.BaseServices;

namespace IMS.Services
{
    public interface ICustomerTypeService : IBaseConfigurationService<ConfigurationDto, ConfigurationFormData, CustomerType>
    {
        void Create(ConfigurationFormData dtoFormData, ISession session);
        void Update(ConfigurationFormData dtoFormData, ISession session);
    }



    public class CustomerTypeService : BaseConfigurationService<ConfigurationDto, ConfigurationFormData, CustomerType>, ICustomerTypeService
    {
        private IBaseDao<CustomerType> _BaseDao;

        public CustomerTypeService()
        {
            _BaseDao = new BaseDao<CustomerType>();
        }
        public void Create(ConfigurationFormData dtoFormData, ISession session)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    var entityType = new CustomerType();
                    var entity = MapToEntity(dtoFormData, entityType);
                    _BaseDao.Create(entity, session);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
        public void Update(ConfigurationFormData dtoFormData, ISession session)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    var entityType = new CustomerType();
                    var entity = MapToEntity(dtoFormData, entityType);
                    _BaseDao.Update(entityType, session);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

    }


}
