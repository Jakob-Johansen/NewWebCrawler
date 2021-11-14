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

        // Checking if chromium is installed, if not it will install it + showing progress in percentage.
        public async Task CheckChromiumBrowser()
        {
            int progressNumber = 0;
            var rdmNumber = new Random();

            var browserFetcher = Puppeteer.CreateBrowserFetcher(new BrowserFetcherOptions());
            var revisionInfo = await browserFetcher.GetRevisionInfoAsync();

            if (!revisionInfo.Local)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Checking for Chromium");
                Thread.Sleep(1000);
                Console.WriteLine("Installing chromium please wait...");

                // Downloads Chromium in the background. Doing this so the progress bar/number can be shown in the console at the same time.
                var bfDownload = browserFetcher.DownloadAsync(BrowserFetcher.DefaultChromiumRevision).ConfigureAwait(true).GetAwaiter();

                // Outputs progress in percentages in console.
                while (progressNumber <= 100)
                {
                    Console.Write($"\rProgress: {progressNumber}%");

                    if (!bfDownload.IsCompleted && progressNumber <= 73)
                    {
                        progressNumber++;
                        Thread.Sleep(rdmNumber.Next(15, 500));
                    }
                    else if (bfDownload.IsCompleted && progressNumber <= 100)
                    {
                        progressNumber++;
                        Thread.Sleep(10);
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\nDone");

                Console.ResetColor();

                Thread.Sleep(1300);

                Console.Clear();
            }
            await LoadCrawlerAsync();
        }
    }
}
