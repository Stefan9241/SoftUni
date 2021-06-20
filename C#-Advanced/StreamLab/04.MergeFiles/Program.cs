using System;
using System.IO;

namespace _04.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader firstReader = new StreamReader("FileOne.txt");
            using StreamReader secondReader = new StreamReader("FileTwo.txt");

            using StreamWriter writer = new StreamWriter("Output.txt");

            string word = firstReader.ReadLine();
            while (word != null)
            {
                string secWord = secondReader.ReadLine();
                writer.WriteLine(word);
                writer.WriteLine(secWord);
                word = firstReader.ReadLine();
            }
        }
    }
}
