using System;

namespace _3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Етап на първенството – текст - “Quarter final ”, “Semi final” или “Final”
            //Вид на билета – текст - “Standard”, “Premium” или “VIP”
            //Брой билети – цяло число в интервала[1 … 30]
            //Снимка с трофея – символ – 'Y'(да) или 'N'(не)

            string stage = Console.ReadLine();
            string typeTicket = Console.ReadLine();
            int numTickets = int.Parse(Console.ReadLine());
            char picture = char.Parse(Console.ReadLine());
            double ticketPrice = 0;
            switch (stage)
            {
                case "Quarter final":
                    switch (typeTicket)
                    {
                        case "Standard":
                            ticketPrice = 55.50;
                            break;
                        case "Premium":
                            ticketPrice = 105.20;
                            break;
                        case "VIP":
                            ticketPrice = 118.90;
                            break;
                    }
                    break;
                case "Semi final":
                    switch (typeTicket)
                    {
                        case "Standard":
                            ticketPrice = 75.88;
                            break;
                        case "Premium":
                            ticketPrice = 125.22;
                            break;
                        case "VIP":
                            ticketPrice = 300.40;
                            break;
                    }
                    break;
                case "Final":
                    switch (typeTicket)
                    {
                        case "Standard":
                            ticketPrice = 110.10;
                            break;
                        case "Premium":
                            ticketPrice = 160.66;
                            break;
                        case "VIP":
                            ticketPrice = 400;
                            break;
                    }
                    break;
            }
            double totalPrice = numTickets * ticketPrice;
            double price = totalPrice;
            if (totalPrice > 4000)
            {
                totalPrice -= totalPrice * 0.25;
            }
            else if (totalPrice > 2500)
            {
                totalPrice -= totalPrice * 0.10;
            }
            if (picture == 'Y' && price < 4000)
            {
                totalPrice += numTickets * 40;
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
