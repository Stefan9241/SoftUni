using System;
using System.Text;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string[] tokens = Console.ReadLine().Split();
            while (tokens[0] != "Done")
            {
                if (tokens[0] == "TakeOdd")
                {
                    var sb = new StringBuilder();
                    for (int i = 1; i < password.Length; i += 2)
                    {
                        sb.Append(password[i]);
                    }
                    password = sb.ToString();
                    Console.WriteLine(password);
                }
                else if (tokens[0] == "Cut")
                {
                    int index = int.Parse(tokens[1]);
                    int lenght = int.Parse(tokens[2]);
                    password = password.Remove(index, lenght);
                    Console.WriteLine(password);
                }
                else if(tokens[0] == "Substitute")
                {
                    string substring = tokens[1];
                    string substitute = tokens[2];
                    if (password.Contains(substring))
                    {
                        password = password.Replace(substring, substitute);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
                tokens = Console.ReadLine().Split();
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
