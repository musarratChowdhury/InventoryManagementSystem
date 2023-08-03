using IMS.BusinessModel.Entity.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.BusinessModel.Entity
{
    using IMS.BusinessModel.Entity.Configuration;
    using System;

    public class PaymentReceived : BaseEntity
    {
        public virtual DateTime PaymentDate { get; set; }
        public virtual decimal PaymentAmount { get; set; }
        public virtual int Status { get; set; }
        public virtual long? InvoiceId { get; set; }
        public virtual long? PaymentTypeId { get; set; }

        // Navigation properties for foreign keys
        public virtual Invoice Invoice { get; set; }
        public virtual PaymentType PaymentType { get; set; }
    }

}
