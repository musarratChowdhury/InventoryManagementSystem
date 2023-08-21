using System;
using IMS.BusinessModel.Dto.CommonDtos;

namespace IMS.BusinessModel.Dto.PaymentReceive
{
    public class PaymentReceiveDto : BaseDto
    {
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public long InvoiceId { get; set; }
        public string InvoiceSerialNumber { get; set; }
        public long PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
    }

    public class PaymentReceiveFormDto
    {
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public long InvoiceId { get; set; }
        public long PaymentTypeId { get; set; }
    }
}