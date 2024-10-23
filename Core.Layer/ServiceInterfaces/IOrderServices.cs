using Core.Layer.Order_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.ServiceInterfaces
{
    public interface IOrderServices
    {
        public Task<Order> CreateOrder(string BuyerEmail, string BasketId, int deliveryMethodId, Address address);
        public Task<IReadOnlyList<Order>> GetOrdersToSpecificUser(string BuyerEmail);
        public Task<Order> GetSpecificOrderByIdToSpecificUser(string BuyerEmail, int OrderId);
    }
}
