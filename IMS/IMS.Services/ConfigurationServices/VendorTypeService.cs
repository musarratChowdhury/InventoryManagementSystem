using IMS.BusinessModel.Entity.Configuration;
using IMS.Services.BaseServices;
using IMS.BusinessModel.Dto.CommonDtos;

namespace IMS.Services
{
    public interface IVendorTypeService : IBaseConfigurationService<ConfigurationDto, ConfigurationFormData, VendorType>
    {

    }



    public class VendorTypeService : BaseConfigurationService<ConfigurationDto, ConfigurationFormData, VendorType>, IVendorTypeService
    {

    }


}
