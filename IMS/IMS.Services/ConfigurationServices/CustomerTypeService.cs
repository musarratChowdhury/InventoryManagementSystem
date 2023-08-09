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

    }



    public class CustomerTypeService : BaseConfigurationService<ConfigurationDto, ConfigurationFormData, CustomerType>, ICustomerTypeService
    {
     
    }


}
