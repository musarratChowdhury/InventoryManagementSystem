using IMS.BusinessModel.Dto.CommonDtos;

namespace IMS.BusinessModel.Dto.Configuration
{
    public class PaymentTypeDto : CommonDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }

    public class PaymentTypeFormData
    {
        public long Id { get; set; }    
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Rank { get; set; }
    }
}
