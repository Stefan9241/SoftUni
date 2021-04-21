using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputBudget = double.Parse(Console.ReadLine());
            var inputCathegory = Console.ReadLine();
            var inputPeople = double.Parse(Console.ReadLine());

            var moneyTickets = 0.00;
            var moneyTransport = 0.00;
            var ticketsNumber = 0.00;
            var moneyLeftover = 0.00;

            if (inputPeople >= 1 && inputPeople <= 4)
            {
                moneyTickets = 0.25 * inputBudget;
                moneyTransport = 0.75 * inputBudget;
            }
            else if (inputPeople >= 5 && inputPeople <= 9)
            {
                moneyTickets = 0.40 * inputBudget;
                moneyTransport = 0.60 * inputBudget;
            }
            else if (inputPeople >= 10 && inputPeople <= 24)
            {
                moneyTickets = 0.50 * inputBudget;
                moneyTransport = 0.50 * inputBudget;
            }
            else if (inputPeople >= 25 && inputPeople <= 49)
            {
                moneyTickets = 0.6 * inputBudget;
                moneyTransport = 0.40 * inputBudget;

            }
            else if (inputPeople >= 50)
            {
                moneyTickets = 0.75 * inputBudget;
                moneyTransport = 0.25 * inputBudget;

            }
            else
            {
                Console.WriteLine("error with people");
            }
            if (inputCathegory == "Normal")
            {
                ticketsNumber = moneyTickets / 249.99;
                moneyLeftover = inputBudget - moneyTransport - inputPeople * 249.99;
            }
            else if (inputCathegory == "VIP")
            {
                ticketsNumber = moneyTickets / 499.99;
                moneyLeftover = inputBudget - moneyTransport - inputPeople * 499.99;
            }
            else
            {
                Console.WriteLine("error with cathegory");
            }
            if (ticketsNumber >= inputPeople)
            {
                Console.WriteLine("Yes! You have {0:f2} leva left.", moneyLeftover);
            }
            else if (ticketsNumber <= inputPeople)
            {
                Console.WriteLine("Not enough money! You need {0:f2} leva.", Math.Abs(moneyLeftover));
            }
            else
            {
                Console.WriteLine("error ticket calculation");
            }

        }
    }
}