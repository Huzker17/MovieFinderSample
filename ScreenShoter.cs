using ConsoleApp1.Interfaces;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using ConsoleApp1.Extensions;
using OpenQA.Selenium.Edge;

namespace ConsoleApp1
{
    public class ScreenShoter : IScreenShoter
    {
        private static int keyCounter = 1;
        private static IWebDriver driver;
        private static IMemoryCache cache;
        private readonly MemoryCacheEntryOptions CacheEntryOptions = new MemoryCacheEntryOptions().SetSize(1);
        private readonly ISearcher searcher;
        public ScreenShoter(IWebDriver _driver, IMemoryCache _cache, ISearcher _searcher) => (driver, cache, searcher) = (_driver, _cache, _searcher);


        public void TakeScreenShot(Uri url)
        {
            driver.Navigate().GoToUrl(url);
            try
            {
                while (keyCounter < 4)
                {
                    keyCounter++;
                    Screenshot takeScreenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    takeScreenshot.SaveFileToCache(cache, keyCounter, CacheEntryOptions);
                    var res = (byte[])cache.Get(keyCounter);
                    searcher.Search(res);
                    TakeScreenShot(url);
                }
                driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
