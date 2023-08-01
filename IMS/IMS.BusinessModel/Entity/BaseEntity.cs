using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.BusinessModel.Entity
{
    public class BaseEntity
    {
        public virtual long Id { get; set; }
        public virtual long CreatedBy { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual long? ModifiedBy { get; set; }
        public virtual DateTime? ModificationDate { get; set; }
        public virtual int Rank { get; set; }
        public virtual string BusinessId { get; set; }
        public virtual int Version { get; set; }
    }
}
