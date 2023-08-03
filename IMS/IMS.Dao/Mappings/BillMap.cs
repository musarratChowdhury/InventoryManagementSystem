using FluentNHibernate.Cfg;
using FluentNHibernate.Mapping;
using IMS.BusinessModel.Entity;
using IMS.Dao.Mappings;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Dao.Mappings
{
    public class BillMap : ClassMap<Bill>
    {
        public BillMap()
        {
            Table("Bill"); // Specify the table name

            Id(x => x.Id).Column("Id").GeneratedBy.Identity(); // Primary key
            Map(x => x.BillDate).Column("BillDate").Not.Nullable();
            Map(x => x.BillDueDate).Column("BillDueDate").Not.Nullable();
            Map(x => x.BillTypeId).Column("BillTypeId").Not.Nullable();

            References(x => x.BillType) // Many-to-one relationship with BillType
                .Column("BillTypeId")
                .LazyLoad()
                .Not.Insert()
                .Not.Update();

            // One-to-one relationship with PurchaseOrder
            //HasOne(x => x.PurchaseOrder)
            //    .PropertyRef(nameof(PurchaseOrder.Bill)) // Specify the property in PurchaseOrder that maps back to Bill
            //    .Cascade.All() // You can specify cascade options if necessary
            //    .Constrained(); // Optional - adds a foreign key constraint

            HasMany(x => x.PaymentVoucherList) // One-to-many relationship with PaymentVoucher
                .KeyColumn("BillId")
                .Cascade.All()
                .Inverse()
                .LazyLoad();

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
