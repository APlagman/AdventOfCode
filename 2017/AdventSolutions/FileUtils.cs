using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventSolutions
{
    static class FileUtils
    {
        public static string PromptForExistingFilePath()
        {
            string filePath;
            do
            {
                Console.WriteLine("Provide input file:");
                filePath = Console.ReadLine();
            } while (!File.Exists(filePath));
            return filePath;
        }
    }
}
