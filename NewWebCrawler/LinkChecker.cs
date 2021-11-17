using System;
using System.Collections.Generic;
using System.IO;
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

            //(?=[.])
            string pattern = @"([.])\b";
            urlSplit = Regex.Split(url, pattern).ToList();

            foreach (var item in urlSplit)
            {
                Console.WriteLine(item);
            }

            // https://www.google.dk/
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-constructors

        }

        public static void TestLinkFilter()
        {
            string url = "https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-constructors";
            //string url = "https://www.google.dk/";

            url = url.Trim().ToLower();

            string[] urlSplitArray;

            urlSplitArray = url.Split(new [] { "https://", "http://", "/" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < urlSplitArray.Length; i++)
            {
                Console.Write($"[{i}: ");
                Console.WriteLine(urlSplitArray[i]);
            }

            //foreach (var item in testarray)
            //{
            //    Console.Write("Test: ");
            //    Console.WriteLine(item);
            //}

            //string getExtension = Path.GetExtension(urlSplitArray[1]);
        }
    }
}
