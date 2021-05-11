using System;
using System.Linq;
using System.Text;

namespace _05.MultiplieBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string bignum = Console.ReadLine().TrimStart('0');
            int num = int.Parse(Console.ReadLine());
            
            var sb = new StringBuilder();

            if (num == 0 || bignum == " ")
            {
                Console.WriteLine("0");
                return;
            }

            int temp = 0;
            foreach (var ch in bignum.Reverse())
            {
                
                int digit = int.Parse(ch.ToString());
                int result = num * digit + temp;

                int restDigit = result % 10;
                temp = result / 10;

                sb.Insert(0, restDigit);
            }
            

            if (temp > 0)
            {
                sb.Insert(0, temp);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
