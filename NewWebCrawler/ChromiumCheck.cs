using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewWebCrawler
{
    public class ChromiumCheck
    {
        public ChromiumCheck()
        {
        }

        // Checking if chromium is installed, if not it will install it + showing progress in percentage.
        public static async Task CheckChromiumBrowser()
        {
            int progressNumber = 0;
            var rdmNumber = new Random();

            // creates a variable that create a BrowserFetcher, that can be used to fx. install chromium.
            var browserFetcher = Puppeteer.CreateBrowserFetcher(new BrowserFetcherOptions());
            // Creates a variable that contains info about the newest chromium version.
            var revisionInfo = await browserFetcher.GetRevisionInfoAsync();

            // Checks if chromium is already installed.
            if (!revisionInfo.Local)
            {
                Console.ForegroundColor = System.ConsoleColor.Yellow;
                Console.WriteLine("Checking for Chromium");
                Thread.Sleep(1000);
                Console.WriteLine("Installing chromium please wait...");

                // Downloads Chromium in the background. Doing this so the progress bar/number can be shown in the console at the same time.
                var bfDownload = browserFetcher.DownloadAsync(BrowserFetcher.DefaultChromiumRevision).ConfigureAwait(true).GetAwaiter();

                // Outputs progress in percentages in console.
                while (progressNumber <= 100)
                {
                    Console.Write($"\rProgress: {progressNumber}%");

                    if (!bfDownload.IsCompleted && progressNumber < 73)
                    {
                        progressNumber++;
                        Thread.Sleep(rdmNumber.Next(15, 400));
                    }
                    else if (bfDownload.IsCompleted && progressNumber <= 100)
                    {
                        progressNumber++;
                        Thread.Sleep(10);
                    }
                }

                ConsoleColor.GreenColor("\n\nDone");

                Thread.Sleep(1300);

                Console.Clear();
            }
            return;
        }
    }
}
