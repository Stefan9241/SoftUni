﻿using System;

namespace Коледна_елха
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            for (int row = 0; row <= n; row++)
            {
                for (int i = 0; i < n-row; i++)
                {
                    Console.Write(" ");
                }
                for (int i = 0; i < row; i++)
                {
                    Console.Write("*");
                }
                Console.Write(" | ");
                for (int i = 0; i < row; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
