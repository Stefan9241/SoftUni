using System;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] commands = Console.ReadLine().Split();
            while (commands[0] != "End")
            {
                Citizen citizen = new Citizen(commands[0], commands[1], int.Parse(commands[2]));
                Console.WriteLine(citizen.GetName());
                Console.WriteLine(((IResident)citizen).GetName());
                commands = Console.ReadLine().Split();
            }
        }
    }
}
