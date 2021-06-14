using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            
            HashSet<string> nums = new HashSet<string>();

            string[] commands = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            while (commands[0] != "END")
            {
                string direction = commands[0];
                string carNumber = commands[1];
                if (direction == "IN")
                {
                    nums.Add(carNumber);
                }
                else
                {
                    nums.Remove(carNumber);
                }

                commands = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }
            if (nums.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }

            foreach (var number in nums)
            {
                Console.WriteLine(number);
            }
        }
    }
}
