using System;
using System.Text.RegularExpressions;

namespace Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            bool isSixToTenChars = CharactersCheck(input);
            bool letterAndDigits = LettersAndDigitsOnlyCheck(input);
            bool moreThenTwoDigits = MoreThenTwoDigits(input);
            if (isSixToTenChars
                && letterAndDigits
                && moreThenTwoDigits)
            {
                Console.WriteLine("Password is valid");
            }
            if (!isSixToTenChars)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!letterAndDigits)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!moreThenTwoDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
        }

        private static bool MoreThenTwoDigits(string input)
        {
            int counter = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char curr = input[i];
                bool isDigit = char.IsDigit(curr);
                if (isDigit)
                {
                    counter++;
                }
            }
            if (counter > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool LettersAndDigitsOnlyCheck(string input)
        {
            bool isMatch = Regex.IsMatch(input, @"^[a-zA-Z0-9]+$");
            if (isMatch)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private static bool CharactersCheck(string input)
        {
            if (input.Length >= 6 && input.Length <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
