using System;

namespace _01.TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] commands = Console.ReadLine().Split('|',StringSplitOptions.RemoveEmptyEntries);
            while (commands[0] != "Decode")
            {
                if (commands[0] == "Move")
                {
                    int numletters = int.Parse(commands[1]);
                    string lettersToMove = input.Substring(0, numletters);
                    input = input.Remove(0, lettersToMove.Length);
                    input = input.Insert(input.Length, lettersToMove);
                }
                else if (commands[0] == "Insert")
                {
                    int index = int.Parse(commands[1]);
                    string insertString = commands[2];
                    input = input.Insert(index, insertString);
                }
                else if (commands[0] == "ChangeAll")
                {
                    string substring = commands[1];
                    string replacement = commands[2];
                    input = input.Replace(substring, replacement);
                }

                commands = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"The decrypted message is: {input}");
        }
    }
}
