using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.BusinessModel.Entity
{
    public class CustomerType : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int Status { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
