﻿using System;
using IMS.BusinessModel.Dto.CommonDtos;

namespace IMS.BusinessModel.Dto.PaymentVoucher
{
    public class PaymentVoucherDto : BaseDto
    {
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public long BillId { get; set; }
        public string BillSerialNumber { get; set; }
        public long PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public long? CashBankId { get; set; }
        public string CashBankName { get; set; }
    }

    public class PaymentVoucherFormDto
    {
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
        public long BillId { get; set; }
        public long PaymentTypeId { get; set; }
        public long? CashBankId { get; set; }
    }
}