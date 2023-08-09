using FluentNHibernate.Mapping;
using IMS.BusinessModel.Entity.OrderDetails;

namespace IMS.Dao.Mappings.OrderDetails
{
    public class PurchaseOrderLineMap : ClassMap<PurchaseOrderLine>
    {
        public PurchaseOrderLineMap()
        {
            CompositeId()
            .KeyProperty(x => x.PurchaseOrderId, "PurchaseOrderId")
            .KeyReference(x => x.Product, "ProductId");

            Map(x => x.Quantity).Column("Quantity").Not.Nullable();
            Map(x => x.UnitPrice).Column("UnitPrice").Not.Nullable();
            Map(x => x.DiscountedAmount).Column("Discount");
            Map(x => x.Amount).Column("Amount").Not.Nullable();
            Map(x => x.Total).Column("Total").Not.Nullable();

            References(x => x.PurchaseOrder)
                .Not.Nullable()
                .Cascade.None();

            References(x => x.Product)
                .Cascade.None();
        }
    }
}
