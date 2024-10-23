using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Order_Aggregate
{
    //not table . its columns will add to OrderItem (as 1:1 both mandatory)
    //the reason from this is clean code (lan ay shwayt property lehm 3laka bb3d ahsn a3mlhm f class wakhod object mn elclass)
    public class ProductOrderItem
    {
        public ProductOrderItem(int productId, string productName, string productUrl)
        {
            ProductId = productId;
            ProductName = productName;
            ProductUrl = productUrl;
        }
        public ProductOrderItem() { }
        public int ProductId { get; set; }
        public string ProductName {  get; set; }
        public string ProductUrl{ get; set; }
    }
}
