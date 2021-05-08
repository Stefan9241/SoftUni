using System;
using System.Linq;
namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            string text = Console.ReadLine().ToLower();

            while (text.IndexOf(word) != -1)
            {
                int index = text.IndexOf(word);
                text = text.Remove(index, word.Length);
            }

            Console.WriteLine(text);
        }
    }
}
