using System;
using System.Threading.Tasks;

namespace NewWebCrawler
{
    class Program
    {
        // WebCrawler
        static async Task Main(string[] args)
        {
            // Some websites to test on.

            // https://www.automobile.tn/
            // https://www.apple.com/
            // https://www.proshop.dk/
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-constructors

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

            // Remember to check trello.

            Crawler crawler = new("www.google.com");
            await crawler.StartProgram();
        }
    }
}
