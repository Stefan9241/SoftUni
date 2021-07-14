using System;

namespace Threeuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] nameAndCity = Console.ReadLine().Split();
            string name = $"{nameAndCity[0]} {nameAndCity[1]}";
            string adress = nameAndCity[2];
            string city = nameAndCity[3];
            Threeuple<string, string,string> tuple = new Threeuple<string, string,string>(name,adress, city);
            Console.WriteLine(tuple);
            string[] nameAndLiters = Console.ReadLine().Split();
            string name1 = nameAndLiters[0];
            bool drunkOrNot = nameAndLiters[2] == "drunk" ? true : false;
            double liters = double.Parse(nameAndLiters[1]);
            Threeuple<string, double, bool> tuple1 = new Threeuple<string, double, bool>(name1, liters,drunkOrNot);
            Console.WriteLine(tuple1);
            string[] intAndDouble = Console.ReadLine().Split();
            string firstName = intAndDouble[0];
            double doUble = double.Parse(intAndDouble[1]);
            string bankName = intAndDouble[2];
            Threeuple<string, double,string> tuple2 = new Threeuple<string, double, string>(firstName, doUble,bankName);
            Console.WriteLine(tuple2);
        }
    }
}
