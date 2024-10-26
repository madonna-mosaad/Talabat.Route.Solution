using Core.Layer.Order_Aggregate;

namespace Talabat.API.DTO
{
    public class OrderItemDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}