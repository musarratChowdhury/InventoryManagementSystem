using IMS.BusinessModel.Entity.Configuration;
using IMS.Dao;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using IMS.Services.BaseServices;
using IMS.BusinessModel.Entity.Common;
using FluentNHibernate.Data;
using IMS.BusinessModel.Dto.CommonDtos;

namespace IMS.Services
{
    public interface IPaymentTypeService : IBaseConfigurationService<ConfigurationDto, ConfigurationFormData, PaymentType>
    {
       
    }



    public class PaymentTypeService : BaseConfigurationService<ConfigurationDto, ConfigurationFormData, PaymentType>, IPaymentTypeService
    {
       
    }


}
