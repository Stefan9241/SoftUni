using System;

namespace Car_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int one = start; one <= end; one++)
            {
                for (int two = start; two <= end; two++)
                {
                    for (int three = start; three <= end; three++)
                    {
                        for (int four = start; four < one; four++)
                        {
                            if (four % 2 == 0)
                            {
                                if (one % 2 != 0)
                                {
                                    if ((one - four) % 2 != 0 && (two + three) % 2 == 0)
                                    {
                                        Console.Write($"{one}{two}{three}{four} ");
                                    }
                                }
                            }
                            else if (one > four)
                            {
                                if (one % 2 == 0)
                                {
                                    if (four % 2 != 0)
                                    {
                                        if ((one - four) % 2 != 0 && (two + three) % 2 == 0)
                                        {
                                            Console.Write($"{one}{two}{three}{four} ");
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
