using System;

namespace Survivor_2ndProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int beachRows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[beachRows][];
            int myTokens = 0;
            int opponentTokens = 0;
            for (int i = 0; i < beachRows; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                matrix[i] = new char[input.Length];
                for (int j = 0; j < input.Length; j++)
                {
                    matrix[i][j] = char.Parse(input[j]);
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "Find")
                {
                    int row = int.Parse(commands[1]);
                    int col = int.Parse(commands[2]);

                    if (CheckIfExist(row, col, matrix, beachRows))
                    {
                        if (matrix[row][col] == 'T')
                        {
                            myTokens++;
                            matrix[row][col] = '-';
                        }
                    }
                    else
                    {
                        continue;
                    }

                }
                else if (commands[0] == "Opponent")
                {
                    int row = int.Parse(commands[1]);
                    int col = int.Parse(commands[2]);
                    string direction = commands[3];

                    if (CheckIfExist(row, col, matrix, beachRows))
                    {
                        if (matrix[row][col] == 'T')
                        {
                            opponentTokens++;
                            matrix[row][col] = '-';
                        }
                    }
                    else
                    {
                        continue;
                    }


                    if (direction == "up")
                    {
                        if (row - 1 < 0)
                        {
                            continue;
                        }
                        else if (matrix[row - 1][col] == 'T')
                        {
                            opponentTokens++;
                            matrix[row - 1][col] = '-';
                        }

                        if (row - 2 < 0)
                        {
                            continue;
                        }
                        else if (matrix[row - 2][col] == 'T')
                        {
                            opponentTokens++;
                            matrix[row - 2][col] = '-';
                        }

                        if (row - 3 < 0)
                        {
                            continue;
                        }
                        else if (matrix[row - 3][col] == 'T')
                        {
                            opponentTokens++;
                            matrix[row - 3][col] = '-';
                        }

                    }
                    else if (direction == "down")
                    {
                        if (row + 1 == beachRows)
                        {
                            continue;
                        }
                        else if (matrix[row + 1][col] == 'T')
                        {
                            opponentTokens++;
                            matrix[row + 1][col] = '-';
                        }

                        if (row + 2 == beachRows)
                        {
                            continue;
                        }
                        else if (matrix[row + 2][col] == 'T')
                        {
                            opponentTokens++;
                            matrix[row + 2][col] = '-';
                        }

                        if (row + 3 == beachRows)
                        {
                            continue;
                        }
                        else if (matrix[row + 3][col] == 'T')
                        {
                            opponentTokens++;
                            matrix[row + 3][col] = '-';
                        }
                    }
                    else if (direction == "left")
                    {
                        if (col - 1 < 0)
                        {
                            continue;
                        }
                        else if (matrix[row][col - 1] == 'T')
                        {
                            opponentTokens++;
                            matrix[row][col - 1] = '-';
                        }

                        if (col - 2 < 0)
                        {
                            continue;
                        }
                        else if (matrix[row][col - 2] == 'T')
                        {
                            opponentTokens++;
                            matrix[row][col - 2] = '-';
                        }

                        if (col - 3 < 0)
                        {
                            continue;
                        }
                        else if (matrix[row][col - 3] == 'T')
                        {
                            opponentTokens++;
                            matrix[row][col - 3] = '-';
                        }
                    }
                    else if (direction == "right")
                    {
                        if (col + 1 == matrix[row].Length)
                        {
                            continue;
                        }
                        else if (matrix[row][col + 1] == 'T')
                        {
                            opponentTokens++;
                            matrix[row][col + 1] = '-';
                        }

                        if (col + 2 == matrix[row].Length)
                        {
                            continue;
                        }
                        else if (matrix[row][col + 2] == 'T')
                        {
                            opponentTokens++;
                            matrix[row][col + 2] = '-';
                        }

                        if (col + 3 == matrix[row].Length)
                        {
                            continue;
                        }
                        else if (matrix[row][col + 3] == 'T')
                        {
                            opponentTokens++;
                            matrix[row][col + 3] = '-';
                        }
                    }
                }
                else if (commands[0] == "Gong")
                {
                    break;
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ",row));
            }

            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        private static bool CheckIfExist(int row, int col, char[][] matrix, int beachRows)
        {
            if (row < 0 || row >= beachRows || col < 0 || matrix[row].Length <= col)
            {
                return false;
            }

            return true;
        }
    }
}
