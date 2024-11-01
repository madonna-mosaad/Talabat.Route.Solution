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
            var itemBasket= await _database.StringGetAsync(id);
            var desirialize = itemBasket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<BasketResponse>(itemBasket);
            CustomerBasket? customerBasket = new CustomerBasket()
            {
                Id = id,
                Items = desirialize.BasketItems,
                DeliveryMethodId=desirialize.DeliveryMethodId,
                ClientSecret=desirialize.ClientSecret,
                PaymentId=desirialize.PaymentId

            };
            return customerBasket ;
        }
        //create or update
        public async Task<CustomerBasket?> SetAsync(CustomerBasket customerBasket)
        {
            var item = await _database.StringSetAsync(customerBasket.Id,JsonSerializer.Serialize(new BasketResponse() {
                BasketItems= customerBasket.Items ,
                DeliveryMethodId= customerBasket.DeliveryMethodId, 
                ClientSecret= customerBasket.ClientSecret, 
                PaymentId= customerBasket.PaymentId})
                ,TimeSpan.FromDays(30));
            if (item)
            {
                return await GetAsync(customerBasket.Id);
            }
            return null;
        }
    }
}
