using System;

namespace _06._Foreign_Languages
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string lenguage = "";
            switch (country)
            {
                case "USA":
                case "England":
                    lenguage = "English";
                    break;
                case "Mexico":
                case "Spain":
                case "Argentina":
                    lenguage = "Spanish";
                    break;
                default:
                    lenguage = "unknown";
                    break;
            }
            Console.WriteLine($"{lenguage}");
        }
    }
}
