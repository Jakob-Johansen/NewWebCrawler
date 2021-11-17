using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewWebCrawler
{
    // ------------------------------------- //
    // Remember this - DONT DELETE.          //
    // Regex split every . but dont delete.  //
    // @"([.])\b"                            //
    // Regex.Split(url, @"([.])\b).ToList(); //
    // ------------------------------------- //

    public class LinkChecker
    {
        public static bool UrlValidate(string url)
        {
            url = url.Trim().ToLower();

            string[] urlSplitArray;

            urlSplitArray = url.Split(new [] { "https://", "http://", "/" }, StringSplitOptions.RemoveEmptyEntries);

            string getExtension = Path.GetExtension(urlSplitArray[0]);

            if (getExtension == null || getExtension.Length == 0)
            {
                Console.WriteLine("Is not a website url.");
                return false;
            }
            return true;
        }
    }
}
