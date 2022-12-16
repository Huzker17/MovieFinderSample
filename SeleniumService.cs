using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.IE;
using System.Drawing.Imaging;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace ConsoleApp1
{
    public class SeleniumService
    {
        //static IWebDriver driver;

        public void seleniumScreenShot(Uri uri)
        {
            var driver = new EdgeDriver();

            driver.Navigate()
                .GoToUrl("http://bbc.com");

            driver.GetScreenshot()
                .SaveAsFile("stackoverflow.jpg", ScreenshotImageFormat.Jpeg);

            driver.Quit();
        }
    }
}
