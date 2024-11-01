using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Order_Aggregate
{
    public class Order:ModelBase
    {
        public Order(string buyerEmail, Address shappingAddress, DeliveryMethod deliveryMethod, ICollection<OrderItem> items, decimal subTotal,string paymentIntentId)
        {
            BuyerEmail = buyerEmail;
            ShappingAddress = shappingAddress;
            DeliveryMethod = deliveryMethod;
            Items = items;
            SubTotal = subTotal;
            PaymentIntentId = paymentIntentId;
            
        }
        public Order() { }

        public string BuyerEmail {  get; set; }
        public DateTimeOffset OrderDate { get; set; }= DateTimeOffset.UtcNow;
        //will make HasConversion in fluentApi
        public Status Status { get; set; }
        //Address : Order is 1:1 and both mandatory (so they will put in same table (make it in fluentApi))
        public Address ShappingAddress { get; set; }
        //DeliveryMethod:Order is 1:M (bs ana m3mltsh el navigation property el many fe el DeliveryMethod 3lshan msh h7tag astkhdmha)
        //msh lazem a3ml fluent api lan fe el7ala d talma m3mltsh 7war el unique yb2a 1:1 w 1:M zy b3d
        public int? DeliveryMethodId {  get; set; }
        public DeliveryMethod? DeliveryMethod { get; set; }
        //OrserItem : Order is M:1 (I will use the many navigation property in my code so i write it )
        public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
        public decimal SubTotal {  get; set; }//price*Quantity to each item(product)
        public decimal GetTotal() => SubTotal + DeliveryMethod.Cost; //can make it property {get;}
        public string? PaymentIntentId { get; set; } 
    }
}
