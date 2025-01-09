using MonkeyCache.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoMonkeyCache
{
    public static class CustomCache
    {
        public static T Get_Cache<T>(string key)
        {
            var cache = Barrel.Current.Get<T>(key);
            return cache;
        }

        public static void Set_Cache<T>(string key, T value)
        {
            Barrel.Current.Add(key, value, TimeSpan.FromDays(1));
        }

        public static void Remove_Cache(string key)
        {
            Barrel.Current.Empty(key);
        }

        public static bool Exists_Cache(string key)
        {
            return Barrel.Current.Exists(key);
        }
        public static void Clear_AllCache()
        {
            Barrel.Current.EmptyAll();
        }

        public static void Clear_Cache(string key)
        {
            Barrel.Current.Empty(key);
        }
    }
}
