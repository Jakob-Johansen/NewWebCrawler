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
        private readonly string _url;
        private Browser _browser;
        private bool _isBrowserRunning = false;

        public Crawler(string url)
        {
            _url = url.Trim().ToLower();
        }

        public async Task StartProgram()
        {
            // Runs a method that checks if chromium is installed, if not then it will install it.
            await ChromiumCheck.CheckChromiumBrowser();

            // Checks if the url is a real url.
            bool urlValidateBool = UrlChecker.UrlValidate(_url);
            ConsoleColor.YellowColor("Checking if the url is valid.");

            // Checks the if the HttpStatusCode is 200 (OK).
            bool urlCheckerBool = await UrlChecker.UrlStatusCheck(_url);
            ConsoleColor.YellowColor("Checking if the website is status 200 (OK).");

            // if false
            if (!urlValidateBool || !urlCheckerBool)
                return;

            ConsoleColor.GreenColor("Done.");

            await StartCrawl();
        }

        public async Task StartCrawl()
        {
            // If false
            if (!_isBrowserRunning)
            {
                // Opens a chromium broser;
                _browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = false });
                _isBrowserRunning = true;
            }

            // Opens a new page in the chromium browser
            var page = await _browser.NewPageAsync();
            
            // Searching for the inputted url.
            await page.GoToAsync(_url);


            // Crawl a tags here...


            // Closes the chromium browser page.
            await page.CloseAsync();

            return;
        }
    }
}
