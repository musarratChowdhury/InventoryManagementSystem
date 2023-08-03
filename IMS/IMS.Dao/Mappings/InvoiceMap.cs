using FluentNHibernate.Mapping;
using IMS.BusinessModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Dao.Mappings
{
    public class InvoiceMap : ClassMap<Invoice>
    {
        public InvoiceMap()
        {
            Table("Invoice"); // Specify the table name

            Id(x => x.Id).Column("Id").GeneratedBy.Identity(); // Primary key
            Map(x => x.InvoiceDate).Column("InvoiceDate").Not.Nullable();
            Map(x => x.InvoiceDueDate).Column("InvoiceDueDate").Not.Nullable();
            Map(x => x.InvoiceTypeId).Column("InvoiceTypeId").Not.Nullable();

            References(x => x.InvoiceType) // Many-to-one relationship with InvoiceType
                .Column("InvoiceTypeId")
                .LazyLoad()
                .Not.Insert()
                .Not.Update();

            References(x => x.SalesOrder)
                .Column("SalesOrderId");

            HasMany(x => x.PaymentReceivedList) // One-to-many relationship with PaymentReceived
                .KeyColumn("InvoiceId")
                .Cascade.All()
                .Inverse()
                .LazyLoad();

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
