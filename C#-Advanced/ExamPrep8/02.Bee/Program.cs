using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var matrix = new char[number, number];

            int beeRow = 0;
            int beeCol = 0;

            for (int i = 0; i < number; i++)
            {
                string command = Console.ReadLine();
                for (int j = 0; j < command.Length; j++)
                {
                    matrix[i, j] = command[j];
                    if (matrix[i,j] == 'B')
                    {
                        beeRow = i;
                        beeCol = j;
                    }
                }
            }
            bool isOutOfBounds = false;
            int polinatedFlowers = 0;
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                else if (command == "up")
                {
                    if (beeRow - 1 < 0)
                    {
                        isOutOfBounds = true;
                        matrix[beeRow, beeCol] = '.';
                        break;
                    }

                    if (matrix[beeRow-1,beeCol] == 'f')
                    {
                        polinatedFlowers++;
                        matrix[beeRow, beeCol] = '.';
                        matrix[beeRow - 1, beeCol] = 'B';
                        beeRow--;
                    }
                    else if(matrix[beeRow - 1, beeCol] == 'O')
                    {
                        matrix[beeRow - 1, beeCol] = '.';
                        matrix[beeRow, beeCol] = '.';
                        beeRow--;
                        if (beeRow - 1 < 0)
                        {
                            isOutOfBounds = true;
                            matrix[beeRow, beeCol] = '.';
                            break;
                        }
                        else if (matrix[beeRow - 1, beeCol] == 'f')
                        {
                            polinatedFlowers++;
                            matrix[beeRow - 1, beeCol] = 'B';
                            beeRow--;
                        }
                        else
                        {
                            matrix[beeRow - 1, beeCol] = 'B';
                            beeRow--;
                        }
                    }
                    else
                    {
                        matrix[beeRow - 1, beeCol] = 'B';
                        matrix[beeRow, beeCol] = '.';
                        beeRow--;
                    }
                }
                else if (command == "down")
                {
                    if (beeRow + 1 == number)
                    {
                        isOutOfBounds = true;
                        matrix[beeRow, beeCol] = '.';
                        break;
                    }

                    if (matrix[beeRow + 1, beeCol] == 'f')
                    {
                        polinatedFlowers++;
                        matrix[beeRow, beeCol] = '.';
                        matrix[beeRow + 1, beeCol] = 'B';
                        beeRow++;
                    }
                    else if (matrix[beeRow + 1, beeCol] == 'O')
                    {
                        matrix[beeRow + 1, beeCol] = '.';
                        matrix[beeRow, beeCol] = '.';
                        beeRow++;
                        if (beeRow + 1 == number)
                        {
                            isOutOfBounds = true;
                            matrix[beeRow, beeCol] = '.';
                            break;
                        }
                        else if (matrix[beeRow + 1, beeCol] == 'f')
                        {
                            polinatedFlowers++;
                            matrix[beeRow + 1, beeCol] = 'S';
                            beeRow++;
                        }
                        else
                        {
                            matrix[beeRow + 1, beeCol] = 'S';
                            beeRow++;
                        }
                    }
                    else
                    {
                        matrix[beeRow + 1, beeCol] = 'B';
                        matrix[beeRow, beeCol] = '.';
                        beeRow++;
                    }
                }
                else if (command == "left")
                {
                    if (beeCol - 1 < 0)
                    {
                        isOutOfBounds = true;
                        matrix[beeRow, beeCol] = '.';
                        break;
                    }

                    if (matrix[beeRow , beeCol - 1] == 'f')
                    {
                        polinatedFlowers++;
                        matrix[beeRow, beeCol] = '.';
                        matrix[beeRow , beeCol - 1] = 'B';
                        beeCol--;
                    }
                    else if (matrix[beeRow , beeCol - 1] == 'O')
                    {
                        matrix[beeRow, beeCol - 1] = '.';
                        matrix[beeRow, beeCol] = '.';
                        beeCol--;
                        if (beeCol - 1 < 0)
                        {
                            isOutOfBounds = true;
                            matrix[beeRow, beeCol] = '.';
                            break;
                        }
                        else if (matrix[beeRow , beeCol - 1] == 'f')
                        {
                            polinatedFlowers++;
                            matrix[beeRow, beeCol - 1] = 'B';
                            beeCol--;
                        }
                        else
                        {
                            matrix[beeRow , beeCol - 1] = 'B';
                            beeCol--;
                        }
                    }
                    else
                    {
                        matrix[beeRow , beeCol - 1] = 'B';
                        matrix[beeRow, beeCol] = '.';
                        beeCol--;
                    }
                }
                else if (command == "right")
                {
                    if (beeCol + 1 == number)
                    {
                        isOutOfBounds = true;
                        matrix[beeRow, beeCol] = '.';
                        break;
                    }

                    if (matrix[beeRow, beeCol + 1] == 'f')
                    {
                        polinatedFlowers++;
                        matrix[beeRow, beeCol] = '.';
                        matrix[beeRow, beeCol + 1] = 'B';
                        beeCol++;
                    }
                    else if (matrix[beeRow, beeCol + 1] == 'O')
                    {
                        matrix[beeRow, beeCol + 1] = '.';
                        matrix[beeRow, beeCol] = '.';
                        beeCol++;
                        if (beeCol + 1 == number)
                        {
                            isOutOfBounds = true;
                            matrix[beeRow, beeCol] = '.';
                            break;
                        }
                        else if (matrix[beeRow, beeCol + 1] == 'f')
                        {
                            polinatedFlowers++;
                            matrix[beeRow, beeCol + 1] = 'B';
                            beeCol++;
                        }
                        else
                        {
                            matrix[beeRow, beeCol + 1] = 'B';
                            beeCol++;
                        }
                    }
                    else
                    {
                        matrix[beeRow, beeCol + 1] = 'B';
                        matrix[beeRow, beeCol] = '.';
                        beeCol++;
                    }
                }
            }

            if (isOutOfBounds)
            {
                Console.WriteLine("The bee got lost!");
            }

            if (polinatedFlowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - polinatedFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinatedFlowers} flowers!");
            }


            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
