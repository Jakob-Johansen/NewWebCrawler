using System;
using System.Threading.Tasks;

namespace NewWebCrawler
{
    class Program
    {
        // WebCrawler
        static async Task Main(string[] args)
        {
            // https://www.automobile.tn/
            // https://www.apple.com/
            // https://www.proshop.dk/
            // http://monosoft.dk/

            // Javascript side
            // https://madfaerd.org/

            // Har sitemap
            // https://www.arla.dk/
            // https://www.microsoft.com/
            // https://netto.dk/
            // https://www.foetex.dk/
            // https://www.bilka.dk/
            // https://www.skousen.dk/
            // https://www.xl-byg.dk/

            //Crawler crawler = new("https://www.google.dk/");
            //await crawler.StartProgram();

            LinkChecker.TestLinkFilter();
        }
    }
}
