using System;
using System.Collections.Generic;

namespace _01.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Stack<char> reverseText = new Stack<char>();

            for (int i = 0; i < text.Length; i++)
            {
                reverseText.Push(text[i]);
            }

            while (reverseText.Count > 0)
            {
                Console.Write(reverseText.Pop());
            }
        }
    }
}
