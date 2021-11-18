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

        public Crawler(string url)
        {
            _url = url.Trim().ToLower();
        }

        public async Task StartProgram()
        {
            await ChromiumCheck.CheckChromiumBrowser();
            await LoadCrawlerAsync();
        }

        public async Task LoadCrawlerAsync()
        {
            bool urlValidateAndCheckBool = await LinkChecker.UrlValidate(_url);

            // if false
            if (!urlValidateAndCheckBool)
                return;

            //var browser = await Puppeteer.LaunchAsync(new LaunchOptions{ Headless = false, });
            //var page = await browser.NewPageAsync();
            //await page.GoToAsync(_url);
            //Console.ReadLine();
            //await browser.CloseAsync();
        }
    }
}
