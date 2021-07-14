using System;

namespace Tuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] nameAndCity = Console.ReadLine().Split();
            string name = $"{nameAndCity[0]} {nameAndCity[1]}";
            string city = nameAndCity[2];
            Tuple<string, string> tuple = new Tuple<string, string>(name,city);
            Console.WriteLine(tuple);
            string[] nameAndLiters = Console.ReadLine().Split();
            string name1 = nameAndLiters[0];
            double liters = double.Parse(nameAndLiters[1]);
            Tuple<string, double> tuple1 = new Tuple<string, double>(name1,liters);
            Console.WriteLine(tuple1);
            string[] intAndDouble = Console.ReadLine().Split();
            int integer = int.Parse(intAndDouble[0]);
            double doUble = double.Parse(intAndDouble[1]);
            Tuple<int, double> tuple2 = new Tuple<int, double>(integer, doUble);
            Console.WriteLine(tuple2);
        }
    }
}
