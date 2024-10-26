using Core.Layer.Order_Aggregate;

namespace Talabat.API.DTO
{
    public class OrderDTO
    {
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public string Status { get; set; }
        public Address ShappingAddress { get; set; }
        public string DeliveryMethodName { get; set; }
        public decimal DeliveryMethodPrice {  get; set; }
        public ICollection<OrderItemDTO> Items { get; set; } 
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public string PaymentIntentId { get; set; }
    }
}
