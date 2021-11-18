using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewWebCrawler
{
    public class ConsoleColor
    {
        public static void RedColor(string text)
        {
            Console.ForegroundColor = System.ConsoleColor.Red;
            Console.WriteLine(text.Trim());
            Console.ResetColor();
        } 
    }
}
