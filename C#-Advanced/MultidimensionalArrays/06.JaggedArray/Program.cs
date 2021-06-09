using System;
using System.Linq;

namespace _06.JaggedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixRows = int.Parse(Console.ReadLine());
            int[][] jaggedMatrix = new int[matrixRows][];

            for (int row = 0; row < matrixRows; row++)
            {
                jaggedMatrix[row] = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                
            }

            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (commands[0].ToUpper() != "END")
            {
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);
                if (row < 0 || row >= jaggedMatrix.Length || col < 0 || col >= jaggedMatrix[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    continue;
                }

                switch (commands[0])
                {
                    case "Add":
                        jaggedMatrix[row][col] += value;
                        break;
                    case "Subtract":
                        jaggedMatrix[row][col] -= value;
                        break;
                    
                }
                commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in jaggedMatrix)
            {
                Console.WriteLine(string.Join(" ",item));
            }
        }
    }
}
