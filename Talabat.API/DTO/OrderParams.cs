using System.ComponentModel.DataAnnotations;

namespace Talabat.API.DTO
{
    public class OrderParams
    {
        [Required]
        public string BuyerEmail {  get; set; }
        [Required]
        public string BasketId { get; set; }
        [Required]
        public int DeliveryMethodId { get; set; }
       public AddressParams Address {  get; set; }
    }
}
