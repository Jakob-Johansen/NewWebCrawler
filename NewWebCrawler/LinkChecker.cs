using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
        static readonly HttpClient client = new();

        public static bool UrlValidate(string url)
        {
            if (url == null || url.Length == 0)
            {
                ConsoleColor.RedColor("NO URL FOUND!");
                return false;
            }

            string[] urlSplitArray;

            urlSplitArray = url.Split(new [] { "https://", "http://", "/" }, StringSplitOptions.RemoveEmptyEntries);

            string getExtension = Path.GetExtension(urlSplitArray[0]);

            if (getExtension == null || getExtension.Length == 0)
            {
                ConsoleColor.RedColor("The url Is not a website url.");
                return false;
            }
            return true;
        }

        public static async Task UrlCheck(string url)
        {
            try
            {
                HttpResponseMessage responseMessage = await client.GetAsync(url);
                if (responseMessage.StatusCode.ToString() == "OK")
                    Console.WriteLine("Yay");
                else
                    Console.WriteLine("Nay");
            }
            catch (Exception ex)
            {
                ConsoleColor.RedColor(ex.Message);
            }
        }
    }
}
