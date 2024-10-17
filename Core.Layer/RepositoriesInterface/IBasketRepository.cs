using Core.Layer.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.RepositoriesInterface
{
    public interface IBasketRepository
    {
        public Task<CustomerBasket?> GetAsync(string id);
        public Task<CustomerBasket?> SetAsync(CustomerBasket customerBasket);
        public Task<bool> DeleteAsync(string id);
    }
}
