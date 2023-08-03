using IMS.BusinessModel.Entity.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.BusinessModel.Entity
{
    public class PurchaseOrder : BaseEntity
    {
        public virtual long VendorId { get; set; }
        public virtual long? BillId { get; set; }
        public virtual int PaymentStatus { get; set; }
        public virtual decimal TotalAmount { get; set; }
        public virtual bool IsArchived { get; set; }

        // Navigation property for the foreign key
        public virtual Vendor Vendor { get; set; }
        public virtual Bill Bill { get; set; }
    }
}
