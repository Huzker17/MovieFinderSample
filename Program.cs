using ConsoleApp1;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using Microsoft.Extensions.Caching.Memory;
using OpenQA.Selenium.Edge;

IMemoryCache cache = new MemoryCache(new MemoryCacheOptions
{
    SizeLimit = 1024,
    ExpirationScanFrequency = TimeSpan.FromDays(1)
});
var opt = new EdgeOptions();
opt.AddArgument(@"--incognito");
WebDriver webDriver = new EdgeDriver(opt);
Searcher searcher = new Searcher();
ScreenShoter sc = new ScreenShoter(webDriver, cache,searcher);
TelegramBot bot = new TelegramBot(sc);
bot.Start();
Console.ReadLine();
