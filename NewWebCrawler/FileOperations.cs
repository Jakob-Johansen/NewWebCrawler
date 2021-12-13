using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewWebCrawler
{
    public class FileOperations
    {
        private readonly string _trimmedPath;
        private readonly string _directoryPath;
        private readonly string _filePath;

        public FileOperations()
        {
            // Gets the path of the currentDirectory then trims the path. Fx C:\Users\NAME\source\repos\NewWebCrawler\NewWebCrawler. 
            _trimmedPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            _directoryPath = _trimmedPath + @"\SaveFiles";
            _filePath = _directoryPath + @"\Links.txt";
        }
        public async Task SaveToFile(string text)
        {
            CheckDirAndFileExists();

            // Adding text to the file.
            using StreamWriter sw = new(_filePath, append: true);
            await sw.WriteLineAsync(text);
        }

        // TEST REMOVE AFTER!
        public async Task SaveToSitemap(string text)
        {
            CheckDirAndFileExists();

            // Adding text to the file.
            using StreamWriter sw = new(_directoryPath + @"\Sitemaps.txt", append: true);
            await sw.WriteLineAsync(text);
        }

        public void CheckDirAndFileExists()
        {
            try
            {
                if (!Directory.Exists(_directoryPath))
                {
                    Directory.CreateDirectory(_directoryPath);
                }

                if (!File.Exists(_filePath))
                {
                    File.Create(_filePath).Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
