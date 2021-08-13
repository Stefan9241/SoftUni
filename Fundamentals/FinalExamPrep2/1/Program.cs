using System;
using System.Linq;
using System.Text;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            var tokens = Console.ReadLine().Split(":|:", StringSplitOptions.RemoveEmptyEntries);
            while (tokens[0] != "Reveal")
            {
                if (tokens[0] == "InsertSpace")
                {
                    int index = int.Parse(tokens[1]);
                    message = message.Insert(index, " ");
                    Console.WriteLine(message);
                }
                else if(tokens[0] == "Reverse")
                {
                    string substring = tokens[1];
                    if (message.Contains(substring))
                    {
                        int indexOfSubstring = message.IndexOf(substring);
                        message = message.Remove(indexOfSubstring,substring.Length);
                        var sb = new StringBuilder();
                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                            sb.Append(substring[i]);
                        }
                        message = message.Insert(message.Length, sb.ToString());
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if(tokens[0] == "ChangeAll")
                {
                    string substringToReplace = tokens[1];
                    string replacement = tokens[2];
                    message = message.Replace(substringToReplace, replacement);
                    Console.WriteLine(message);
                }


                tokens = Console.ReadLine().Split(":|:", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
