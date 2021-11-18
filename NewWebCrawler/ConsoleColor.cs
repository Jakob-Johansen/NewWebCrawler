using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewWebCrawler
{
    public static class ConsoleColor
    {
        // Used for bad messages.
        public static void RedColor(string text)
        {
            Console.ForegroundColor = System.ConsoleColor.Red;
            Console.WriteLine(text.Trim());
            Console.ResetColor();
        }

        // Used for good messages.
        public static void GreenColor(string text)
        {
            Console.ForegroundColor = System.ConsoleColor.Green;
            Console.WriteLine(text.Trim());
            Console.ResetColor();
        }

        // Used when working on something.
        public static void YellowColor(string text)
        {
            Console.ForegroundColor = System.ConsoleColor.Yellow;
            Console.WriteLine(text.Trim());
            Console.ResetColor();
        }
    }
}
