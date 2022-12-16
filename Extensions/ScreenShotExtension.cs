using Microsoft.Extensions.Caching.Memory;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Extensions
{
    public static class ScreenShotExtension
    {
        public static void SaveFileToCache(this Screenshot sc, IMemoryCache cache, int keyCounter, MemoryCacheEntryOptions CacheEntryOptions)
        {
            cache.Set(keyCounter, sc.AsByteArray, CacheEntryOptions);
            sc.SaveAsFile(cache.Get(keyCounter).ToString());
        }   
    }
}
