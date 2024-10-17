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
    }
}
