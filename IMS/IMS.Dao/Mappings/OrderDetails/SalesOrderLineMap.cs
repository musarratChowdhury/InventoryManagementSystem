﻿using FluentNHibernate.Mapping;
using IMS.BusinessModel.Entity.OrderDetails;

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

            References(x => x.SalesOrder)
                .Not.Nullable();

            References(x => x.Product) 
                .LazyLoad();
        }
    }
}
