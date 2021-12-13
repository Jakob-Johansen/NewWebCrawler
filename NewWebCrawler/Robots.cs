using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using PuppeteerSharp;

namespace NewWebCrawler
{
    public class Robots
    {
        // https://stackoverflow.com/questions/642293/how-do-i-read-and-parse-an-xml-file-in-c
        // https://docs.microsoft.com/en-us/dotnet/api/system.xml.xmldocument?view=net-6.0

        private Browser _browser;
        private UrlOperations _urlOperations;
        private XmlDocument _xmlDoc;
        private readonly string _urlRobots;

        private FileOperations _fo;

        public Robots(string url)
        {
            if (url.EndsWith("/"))
                _urlRobots = url + "robots.txt";
            else
                _urlRobots = url + "/robots.txt";

            _fo = new();
            _xmlDoc = new();
            _urlOperations = new();
        }

        // Need to be a bool
        public async Task CheckRobots()
        {
            // Checks if the website has a robots.txt / check the url status
            bool urlCheckStatus = await _urlOperations.UrlStatusCheckAsync(_urlRobots);

            // If url status is not OK
            if (!urlCheckStatus)
            {
                ConsoleColor.RedColor("No Robots.txt found!");

                // Needs to return false when i'm done with the code.
                return;
            }

            _browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = false });
            var page = await _browser.NewPageAsync();
            await page.GoToAsync(_urlRobots);

            var pageContent = await page.GetContentAsync();
            await _browser.CloseAsync();

            // Splits the pageContent at every new line, and adds it to an array.
            string[] pageContentArray = pageContent.Split(new string[] { "\n", "<" }, StringSplitOptions.RemoveEmptyEntries);
            List<string> sitemapList = new();

            foreach (var item in pageContentArray)
            {
                // Checks if item contains sitemap.
                if (item.ToLower().Contains("sitemap"))
                {
                    // Splits the sitemap line at whitespace and only adds the last of the string to the sitemapList. 
                    sitemapList.Add(item.Split(" ").Last().Trim());
                }
            }

            foreach (var item in sitemapList)
            {
                ScanSitemaps(item);
            }
        }

        public void ScanSitemaps(string link)
        {
            //string xmlUrl = "https://www.microsoft.com/store/productdetailpages.index.xml";

            // Works
            // Måske gøre så den bliver ved med at tjekke om der er flere "Children"
            // og kør en rekusive metode til den ikke finder flere og tjek om nogen
            // af dem indeholder loc.

            _xmlDoc.Load(link);
            var nodes = _xmlDoc.DocumentElement.ChildNodes;

            foreach (XmlNode fNode in nodes)
            {
                foreach (XmlNode sNode in fNode.ChildNodes)
                {
                    if (sNode.Name == "loc")
                    {
                        Console.WriteLine(sNode.InnerText);

                        if (sNode.InnerText.Contains(".xml"))
                        {
                            _fo.SaveToSitemap(sNode.InnerText).ConfigureAwait(true).GetAwaiter();
                            ScanSitemaps(sNode.InnerText);
                        }
                        else
                        {
                            _fo.SaveToFile(sNode.InnerText).ConfigureAwait(true).GetAwaiter();
                        }
                    }
                }
            }
        }
    }
}
