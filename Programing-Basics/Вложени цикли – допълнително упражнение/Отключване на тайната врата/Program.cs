using System;

namespace Отключване_на_тайната_врата
{
    class Program
    {
        static void Main(string[] args)
        {
            //            Горната граница на стотиците -цяло число в диапазона(1 - 9)
            //Горната граница на десетиците -цяло число в диапазона(1 - 9)
            //Горната граница на единиците -цяло число в диапазона(1 - 9)
            int hundrets = int.Parse(Console.ReadLine());
            int dozens = int.Parse(Console.ReadLine());
            int units = int.Parse(Console.ReadLine());

            for (int num1 = 2; num1 <= hundrets; num1++)
            {
                for (int num2 = 2; num2 <= dozens; num2++)
                {
                    for (int num3 = 2; num3 <= units; num3++)
                    {
                        if (num1 % 2 ==0 && num3 % 2 == 0)
                        {
                            if (num2 == 2 || num2 == 3 || num2 == 5 || num2 == 7)
                            {
                                Console.WriteLine($"{num1} {num2} {num3}");
                            }
                            else 
                            {
                                break;
                            }
                        }
                    }
                }
            }

        }
    }
}
