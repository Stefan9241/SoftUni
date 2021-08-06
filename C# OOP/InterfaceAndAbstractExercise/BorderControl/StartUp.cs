using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var all = new List<IIdentifiable>();
            string[] commands = Console.ReadLine().Split();
            while (commands[0] != "End")
            {
                if (commands.Length > 2)
                {
                    all.Add(new Citizen(commands[0], int.Parse(commands[1]), commands[2]));
                }
                else if(commands.Length == 2)
                {
                    all.Add(new Robot(commands[0], commands[1]));
                }

                commands = Console.ReadLine().Split();
            }

            string filter = Console.ReadLine();
            var ids = new List<string>();
            foreach (var guy in all)
            {
                if (guy.Id.EndsWith(filter))
                {
                    ids.Add(guy.Id);
                }
            }

            foreach (var id in ids)
            {
                Console.WriteLine(id);
            }
        }
    }
}
