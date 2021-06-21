using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader reader = new StreamReader("text.txt");
            using StreamWriter writer = new StreamWriter("output.txt");
            int linesCounter = 0;
            char[] chars = { '-', ',', '.', '!', '?' };
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                if (linesCounter % 2 == 0)
                {
                    line = ReplaceAll(chars, '@', line);
                    line = Reverse(line);
                    Console.WriteLine(line);
                    writer.WriteLine(line);
                }
                linesCounter++;
            }
        }

         static string Reverse(string line)
        {
            var sb = new StringBuilder();
            string[] word = line.Split(" ").ToArray();
            for (int i = 0; i < word.Length; i++)
            {
                sb.Append(word[word.Length - i - 1]);
                sb.Append(' ');
            }
            return sb.ToString().TrimEnd();
        }

        static string ReplaceAll(char[] chars, char v, string line)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < line.Length; i++)
            {
                char currSymbol = line[i];

                if (chars.Contains(currSymbol))
                {
                    sb.Append(v);
                }
                else
                {
                    sb.Append(currSymbol);
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
