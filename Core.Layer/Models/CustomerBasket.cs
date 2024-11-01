using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Models
{
    //in Redis
    public class CustomerBasket
    {
        public string Id { get; set; }//string because the key of redis is string
        public List<BasketItem> Items { get; set; }
        public int DeliveryMethodId {  get; set; }
        public string? PaymentId { get; set; }
        public string? ClientSecret {  get; set; }
    }
}
