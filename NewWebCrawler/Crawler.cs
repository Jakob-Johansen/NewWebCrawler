using PuppeteerSharp;
using System.Threading.Tasks;

namespace NewWebCrawler
{
    public class Crawler
    {
        private readonly string _url;
        private Browser _browser;
        private bool _isBrowserRunning = false;
        private UrlOperations _urlOperations;

        public Crawler(string url)
        {
            _url = url.Trim().ToLower();
            _urlOperations = new();
        }

        public async Task StartProgram()
        {
            // Runs a method that checks if chromium is installed, if not then it will install it.
            await ChromiumCheck.CheckChromiumBrowser();

            // Checks if the url is a real url.
            bool urlValidateBool = _urlOperations.UrlValidate(_url);
            ConsoleColor.YellowColor("Checking if the url is valid.");

            // Checks the if the HttpStatusCode is 200 (OK).
            bool urlCheckerBool = await _urlOperations.UrlStatusCheckAsync(_url);
            ConsoleColor.YellowColor("Checking if the website is status 200 (OK).");

            // if false
            if (!urlValidateBool || !urlCheckerBool)
            {
                if (!urlCheckerBool)
                {
                    ConsoleColor.RedColor("The website status is not 200 (OK).");
                }
                return;
            }

            ConsoleColor.GreenColor("Done.");

            await StartCrawl(_url);
        }

        public async Task StartCrawl(string url)
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
            await page.GoToAsync(url);


            // https://github.com/hardkoded/puppeteer-sharp/blob/master/samples/get-all-links/Program.cs
            // Crawl a tags here...


            // Closes the chromium browser page.
            await _browser.CloseAsync();

            return;
        }
    }
}
