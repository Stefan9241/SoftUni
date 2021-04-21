using System;

namespace RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());
            string result = RepeatString(text,num);
            Console.WriteLine(result);
        }

        private static string RepeatString(string v1 , int v2)
        {
            string result = "";
            for (int i = 0; i < v2; i++)
            {
                result += v1;
            }
            return (result);
        }
    }
}
