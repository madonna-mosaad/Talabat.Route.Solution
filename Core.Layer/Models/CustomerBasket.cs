using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Models
{
    public class CustomerBasket
    {
        public string Id { get; set; }//string because the key of redis is string
        public List<BasketItem> Items { get; set; }
    }
}
