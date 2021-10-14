using System;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            var heroRow = 0;
            var heroCol = 0;

            var firstPillarRow = -10;
            var firstPillarCol = -10;

            bool pillarExist = false;

            var secondPillarRow = -10;
            var secondPillarColl = -10;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < input.Length; j++)
                {
                    matrix[i, j] = input[j];
                    if (matrix[i, j] == 'S')
                    {
                        heroRow = i;
                        heroCol = j;
                    }
                    else if (matrix[i, j] == 'O' && pillarExist == false)
                    {
                        pillarExist = true;
                        firstPillarRow = i;
                        firstPillarCol = j;
                    }
                    else if (matrix[i, j] == 'O' && pillarExist == true)
                    {
                        secondPillarRow = i;
                        secondPillarColl = j;
                    }
                }
            }

            int sum = 0;
            bool isOutOfBounds = false;
            while (sum < 50)
            {
                string command = Console.ReadLine();
                if (command == "up")
                {
                    if (heroRow - 1 < 0)
                    {
                        isOutOfBounds = true;
                        matrix[heroRow, heroCol] = '-';
                        break;
                    }

                    if (matrix[heroRow - 1, heroCol] == 'O')
                    {
                        if (matrix[heroRow - 1, heroCol] == matrix[firstPillarRow, firstPillarCol])
                        {
                            matrix[heroRow, heroCol] = '-';
                            matrix[heroRow - 1, heroCol] = '-';
                            matrix[secondPillarRow, secondPillarColl] = 'S';
                            heroRow = secondPillarRow;
                            heroCol = secondPillarColl;
                        }
                        else
                        {
                            matrix[heroRow, heroCol] = '-';
                            matrix[heroRow - 1, heroCol] = '-';
                            matrix[firstPillarRow, firstPillarCol] = 'S';
                            heroRow = firstPillarRow;
                            heroCol = firstPillarCol;
                        }
                    }
                    else if (char.IsDigit(matrix[heroRow - 1, heroCol]))
                    {
                        sum += int.Parse(matrix[heroRow - 1, heroCol].ToString());
                        matrix[heroRow - 1, heroCol] = 'S';
                        matrix[heroRow, heroCol] = '-';
                        heroRow--;
                    }
                    else
                    {
                        matrix[heroRow, heroCol] = '-';
                        matrix[heroRow - 1, heroCol] = 'S';
                        heroRow--;
                    }

                }
                else if (command == "down")
                {
                    if (heroRow + 1 == n)
                    {
                        isOutOfBounds = true;
                        matrix[heroRow, heroCol] = '-';
                        break;
                    }

                    if (matrix[heroRow + 1, heroCol] == 'O')
                    {
                        if (matrix[heroRow + 1, heroCol] == matrix[firstPillarRow, firstPillarCol])
                        {
                            matrix[heroRow, heroCol] = '-';
                            matrix[heroRow + 1, heroCol] = '-';
                            matrix[secondPillarRow, secondPillarColl] = 'S';
                            heroRow = secondPillarRow;
                            heroCol = secondPillarColl;
                        }
                        else
                        {
                            matrix[heroRow, heroCol] = '-';
                            matrix[heroRow + 1, heroCol] = '-';
                            matrix[firstPillarRow, firstPillarCol] = 'S';
                            heroRow = firstPillarRow;
                            heroCol = firstPillarCol;
                        }
                    }
                    else if (char.IsDigit(matrix[heroRow + 1, heroCol]))
                    {
                        sum += int.Parse(matrix[heroRow + 1, heroCol].ToString());
                        matrix[heroRow + 1, heroCol] = 'S';
                        matrix[heroRow, heroCol] = '-';
                        heroRow++;
                    }
                    else
                    {
                        matrix[heroRow, heroCol] = '-';
                        matrix[heroRow + 1, heroCol] = 'S';
                        heroRow++;
                    }
                }
                else if (command == "left")
                {
                    if (heroCol - 1 < 0)
                    {
                        isOutOfBounds = true;
                        matrix[heroRow, heroCol] = '-';
                        break;
                    }

                    if (matrix[heroRow, heroCol - 1] == 'O')
                    {
                        if (matrix[heroRow, heroCol - 1] == matrix[firstPillarRow, firstPillarCol])
                        {
                            matrix[heroRow, heroCol] = '-';
                            matrix[heroRow, heroCol - 1] = '-';
                            matrix[secondPillarRow, secondPillarColl] = 'S';
                            heroRow = secondPillarRow;
                            heroCol = secondPillarColl;
                        }
                        else
                        {
                            matrix[heroRow, heroCol] = '-';
                            matrix[heroRow, heroCol - 1] = '-';
                            matrix[firstPillarRow, firstPillarCol] = 'S';
                            heroRow = firstPillarRow;
                            heroCol = firstPillarCol;
                        }
                    }
                    else if (char.IsDigit(matrix[heroRow, heroCol - 1]))
                    {
                        sum += int.Parse(matrix[heroRow, heroCol - 1].ToString());
                        matrix[heroRow, heroCol - 1] = 'S';
                        matrix[heroRow, heroCol] = '-';
                        heroCol--;
                    }
                    else
                    {
                        matrix[heroRow, heroCol] = '-';
                        matrix[heroRow, heroCol - 1] = 'S';
                        heroCol--;
                    }
                }
                else if (command == "right")
                {
                    if (heroCol + 1 == n)
                    {
                        isOutOfBounds = true;
                        matrix[heroRow, heroCol] = '-';
                        break;
                    }

                    if (matrix[heroRow, heroCol + 1] == 'O')
                    {
                        if (matrix[heroRow, heroCol + 1] == matrix[firstPillarRow, firstPillarCol])
                        {
                            matrix[heroRow, heroCol] = '-';
                            matrix[heroRow, heroCol + 1] = '-';
                            matrix[secondPillarRow, secondPillarColl] = 'S';
                            heroRow = secondPillarRow;
                            heroCol = secondPillarColl;
                        }
                        else
                        {
                            matrix[heroRow, heroCol] = '-';
                            matrix[heroRow, heroCol + 1] = '-';
                            matrix[firstPillarRow, firstPillarCol] = 'S';
                            heroRow = firstPillarRow;
                            heroCol = firstPillarCol;
                        }
                    }
                    else if (char.IsDigit(matrix[heroRow, heroCol + 1]))
                    {
                        sum += int.Parse(matrix[heroRow, heroCol + 1].ToString());
                        matrix[heroRow, heroCol + 1] = 'S';
                        matrix[heroRow, heroCol] = '-';
                        heroCol++;
                    }
                    else
                    {
                        matrix[heroRow, heroCol] = '-';
                        matrix[heroRow, heroCol + 1] = 'S';
                        heroCol++;
                    }
                }
            }

            if (isOutOfBounds)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            else
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }

            Console.WriteLine($"Money: {sum}");


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
