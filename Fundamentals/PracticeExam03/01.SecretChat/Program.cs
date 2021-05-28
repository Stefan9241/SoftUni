using System;
using System.Linq;
namespace _01.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string secretMsg = Console.ReadLine();

            string[] commands = Console.ReadLine().Split(":|:",StringSplitOptions.RemoveEmptyEntries);
            while (commands[0] != "Reveal")
            {
                if (commands[0] == "InsertSpace")
                {
                    int index = int.Parse(commands[1]);
                    secretMsg = secretMsg.Insert(index, " ");
                    Console.WriteLine(secretMsg);
                }
                else if (commands[0] == "Reverse")
                {
                    string substring = commands[1];
                    char[] charArray = substring.ToCharArray();
                    Array.Reverse(charArray);
                    string reversedSubstring = string.Join("", charArray);
                    int indexOf = secretMsg.IndexOf(substring);
                    int lenght = substring.Length;
                    if (secretMsg.Contains(substring))
                    {
                        secretMsg = secretMsg.Remove(indexOf,lenght);
                        secretMsg = secretMsg.Insert(secretMsg.Length, reversedSubstring);
                        Console.WriteLine(secretMsg);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (commands[0] == "ChangeAll")
                {
                    string substring = commands[1];
                    string replacement = commands[2];
                    secretMsg = secretMsg.Replace(substring, replacement);
                    Console.WriteLine(secretMsg);
                }

                commands = Console.ReadLine().Split(":|:", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"You have a new text message: {secretMsg}");
        }
    }
}
