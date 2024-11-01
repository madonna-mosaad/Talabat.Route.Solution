using Core.Layer.Order_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.Specifications.SpecificationClasses
{
    public class OrderSpecificationsPaymentValues:BaseSpecifications<Order>
    {
        public OrderSpecificationsPaymentValues(string paymentId) : base(o => o.PaymentIntentId == paymentId)
        {
            
        }
    }
}
