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

        // Checking if chromium is installed, if not it will install it.
        public async Task CheckChromiumBrowser()
        {
            var browserFetcher = Puppeteer.CreateBrowserFetcher(new BrowserFetcherOptions());
            var revisionInfo = await browserFetcher.GetRevisionInfoAsync();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Checking for installed chromium\n");

            if (!revisionInfo.Downloaded)
            {
                Console.WriteLine("Installing chromium please wait.\n");
                await browserFetcher.DownloadAsync(BrowserFetcher.DefaultChromiumRevision);
                Console.Write("Done\n");
            }
            else
            {
                Console.WriteLine("Chromium is already installed, the crawler will start soon\n");
            }
            Console.ResetColor();

            Thread.Sleep(3000);

            Console.Clear();

            await LoadCrawlerAsync();
        }
    }
}
