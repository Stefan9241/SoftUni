using System;
using Telephony.Models;
using System.Linq;
namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] inputSites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var smartPhone = new Smartphone();
            var stationaryPhone = new StationaryPhone();

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                if (inputNumbers[i].Any(x=> char.IsLetter(x)))
                {
                    Console.WriteLine("Invalid number!");
                }
                else if (inputNumbers[i].Length == 10)
                {
                    smartPhone.Call(inputNumbers[i]);
                }
                else
                {
                    stationaryPhone.Call(inputNumbers[i]);
                }
            }

            for (int j = 0; j < inputSites.Length; j++)
            {
                if (inputSites[j].Any(s=> char.IsDigit(s)))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    smartPhone.Brawse(inputSites[j]);
                }
            }
        }
    }
}
