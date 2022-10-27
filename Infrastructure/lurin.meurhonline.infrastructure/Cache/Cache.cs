
using System;
using System.Runtime.Caching;

namespace lurin.meurhonline.infrastructure.cache
{
    public static class Cache
    {
        private static readonly ObjectCache cache = MemoryCache.Default;

        public static void AddItem(string key, object objToCache, int daysInCache)
        {
            cache.Add(key, objToCache, DateTime.Now.AddDays(daysInCache));
        }

        public static T Get<T>(string key) where T : class
        {
            return (T)cache[key];
        }
    }
}
