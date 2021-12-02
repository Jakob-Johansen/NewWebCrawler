using System;
using System.Collections.Generic;
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
            _trimmedPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            _directoryPath = _trimmedPath + @"\SaveFiles";
            _filePath = _directoryPath + @"\Links.txt";
        }
        public void SaveToFile()
        {
            CheckDirAndFileExists();
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
                    File.Create(_filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
