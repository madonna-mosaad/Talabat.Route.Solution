using Core.Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Order_Aggregate
{
    public class DeliveryMethod:ModelBase
    {
        public DeliveryMethod(string shortName, string description, string dilveryTime, decimal cost)
        {
            ShortName = shortName;
            Description = description;
            DeliveryTime = dilveryTime;
            Cost = cost;
        }
        public DeliveryMethod() { }
        public string ShortName {  get; set; }
        public string Description { get; set; }
        public string DeliveryTime {  get; set; }
        public decimal Cost {  get; set; }
    }
}
