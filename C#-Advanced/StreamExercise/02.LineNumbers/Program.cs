using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("text.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                string curLine = lines[i];
                int countLetters = 0;
                int countPunctuation = 0;
                for (int j = 0; j < curLine.Length; j++)
                {
                    char currChar = curLine[j];
                    if (char.IsPunctuation(currChar))
                    {
                        countPunctuation++;
                    }
                    else if(char.IsLetter(currChar))
                    {
                        countLetters++;
                    }
                }
                lines[i] = $"Line {i + 1}:{curLine} ({countLetters})({countPunctuation})";
                
            }
            File.WriteAllLines("output.txt", lines);
        }
    }
}
