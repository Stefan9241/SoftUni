using System;

namespace _01.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string input = Console.ReadLine();
            while (input != "Done")
            {
                string[] cmdArgs = input.Split();
                string command = cmdArgs[0];

                if (command == "TakeOdd")
                {
                    string newPass = "";
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            newPass += password[i];
                        }
                    }
                    password = newPass;
                    Console.WriteLine(password);
                }
                else if (command == "Cut")
                {
                    int index = int.Parse(cmdArgs[1]);
                    int lenght = int.Parse(cmdArgs[2]);
                    password = password.Remove(index, lenght);
                    Console.WriteLine(password);
                }
                else if (command == "Substitute")
                {
                    string substring = cmdArgs[1];
                    string subtitue = cmdArgs[2];
                    if (password.Contains(substring))
                    {
                        password = password.Replace(substring, subtitue);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }


                input = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
