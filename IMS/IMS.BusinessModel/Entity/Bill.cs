using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.BusinessModel.Entity
{
    public class Bill : BaseEntity
    {
        public virtual DateTime BillDate { get; set; }
        public virtual DateTime BillDueDate { get; set; }
        public virtual long BillTypeId { get; set; }
        public virtual BillType BillType { get; set; }
        //public virtual PurchaseOrder {get;set;}
        //public virtual PurchaseOrderId {get; set;}
    }
}
