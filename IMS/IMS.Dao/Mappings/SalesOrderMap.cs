using FluentNHibernate.Mapping;
using IMS.BusinessModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Dao.Mappings
{
    public class SalesOrderMap : ClassMap<SalesOrder>
    {
        public SalesOrderMap()
        {
            Table("SalesOrder");

            Id(x => x.Id).Column("Id").GeneratedBy.Identity();
            Map(x => x.CustomerId).Column("CustomerId").Not.Nullable();
            Map(x => x.TotalAmount).Column("TotalAmount").Not.Nullable();
            Map(x => x.IsArchived).Column("IsArchived").Not.Nullable();
            Map(x => x.ShipmentStatus).Column("ShipmentStatus").Not.Nullable();
            Map(x => x.PaymentStatus).Column("PaymentStatus").Not.Nullable();

            References(x => x.Customer) // Many-to-one relationship with Customer
                .Column("CustomerId")
                .LazyLoad()
                .Not.Insert()
                .Not.Update();

            //// One-to-one relationship with Invoice
            //HasOne(x => x.Invoice)
            //    .PropertyRef(nameof(Invoice.SalesOrder)) // Specify the property in Invoice that maps back to SalesOrder
            //    .Cascade.All() // You can specify cascade options if necessary
            //    .Constrained(); // Optional - adds a foreign key constraint
                                // Note: You might need to adjust the property names if the mapping is different in Invoice

            // BaseEntity properties
            Map(x => x.CreatedBy).Column("CreatedBy").Not.Nullable();
            Map(x => x.CreationDate).Column("CreationDate").Not.Nullable();
            Map(x => x.ModifiedBy).Column("ModifiedBy");
            Map(x => x.ModificationDate).Column("ModificationDate");
            Map(x => x.Rank).Column("Rank").Not.Nullable();
            Map(x => x.BusinessId).Column("BusinessId").Length(256);
            Map(x => x.Version).Column("Version").Not.Nullable();
        }
    }
}