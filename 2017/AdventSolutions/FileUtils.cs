using System;
using System.IO;

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
