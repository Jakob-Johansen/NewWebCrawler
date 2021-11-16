using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewWebCrawler
{
    public class Crawler
    {

        private readonly string _link;

        public Crawler(string link)
        {
            _link = link;
        }

        public async Task StartProgram()
        {
            ChromiumCheck chromiumCheck = new();
            await chromiumCheck.CheckChromiumBrowser();

            await LoadCrawlerAsync();
        }

        public async Task LoadCrawlerAsync()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Start\n");
            Console.ResetColor();

            var browser = await Puppeteer.LaunchAsync(new LaunchOptions{ Headless = false, });
            var page = await browser.NewPageAsync();
            await page.GoToAsync(_link);
            Console.ReadLine();
            await browser.CloseAsync();
        }
    }
}
