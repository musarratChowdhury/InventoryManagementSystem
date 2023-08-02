using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.BusinessModel.Entity
{
    public class Vendor : BaseEntity
    {
        public long VendorTypeId { get; set; }
        public virtual VendorType VendorType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Status { get; set; }
    }
}
