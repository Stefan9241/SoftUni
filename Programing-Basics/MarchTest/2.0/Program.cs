using System;

namespace _2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string text1 = Console.ReadLine();
            string text2 = Console.ReadLine();
            string text3 = Console.ReadLine();
            int counterWon = 0;
            int counterLost = 0;
            int counterDraw = 0;

            if (text1[0] > text1[2])
            {
                counterWon++;
            }
            else if (text1[0] == text1[2])
            {
                counterDraw++;
            }
            else if (text1[0] < text1[2])
            {
                counterLost++;
            }

            if (text2[0] > text2[2])
            {
                counterWon++;
            }
            else if (text2[0] == text2[2])
            {
                counterDraw++;
            }
            else if (text2[0] < text2[2])
            {
                counterLost++;
            }

            if (text3[0] > text3[2])
            {
                counterWon++;
            }
            else if (text3[0] == text3[2])
            {
                counterDraw++;
            }
            else if (text3[0] < text3[2])
            {
                counterLost++;
            }

            Console.WriteLine($"Team won {counterWon} games.");
            Console.WriteLine($"Team lost {counterLost} games.");
            Console.WriteLine($"Drawn games: {counterDraw}");
        }
    }
}
