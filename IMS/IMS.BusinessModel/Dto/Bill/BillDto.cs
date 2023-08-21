using System;

namespace IMS.BusinessModel.Dto.Bill
{
    public class BillDto
    {
        public virtual DateTime BillDate { get; set; }
        public virtual DateTime BillDueDate { get; set; }
        public virtual long BillTypeId { get; set; }
        public virtual string BillTypeName { get; set; }
        public virtual long PurchaseOrderId {get; set;}
        public virtual string PurchaseOrderSerialNumber {get;set;}
    }

    public class BillFormDto
    {
        public virtual DateTime BillDate { get; set; }
        public virtual DateTime BillDueDate { get; set; }
        public virtual long BillTypeId { get; set; }
        public virtual long PurchaseOrderId {get; set;}
    }
}