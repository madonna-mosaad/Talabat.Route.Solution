using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Models
{
    //not model but to help in desirialize in BasketRepository
    public class BasketResponse
    {
        public List<BasketItem> BasketItems { get; set; }
        public int DeliveryMethodId { get; set; }
        public string? ClientSecret { get; set; }
        public string? PaymentId { get; set; }
    }
}
