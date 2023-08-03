using FluentNHibernate.Mapping;
using IMS.BusinessModel.Entity.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Dao.Mappings.OrderDetails
{
    public class SalesOrderLineMap : ClassMap<SalesOrderLine>
    {
        public SalesOrderLineMap()
        {
            CompositeId()
            .KeyProperty(x => x.SalesOrderId, "SalesOrderId")
            .KeyReference(x => x.Product, "ProductId");

            Map(x => x.Quantity).Column("Quantity").Not.Nullable();
            Map(x => x.UnitPrice).Column("UnitPrice").Not.Nullable();
            Map(x => x.DiscountedAmount).Column("Discount");
            Map(x => x.Amount).Column("Amount").Not.Nullable();
            Map(x => x.Total).Column("Total").Not.Nullable();

            References(x => x.SalesOrder) // Many-to-one relationship with SalesOrder
                .Not.Nullable()
                .LazyLoad()
                .Cascade.None();

            References(x => x.Product) // Many-to-one relationship with Product
                .LazyLoad()
                .Cascade.None();
        }
    }
}
