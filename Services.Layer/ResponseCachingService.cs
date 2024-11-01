
using Core.Layer.ServiceInterfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Services.Layer
{
    public class ResponseCachingService : IResponseCachingService
    {
        private IDatabase _database;
        public ResponseCachingService(IConnectionMultiplexer redis)
        {
            _database=redis.GetDatabase();

        }
        public async Task CacheResponseAsync(string key, object response, TimeSpan ExpireTime)
        {
            if (response is null) return;
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var SerializedResponse=JsonSerializer.Serialize(response,options);
            await _database.StringSetAsync(key, SerializedResponse, ExpireTime);
        }

        public async Task<string?> GetCacheResponseAsync(string key)
        {
            var response = await _database.StringGetAsync(key);
            if(response.IsNullOrEmpty) return null;
            return response;
        }
    }
}
