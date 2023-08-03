using FluentNHibernate.Mapping;
using IMS.BusinessModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Dao.Mappings
{
    public class PurchaseOrderMap : ClassMap<PurchaseOrder>
    {
        public PurchaseOrderMap()
        {
            Table("PurchaseOrder"); // Specify the table name

            Id(x => x.Id).Column("Id").GeneratedBy.Identity(); // Primary key
            Map(x => x.VendorId).Column("VendorId").Not.Nullable();
            Map(x => x.BillId).Column("BillId");
            Map(x => x.PaymentStatus).Column("PaymentStatus").Not.Nullable();
            Map(x => x.TotalAmount).Column("TotalAmount").Not.Nullable();
            Map(x => x.IsArchived).Column("IsArchived").Not.Nullable();

            References(x => x.Vendor) // Many-to-one relationship with Vendor
                .Column("VendorId")
                .LazyLoad()
                .Not.Insert()
                .Not.Update();

            //// One-to-one relationship with Bill
            //HasOne(x => x.Bill)
            //    .Constrained() // Optional - adds a foreign key constraint
            //    .Cascade.All() // You can specify cascade options if necessary
            //    .PropertyRef(nameof(Bill.PurchaseOrder)); // Specify the property in Bill that maps back to PurchaseOrder
                                                          // Note: You might need to adjust the property names if the mapping is different in Bill

            // BaseEntity properties
            Map(x => x.CreatedBy).Column("CreatedBy").Not.Nullable();
            Map(x => x.CreationDate).Column("CreationDate").Not.Nullable();
            Map(x => x.ModifiedBy).Column("ModifiedBy");
            Map(x => x.ModificationDate).Column("ModificationDate");
            Map(x => x.Rank).Column("Rank").Not.Nullable();
            Map(x => x.BusinessId).Column("BusinessId").Length(256); // Specify the length for BusinessId column
            Map(x => x.Version).Column("Version").Not.Nullable();
        }
    }
}
