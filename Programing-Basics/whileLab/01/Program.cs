﻿using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (text != "Stop")
            {
                Console.WriteLine(text);
                text =Console.ReadLine();
            }
        }
    }
}
