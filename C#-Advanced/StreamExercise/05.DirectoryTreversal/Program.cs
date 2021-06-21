using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.DirectoryTreversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<FileInfo>> filesByExtension = new Dictionary<string, List<FileInfo>>();

            string path = Console.ReadLine();

            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);

                string extension = info.Extension;
                if (!filesByExtension.ContainsKey(extension))
                {
                    filesByExtension[extension] = new List<FileInfo>();
                }
                filesByExtension[extension].Add(info);
            }

            using (StreamWriter writter = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt"))
            {
                foreach (var kvp in filesByExtension.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
                {
                    writter.WriteLine(kvp.Key);
                    foreach (var item in kvp.Value.OrderBy(x=>Math.Ceiling((double)x.Length / 1024)))
                    {
                        writter.WriteLine($"--{item.Name} - {Math.Ceiling((double)item.Length / 1024)}kb");
                    }
                }
            }
        }
    }
}
