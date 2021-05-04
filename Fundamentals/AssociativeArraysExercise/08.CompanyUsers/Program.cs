using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new SortedDictionary<string, List<string>>();
            string[] cmdArg = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries) ;

            while (cmdArg[0] != "End")
            {
                string companyName = cmdArg[0];
                string userId = cmdArg[1];
                if (!input.ContainsKey(companyName))
                {
                    input.Add(companyName, new List<string> { userId });
                }
                else
                {
                    if (!input[companyName].Contains(userId))
                    {
                        input[companyName].Add(userId);
                    }
                }
                cmdArg = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var item in input)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var id in item.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }

        }
    }
}
