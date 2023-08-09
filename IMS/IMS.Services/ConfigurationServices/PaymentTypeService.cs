using IMS.BusinessModel.Entity.Configuration;
using IMS.Services.BaseServices;
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
