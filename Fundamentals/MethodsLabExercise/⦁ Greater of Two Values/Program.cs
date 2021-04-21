using System;

namespace __Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            
            switch (input)
            {
                case "int":
                    int num1 = int.Parse(Console.ReadLine());
                    int num2 = int.Parse(Console.ReadLine());
                    int result = GetMax(num1, num2);
                    Console.WriteLine(result);
                    break;
                case "char":
                    char first = char.Parse(Console.ReadLine());
                    char second = char.Parse(Console.ReadLine());
                    char outputLarger = GetCharMax(first, second);
                    Console.WriteLine(outputLarger);
                    break;
                case "string":
                    string firstString = Console.ReadLine();
                    string secondString = Console.ReadLine();
                    string outputLargerString = GetStringMax(firstString, secondString);
                    Console.WriteLine(outputLargerString);
                    break;
            }
        }

        private static int GetMax(int num1, int num2)
        {
            if (num1 > num2)
            {
                return num1;
            }
            else
            {
                return num2;
            }
        }

        static char GetCharMax(char first, char second)
        {
            char larger = (char)0x00;
            if (first >= second) larger = first;
            else larger = second;
            return larger;
        }

        static string GetStringMax(string first, string second)
        {
            string larger = string.Empty;
            if (first.CompareTo(second) >= 0) larger = first;
            else larger = second;
            return larger;
        }
    }
}
