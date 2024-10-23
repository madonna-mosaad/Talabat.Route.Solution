using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Order_Aggregate
{
    public class OrderItem:ModelBase
    {
        public OrderItem(ProductOrderItem productOrderItem, decimal price, int quantity)
        {
            this.productOrderItem = productOrderItem;
            Price = price;
            Quantity = quantity;
        }
        public OrderItem() { }
        //the reason from this is clean code (lan ay shwayt property lehm 3laka bb3d ahsn a3mlhm f class wakhod object mn elclass)
        public ProductOrderItem productOrderItem {  get; set; }
        public decimal Price {  get; set; }
        public int Quantity { get; set; }//number of pieces to same product
    }
}
