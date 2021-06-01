using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> nums = new Stack<int>(input);

            string[] cmd = Console.ReadLine().Split();

            while (cmd[0].ToUpper() != "END")
            {
                if (cmd[0].ToUpper() == "ADD")
                {
                    int firstNum = int.Parse(cmd[1]);
                    int secNum = int.Parse(cmd[2]);
                    nums.Push(firstNum);
                    nums.Push(secNum);
                }
                else
                {
                    int count = int.Parse(cmd[1]);
                    if (count > nums.Count)
                    {
                        cmd = Console.ReadLine().Split();
                        continue;
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            nums.Pop();
                        }
                    }
                    
                }

                cmd = Console.ReadLine().Split();
            }

            Console.WriteLine($"Sum: {nums.Sum()}");
        }
    }
}
