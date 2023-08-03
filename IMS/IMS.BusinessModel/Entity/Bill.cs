using System;
using IMS.BusinessModel.Entity.Common;
using IMS.BusinessModel.Entity.Configuration;

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
        public virtual long CreatedBy { get; set; }
        public virtual int PaymentStatus { get; set; }
        public virtual bool IsArchived { get; set; }
        public virtual long? ModifiedBy { get; set; }
        public virtual DateTime? ModificationDate { get; set; }
    }
}
