using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> invitedGuests = new List<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList());
                

            List<string> filter = new List<string>();

            string[] commands = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "Print")
            {
                if (commands[0] == "Add filter")
                {
                    filter.Add(commands[1] + " " + commands[2]);
                }
                else if (commands[0] == "Remove filter")
                {
                    filter.Remove(commands[1] + " " + commands[2]);
                }
                commands = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var filt in filter)
            {
                var command = filt.Split();
                if (command[0] == "Starts")
                {
                    invitedGuests = invitedGuests.Where(x => !x.StartsWith((command[2]))).ToList();
                }
                else if(command[0] == "Ends")
                {
                    invitedGuests = invitedGuests.Where(x => !x.EndsWith((command[2]))).ToList();
                }
                else if(command[0] == "Length")
                {
                    invitedGuests = invitedGuests.Where(x => x.Length != int.Parse(command[1])).ToList();
                }
                else if(command[0] == "Contains")
                {
                    invitedGuests = invitedGuests.Where(x => !x.Contains(command[1])).ToList();
                }
            }

            if (invitedGuests.Count > 0)
            {
                Console.WriteLine(string.Join(" ",invitedGuests));
            }
        }
    }
}
