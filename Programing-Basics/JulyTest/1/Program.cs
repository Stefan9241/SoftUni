using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int ticketsOld = int.Parse(Console.ReadLine());
            int ticketsBaby = int.Parse(Console.ReadLine());
            double priceTicketOld = double.Parse(Console.ReadLine());
            double tax = double.Parse(Console.ReadLine());

            double priceBaby = priceTicketOld - priceTicketOld * 0.70;
            double oldWithTax = priceTicketOld + tax;
            double babyWithTax = priceBaby + tax;
            double total = babyWithTax * ticketsBaby + oldWithTax * ticketsOld;
            double totalPriceForDay = total * 0.20;
            Console.WriteLine($"The profit of your agency from {name} tickets is {totalPriceForDay:f2} lv.");
        }
    }
}
