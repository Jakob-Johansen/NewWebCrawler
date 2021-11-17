﻿using System;
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

            Crawler crawler = new("https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-constructors");
            await crawler.StartProgram();
        }
    }
}
