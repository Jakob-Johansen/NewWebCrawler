using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewWebCrawler
{
    public class LinkChecker
    {
        public static void CheckUrl(string url)
        {
            List<string> urlSplit = new();
            url = url.Trim().ToLower();

            // (?=[.])
            string pattern = @"([.])\b";
            urlSplit = Regex.Split(url, pattern).ToList();

            foreach (var item in urlSplit)
            {
                Console.WriteLine(item);
            }

            // https://www.google.dk/
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-constructors

        }
    }
}
