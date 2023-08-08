using System;
using System.Collections.Generic;
using System.Text;
using IMS.BusinessModel.Entity.Common;

namespace IMS.BusinessModel.Entity.Configuration
{
    public class PaymentType : BaseEntity, IConfigurationEntity
    {

        public virtual List<PaymentReceived> PaymentReceivedList { get; set; }
        public virtual List<PaymentVoucher> PaymentVoucherList { get; set; }

    }
}
