using System;
using System.IO;

namespace _06.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileNames = Directory.GetFiles(@"D:\Програми\Visual\C#-Advanced\StreamLab\06.FolderSize\TestFolder");
            double totalSize = 0;

            foreach (var fileName in fileNames)
            {
                var info = new FileInfo(fileName);
                totalSize += info.Length;
            }

            totalSize = totalSize / 1024 / 1024;

            File.WriteAllText("output.txt", totalSize.ToString());
        }
    }
}
