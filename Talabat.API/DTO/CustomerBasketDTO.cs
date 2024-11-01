using Core.Layer.Models;

namespace Talabat.API.DTO
{
    public class CustomerBasketDTO
    {
        public string Id { get; set; }//string because the key of redis is string
        public List<BasketItem> Items { get; set; }
        public CustomerBasketDTO(string id)
        {
            Id = id;
            Items = new List<BasketItem>();
        }
        public int DeliveryMethodId { get; set; }
        public string? PaymentId { get; set; }
        public string? ClientSecret { get; set; }
    }
}
