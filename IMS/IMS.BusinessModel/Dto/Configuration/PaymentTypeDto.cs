using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.BusinessModel.Dto.Configuration
{
    public class PaymentTypeDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        // Add other properties as needed
    }
}
