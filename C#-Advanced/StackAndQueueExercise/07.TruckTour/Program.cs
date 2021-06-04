using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> queue = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                int[] cmd = Console.ReadLine().Split().Select(int.Parse).ToArray();
                queue.Enqueue(cmd);
            }
            
            int result = 0;
            while(true)
            {
                int total = 0;
                foreach (var item in queue)
                {
                    int petrol = item[0];
                    int distance = item[1];
                    total += petrol - distance;
                    if (total < 0)
                    {
                        queue.Enqueue(queue.Dequeue());
                        result++;
                        break;
                    }

                }
                if (total >= 0)
                {
                    break;
                }
            }
            Console.WriteLine(result);
        }
    }
}
