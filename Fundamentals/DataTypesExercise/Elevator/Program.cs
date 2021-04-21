using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int elevate = people / capacity;
            int number = people % capacity;
            if (number != 0)
            {
                elevate++;
            }

            Console.WriteLine(elevate);
        }
    }
}
