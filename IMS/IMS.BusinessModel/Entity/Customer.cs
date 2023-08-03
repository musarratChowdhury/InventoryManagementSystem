using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.BusinessModel.Entity
{
    public class Customer : BaseEntity
    {
        public virtual long CustomerTypeId { get; set; }
        public virtual CustomerType CustomerType { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Address { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual int Status { get; set; }
    }

}
