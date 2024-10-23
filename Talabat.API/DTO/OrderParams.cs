namespace Talabat.API.DTO
{
    public class OrderParams
    {
        public string BuyerEmail {  get; set; }
        public string BasketId { get; set; }
        public int deliveryMethodId { get; set; }
       public AddressParams address {  get; set; }
    }
}
