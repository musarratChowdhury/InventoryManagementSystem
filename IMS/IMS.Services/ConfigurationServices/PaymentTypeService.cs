using IMS.BusinessModel.Dto.Configuration;
using IMS.BusinessModel.Entity.Configuration;
using IMS.Dao;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using IMS.Services.BaseServices;
using IMS.BusinessModel.Entity.Common;
using FluentNHibernate.Data;

namespace IMS.Services
{
    public interface IPaymentTypeService : IBaseConfigurationService<ConfigurationDto, ConfigurationFormData, PaymentType>
    {
        void Create(ConfigurationFormData dtoFormData, ISession session);
        void Update(ConfigurationFormData dtoFormData, ISession session);
    }



    public class PaymentTypeService : BaseConfigurationService<ConfigurationDto, ConfigurationFormData, PaymentType>, IPaymentTypeService
    {
        private IBaseDao<PaymentType> _BaseDao;

        public PaymentTypeService()
        {
            _BaseDao = new BaseDao<PaymentType>();
        }
        public void Create(ConfigurationFormData dtoFormData, ISession session)
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    var entityType = new PaymentType();
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
                    var entityType = new PaymentType();
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
