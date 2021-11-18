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
            await ChromiumCheck.CheckChromiumBrowser();

            bool urlValidateBool = LinkChecker.UrlValidate(_url);
            bool urlCheckerBool = await LinkChecker.UrlCheck(_url);

            // if false
            if (!urlValidateBool || !urlCheckerBool)
                return;

            await StartCrawl();
        }

        public async Task StartCrawl()
        {
            if (!_isBrowserRunning)
            {
                _browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = false });
                _isBrowserRunning = true;
            }
            var page = await _browser.NewPageAsync();
            await page.GoToAsync(_url);

            // Crawl a tags here.


            await page.CloseAsync();
            return;

            //var browser = await Puppeteer.LaunchAsync(new LaunchOptions{ Headless = false, });
            //var page = await browser.NewPageAsync();
            //await page.GoToAsync(_url);
            //Console.ReadLine();
            //await browser.CloseAsync();
        }
    }
}
