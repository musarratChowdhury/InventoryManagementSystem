﻿using System;
using System.Collections.Generic;
using System.Text;
using IMS.BusinessModel.Entity.Common;

namespace IMS.BusinessModel.Entity.Configuration
{
    public class PaymentType : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Status { get; set; }

        public virtual List<PaymentReceived> PaymentReceivedList { get; set; }
        public virtual List<PaymentVoucher> PaymentVoucherList { get; set; }

    }
}
