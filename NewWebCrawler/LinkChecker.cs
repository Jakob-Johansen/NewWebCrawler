using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
            ConsoleColor.YellowColor("Checking if the url is valid.");

            if (url == null || url.Length == 0)
            {
                ConsoleColor.RedColor("NO URL FOUND!");
                return false;
            }

            string[] urlSplitArray;

            urlSplitArray = url.Split(new[] { "https://", "http://", "/" }, StringSplitOptions.RemoveEmptyEntries);

            string getExtension = Path.GetExtension(urlSplitArray[0]);

            if (getExtension != null && getExtension.Length != 0)
            {
                ConsoleColor.GreenColor("Done.");
                return true;
            }
            ConsoleColor.RedColor("The url Is not a website url.");
            return false;
        }

        public static async Task<bool> UrlCheck(string url)
        {
            ConsoleColor.YellowColor("Checking if the website is status 200 (OK).");
            try
            {
                HttpResponseMessage responseMessage = await client.GetAsync(url);
                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    ConsoleColor.GreenColor("Done");
                    return true;
                }
                else
                {
                    ConsoleColor.RedColor("The website status is not 200 (OK).");
                    return false;
                }
            }
            catch (Exception ex)
            {
                ConsoleColor.RedColor(ex.Message);
                return false;
            }
        }
    }
}
