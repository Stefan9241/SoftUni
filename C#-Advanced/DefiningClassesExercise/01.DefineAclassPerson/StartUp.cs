using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person gosho = new Person()
            {
                Name = "Gosho",
                Age = 10
            };

            Console.WriteLine(gosho);
        }
    }
}
