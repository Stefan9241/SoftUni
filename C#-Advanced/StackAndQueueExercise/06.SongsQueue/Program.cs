using System;
using System.Collections.Generic;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
            Queue<string> songs = new Queue<string>(input);
            
            while (songs.Count > 0)
            {
                string command = Console.ReadLine();
                string[] cmd = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (cmd[0] == "Add")
                {
                    
                    string song = command.Substring(4);
                    if (!songs.Contains(song))
                    {
                        songs.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (command == "Play")
                {
                    songs.Dequeue();
                }
                else if (command == "Show")
                {
                    Console.WriteLine($"{string.Join(", ",songs)}");
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
