using System;
using System.Collections.Generic;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                int curNum = int.Parse(Console.ReadLine());
                if (dict.ContainsKey(curNum) == false)
                {
                    dict.Add(curNum, new List<int>());
                }
                dict[curNum].Add(curNum);
            }

            foreach (var num in dict)
            {
                if (num.Value.Count % 2 == 0)
                {
                    Console.WriteLine(num.Key);
                }
            }
        }
    }
}
