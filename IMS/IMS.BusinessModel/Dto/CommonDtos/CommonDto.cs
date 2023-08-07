using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.BusinessModel.Dto.CommonDtos
{
    public class CommonDto
    {
        public long Id { get; set; }
        public long CreatedBy { get; set; } = 1;
        public DateTime CreationDate { get; set; } = DateTime.UtcNow.Date;
        public long? ModifiedBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int Rank { get; set; } = 0;
        public string BusinessId { get; set; } = "IMS-01";
        public int Version { get; set; } = 1;
    }
}
