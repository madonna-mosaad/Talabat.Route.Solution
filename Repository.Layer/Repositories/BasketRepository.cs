using Core.Layer.Models;
using Core.Layer.RepositoriesInterface;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository.Layer.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer connectionMultiplexer) 
        { 
            _database = connectionMultiplexer.GetDatabase();
        }
        public async Task<bool> DeleteAsync(string id)
        {
           return await _database.KeyDeleteAsync(id);
        }

        public async Task<CustomerBasket?> GetAsync(string id)
        {
            var item= await _database.StringGetAsync(id);
            return item.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(item);
        }

        public async Task<CustomerBasket?> SetAsync(CustomerBasket customerBasket)
        {
            var item = await _database.StringSetAsync(customerBasket.Id,JsonSerializer.Serialize(customerBasket.Items),TimeSpan.FromDays(30));
            if (item)
            {
                return await GetAsync(customerBasket.Id);
            }
            return null;
        }
    }
}
