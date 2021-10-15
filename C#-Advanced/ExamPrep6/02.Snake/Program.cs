using System;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var matrix = new char[n, n];
            var snakeRow = -10;
            var snakeCol = -10;

            var firstBurrowRow = -10;
            var firstBurrowCol = -10;

            var secondBurrowRow = -10;
            var secondBurrowCol = -10;

            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                for (int j = 0; j < command.Length; j++)
                {
                    matrix[i, j] = command[j];
                    if (matrix[i,j] == 'S')
                    {
                        snakeRow = i;
                        snakeCol = j;
                    }
                    else if(matrix[i,j] == 'B' && firstBurrowRow == -10)
                    {
                        firstBurrowRow = i;
                        firstBurrowCol = j;
                    }
                    else if (matrix[i, j] == 'B' && firstBurrowRow > -10)
                    {
                        secondBurrowRow = i;
                        secondBurrowCol = j;
                    }
                }
            }
            bool isOutOfBounds = false;
            int food = 0;
            while (food < 10)
            {
                string command = Console.ReadLine();
                if (command == "up")
                {
                    if (snakeRow - 1 < 0)
                    {
                        isOutOfBounds = true;
                        matrix[snakeRow, snakeCol] = '.'; //maybe '-'
                        break;
                    }

                    if (matrix[snakeRow - 1,snakeCol] == '*')
                    {
                        food++;
                        matrix[snakeRow, snakeCol] = '.';
                        matrix[snakeRow - 1, snakeCol] = 'S';
                        snakeRow--;
                    }
                    else if(matrix[snakeRow - 1, snakeCol] == 'B')
                    {
                        if (matrix[snakeRow - 1, snakeCol] == matrix[firstBurrowRow, firstBurrowCol])
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow - 1, snakeCol] = '.';
                            matrix[secondBurrowRow, secondBurrowCol] = 'S';
                            snakeRow = secondBurrowRow;
                            snakeCol = secondBurrowCol;
                        }
                        else
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow - 1, snakeCol] = '.';
                            matrix[firstBurrowRow, firstBurrowCol] = 'S';
                            snakeRow = firstBurrowRow;
                            snakeCol = firstBurrowCol;
                        }
                    }
                    else
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        matrix[snakeRow - 1, snakeCol] = 'S';
                        snakeRow--;
                    }
                }
                else if(command == "down")
                {
                    if (snakeRow + 1 == n)
                    {
                        isOutOfBounds = true;
                        matrix[snakeRow, snakeCol] = '.'; //maybe '-'
                        break;
                    }

                    if (matrix[snakeRow + 1, snakeCol] == '*')
                    {
                        food++;
                        matrix[snakeRow, snakeCol] = '.';
                        matrix[snakeRow + 1, snakeCol] = 'S';
                        snakeRow++;
                    }
                    else if (matrix[snakeRow + 1, snakeCol] == 'B')
                    {
                        if (matrix[snakeRow + 1, snakeCol] == matrix[firstBurrowRow, firstBurrowCol])
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow + 1, snakeCol] = '.';
                            matrix[secondBurrowRow, secondBurrowCol] = 'S';
                            snakeRow = secondBurrowRow;
                            snakeCol = secondBurrowCol;
                        }
                        else
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow + 1, snakeCol] = '.';
                            matrix[firstBurrowRow, firstBurrowCol] = 'S';
                            snakeRow = firstBurrowRow;
                            snakeCol = firstBurrowCol;
                        }
                    }
                    else
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        matrix[snakeRow + 1, snakeCol] = 'S';
                        snakeRow++;
                    }
                }
                else if(command == "left")
                {
                    if (snakeCol - 1 < 0)
                    {
                        isOutOfBounds = true;
                        matrix[snakeRow, snakeCol] = '.'; //maybe '-'
                        break;
                    }

                    if (matrix[snakeRow , snakeCol - 1] == '*')
                    {
                        food++;
                        matrix[snakeRow, snakeCol] = '.';
                        matrix[snakeRow , snakeCol - 1] = 'S';
                        snakeCol--;
                    }
                    else if (matrix[snakeRow, snakeCol - 1] == 'B')
                    {
                        if (matrix[snakeRow , snakeCol - 1] == matrix[firstBurrowRow, firstBurrowCol])
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow , snakeCol - 1] = '.';
                            matrix[secondBurrowRow, secondBurrowCol] = 'S';
                            snakeRow = secondBurrowRow;
                            snakeCol = secondBurrowCol;
                        }
                        else
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow , snakeCol - 1] = '.';
                            matrix[firstBurrowRow, firstBurrowCol] = 'S';
                            snakeRow = firstBurrowRow;
                            snakeCol = firstBurrowCol;
                        }
                    }
                    else
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        matrix[snakeRow , snakeCol - 1] = 'S';
                        snakeCol--;
                    }
                }
                else if(command == "right")
                {
                    if (snakeCol + 1 == n)
                    {
                        isOutOfBounds = true;
                        matrix[snakeRow, snakeCol] = '.'; //maybe '-'
                        break;
                    }

                    if (matrix[snakeRow, snakeCol + 1] == '*')
                    {
                        food++;
                        matrix[snakeRow, snakeCol] = '.';
                        matrix[snakeRow, snakeCol + 1] = 'S';
                        snakeCol++;
                    }
                    else if (matrix[snakeRow, snakeCol + 1] == 'B')
                    {
                        if (matrix[snakeRow, snakeCol + 1] == matrix[firstBurrowRow, firstBurrowCol])
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow, snakeCol + 1] = '.';
                            matrix[secondBurrowRow, secondBurrowCol] = 'S';
                            snakeRow = secondBurrowRow;
                            snakeCol = secondBurrowCol;
                        }
                        else
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[snakeRow, snakeCol + 1] = '.';
                            matrix[firstBurrowRow, firstBurrowCol] = 'S';
                            snakeRow = firstBurrowRow;
                            snakeCol = firstBurrowCol;
                        }
                    }
                    else
                    {
                        matrix[snakeRow, snakeCol] = '.';
                        matrix[snakeRow, snakeCol + 1] = 'S';
                        snakeCol++;
                    }
                }
            }

            if (isOutOfBounds)
            {
                Console.WriteLine("Game over!");
            }

            if (food >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {food}");


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
