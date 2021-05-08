using System;
using System.Linq;
namespace _05.DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            char[] arr = input.ToCharArray();
            string letters = string.Empty;
            string digits = string.Empty;
            string other = string.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                if (char.IsDigit(arr[i]))
                {
                    digits += arr[i];
                }
                else if (char.IsLetter(arr[i]))
                {
                    letters += arr[i];
                }
                else if (!char.IsLetterOrDigit(arr[i]))
                {
                    other += arr[i];
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(other);
        }
    }
}
