using IMS.BusinessModel.Entity.Configuration;
using IMS.Services.BaseServices;
using IMS.BusinessModel.Dto.CommonDtos;

namespace IMS.Services
{
    public interface ICustomerTypeService : IBaseConfigurationService<ConfigurationDto, ConfigurationFormData, CustomerType>
    {

    }



    public class CustomerTypeService : BaseConfigurationService<ConfigurationDto, ConfigurationFormData, CustomerType>, ICustomerTypeService
    {
     
    }


}
