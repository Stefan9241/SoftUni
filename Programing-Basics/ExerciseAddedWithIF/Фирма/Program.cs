using System;

namespace Фирма
{
    class Program
    {
        static void Main(string[] args)
        {
            double needHours = double.Parse(Console.ReadLine()); //необходимите часовете 
            int days = int.Parse(Console.ReadLine()); // са дните, с които фирмата разполага 
            int workersExtraH = int.Parse(Console.ReadLine()); // броят на служителите, работещи извънредно 

            double time = (days - (days * 0.10)) * 8;
            double extraWork = workersExtraH * (days * 2);
            double totalHours = Math.Floor(time + extraWork);

            if (totalHours >= needHours)
            {
                Console.WriteLine($"Yes!{totalHours - needHours} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{needHours - totalHours} hours needed.");
            }
        }
    }
}
