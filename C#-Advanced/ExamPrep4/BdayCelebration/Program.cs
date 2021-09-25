using System;
using System.Collections.Generic;
using System.Linq;

namespace BdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] guestsCapacity = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> guests = new Queue<int>(guestsCapacity);

            int[] platesCapacity = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> plates = new Stack<int>(platesCapacity);
            int lefotvers = 0;
            while (guests.Count > 0 && plates.Count > 0)
            {
                var guest = guests.Peek();
                var plate = plates.Peek();
                if (plate > guest)
                {
                    lefotvers += plate - guest;
                    guests.Dequeue();
                    plates.Pop();
                }
                else if(guest > plate)
                {
                    guest -= plates.Pop();
                    while (guest > 0)
                    {
                        if (guest - plates.Peek() > 0)
                        {
                            guest -= plates.Pop();
                        }
                        else
                        {
                            lefotvers += plates.Peek() - guest;
                            guest = -10;
                            plates.Pop();
                            guests.Dequeue();
                        }
                    }
                }
                else
                {
                    guests.Dequeue();
                    plates.Pop();
                }
            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ",guests)}");
            }
            else
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }

            Console.WriteLine($"Wasted grams of food: {lefotvers}");
        }
    }
}
