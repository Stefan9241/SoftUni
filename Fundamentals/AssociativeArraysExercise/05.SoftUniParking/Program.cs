using System;
using System.Collections.Generic;

namespace _05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] commands = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string comand = commands[0]; 
                string name = commands[1];
                
                if (comand == "register")
                {
                    string licence = commands[2];
                    if (dict.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licence}");
                    }
                    else
                    {
                        dict.Add(name, licence);
                        Console.WriteLine($"{name} registered {licence} successfully");
                    }
                }
                else
                {
                    if (dict.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} unregistered successfully");
                        dict.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                }
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
            
        }
    }
}
