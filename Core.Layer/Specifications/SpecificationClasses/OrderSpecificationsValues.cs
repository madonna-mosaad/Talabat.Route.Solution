using Core.Layer.Order_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Specifications.SpecificationClasses
{
    public class OrderSpecificationsValues:BaseSpecifications<Order>
    {
        public OrderSpecificationsValues(string email) : base(o=>o.BuyerEmail==email)
        {
            Includes.Add(o => o.DeliveryMethod);
            //many but mandatory so eager not lazy
            Includes.Add(o => o.Items);
        }
        public OrderSpecificationsValues(string email, int id) : base(o => o.BuyerEmail == email&&o.Id==id)
        {
            Includes.Add(o => o.DeliveryMethod);
            //many but mandatory so eager not lazy
            Includes.Add(o => o.Items);
        }
    }
}
