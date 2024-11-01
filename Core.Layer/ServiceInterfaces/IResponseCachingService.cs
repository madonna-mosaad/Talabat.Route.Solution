using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Layer.ServiceInterfaces
{
    public interface IResponseCachingService
    {
        public Task CacheResponseAsync(string key, object response, TimeSpan ExpireTime);
        public Task<string?> GetCacheResponseAsync(string key);
    }
}
