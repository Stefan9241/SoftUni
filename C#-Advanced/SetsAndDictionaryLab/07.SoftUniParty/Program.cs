using System;
using System.Collections.Generic;
using System.Linq;
namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> normalGuests = new HashSet<string>();
            string guests = Console.ReadLine();
            while (guests != "PARTY")
            {
                if (guests == "END")
                {
                    foreach (var guest in vipGuests)
                    {
                        Console.WriteLine(guest);
                    }
                    foreach (var guest in normalGuests)
                    {
                        Console.WriteLine(guest);
                    }
                    return;
                }
                if (guests.Length == 8)
                {
                    char firstChar = guests[0];

                    if (char.IsDigit(firstChar))
                    {
                        vipGuests.Add(guests);
                    }
                    else
                    {
                        normalGuests.Add(guests);
                    }
                }
                guests = Console.ReadLine();
            }
            
            guests = Console.ReadLine();
            while (guests != "END")
            {
                
                vipGuests.Remove(guests);
                normalGuests.Remove(guests);

                guests = Console.ReadLine();
            }

            Console.WriteLine(vipGuests.Count + normalGuests.Count);
            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }
            foreach (var guest in normalGuests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
