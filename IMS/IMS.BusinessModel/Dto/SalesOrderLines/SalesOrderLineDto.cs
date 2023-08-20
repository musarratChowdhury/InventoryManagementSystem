namespace IMS.BusinessModel.Dto.SalesOrderLines
{
    public sealed class SalesOrderLineDto
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedAmount { get; set; }
        public decimal Amount { get; set; }
        public decimal Total { get; set; }
        public long? ProductId { get; set; }
    }
}