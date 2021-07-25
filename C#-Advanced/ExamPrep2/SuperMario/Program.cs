using System;
using System.Linq;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int numRows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[numRows][];

            int marioRow = 0;
            int marioCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var cols = Console.ReadLine();
                matrix[row] = new char[matrix.Length];
                for (int col = 0; col < cols.Length; col++)
                {
                    matrix[row][col] = cols[col];
                    if (matrix[row][col] == 'M')
                    {
                        marioCol = col;
                        marioRow = row;
                    }
                }
            }
            bool foundPrinces = false;
            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var direction = char.Parse(command[0]);
                var spawnRow = int.Parse(command[1]);
                var spawnCol = int.Parse(command[2]);
                matrix[spawnRow][spawnCol] = 'B';
                lives--;
                if (direction == 'W')
                {
                    if (marioRow - 1 < 0)
                    {
                        continue;
                    }
                    matrix[marioRow][marioCol] = '-';
                    marioRow--;
                }
                else if (direction == 'S')
                {
                    if (marioRow + 1 == numRows)
                    {
                        continue;
                    }
                    matrix[marioRow][marioCol] = '-';
                    marioRow++;

                }
                else if (direction == 'A')
                {
                    if (marioCol - 1 < 0)
                    {
                        continue;
                    }
                    matrix[marioRow][marioCol] = '-';
                    marioCol--;

                }
                else if (direction == 'D')
                {
                    if (marioCol + 1 == matrix[marioRow].Length)
                    {
                        continue;
                    }
                    matrix[marioRow][marioCol] = '-';
                    marioCol++;
                }

                if (lives <= 0)
                {
                    matrix[marioRow][marioCol] = 'X';
                    break;
                }
                else if (matrix[marioRow][marioCol] == 'B')
                {
                    lives -= 2;
                    if (lives <= 0)
                    {
                        matrix[marioRow][marioCol] = 'X';
                        break;
                    }
                }
                else if (matrix[marioRow][marioCol] == 'P')
                {
                    foundPrinces = true;
                    matrix[marioRow][marioCol] = '-';
                    break;
                }

                matrix[marioRow][marioCol] = 'M';
            }

            if (foundPrinces)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }
            else
            {
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
