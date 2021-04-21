using System;

namespace _05
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            for (int first = 1; first <= n; first++)
            {
                for (int second = 1; second <= n; second++)
                {
                    for (char third = 'a'; third < 'a'+l ; third++)
                    {
                        for (char forth= 'a'; forth < 'a'+l; forth++)
                        {
                            for (int fifth = 1; fifth <= n; fifth++)
                            {
                                if (fifth > first && fifth > second)
                                {
                                    Console.Write($"{first}{second}{third}{forth}{fifth} ");
                                }
                            }
                        }
                    }                   
                }  
            }
        }
    }
}
