using System;

namespace _07
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            int studentCounter = 0;
            int kidCounter = 0;
            int standardCounter = 0;
            
            while (title !="Finish")
            {
                double freeSpace = double.Parse(Console.ReadLine());
                double ticketsCounter = 0;
                string tickets = Console.ReadLine();
                while (tickets != "End" && freeSpace > ticketsCounter)
                {
                    ticketsCounter++;
                    if (tickets == "student" )
                    {
                        studentCounter++;
                    }
                    else if (tickets == "kid")
                    {
                        kidCounter++;
                    }
                    else if (tickets == "standard")
                    {
                        standardCounter++;
                    }
                    tickets = Console.ReadLine();

                }
                Console.WriteLine($"{title} - {(ticketsCounter / freeSpace) * 100:f2}% full.");
                if (freeSpace <= ticketsCounter)
                {
                    break;
                }
                title = Console.ReadLine();
             
            }

            double totalTickets = standardCounter + kidCounter + studentCounter;
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{studentCounter / totalTickets * 100:f2}% student tickets.");
            Console.WriteLine($"{standardCounter / totalTickets * 100:F2}% standard tickets.");
            Console.WriteLine($"{kidCounter / totalTickets * 100:f2}% kids tickets.");
        }
    }
}
