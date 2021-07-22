using System;
using System.Linq;

namespace Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            int countCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeOfMatrix, sizeOfMatrix];
            int playerRow = 0;
            int playerCol = 0;
            for (int row = 0; row < sizeOfMatrix; row++)
            {
                string currRowCommands = Console.ReadLine();
                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    matrix[row, col] = currRowCommands[col];
                    if (matrix[row, col] == 'f')
                    {
                        playerCol = col;
                        playerRow = row;
                    }
                }
            }

            bool playerWon = false;

            for (int i = 0; i < countCommands; i++)
            {
                string command = Console.ReadLine();
                if (command == "up")
                {
                    matrix[playerRow, playerCol] = '-';
                    if (playerRow - 1 < 0)
                    {
                        playerRow = sizeOfMatrix - 1;
                    }
                    else
                    {
                        playerRow--;
                    }

                    if (matrix[playerRow, playerCol] == 'T')
                    {
                        if (playerRow == sizeOfMatrix - 1)
                        {
                            playerRow = 0;
                        }
                        else
                        {
                            playerRow++;
                        }
                        matrix[playerRow, playerCol] = 'f';
                        continue;
                    }
                    else if (matrix[playerRow, playerCol] == 'F')
                    {
                        playerWon = true;
                        matrix[playerRow, playerCol] = 'f';
                        break;
                    }
                    else if (matrix[playerRow, playerCol] == 'B')
                    {
                        matrix[playerRow, playerCol] = 'B';
                        playerRow--;
                        if (playerRow - 1 < 0)
                        {
                            playerRow = sizeOfMatrix - 1;
                        }
                        else
                        {
                            playerRow--;
                        }

                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            playerWon = true;
                            matrix[playerRow, playerCol] = 'f';
                            break;
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            if (playerRow == sizeOfMatrix - 1)
                            {
                                playerRow = 0;
                            }
                            else
                            {
                                playerRow++;
                            }
                        }
                    }
                    matrix[playerRow, playerCol] = 'f';
                }
                else if (command == "down")
                {
                    matrix[playerRow, playerCol] = '-';
                    if (playerRow + 1 == sizeOfMatrix)
                    {
                        playerRow = 0;
                    }
                    else
                    {
                        playerRow++;
                    }

                    if (matrix[playerRow, playerCol] == 'T')
                    {
                        if (playerRow == sizeOfMatrix)
                        {
                            playerRow = 0;
                        }
                        else
                        {
                            playerRow--;
                        }
                        matrix[playerRow, playerCol] = 'f';
                        continue;
                    }
                    else if (matrix[playerRow, playerCol] == 'F')
                    {
                        playerWon = true;
                        matrix[playerRow, playerCol] = 'f';
                        break;
                    }
                    else if (matrix[playerRow, playerCol] == 'B')
                    {
                        matrix[playerRow, playerCol] = 'B';
                        playerRow++;
                        if (playerRow == sizeOfMatrix)
                        {
                            playerRow = 0;
                        }
                        else
                        {
                            playerRow++;
                        }

                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            playerWon = true;
                            matrix[playerRow, playerCol] = 'f';
                            break;
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            if (playerRow == 0)
                            {
                                playerRow = sizeOfMatrix - 1;
                            }
                            else
                            {
                                playerRow--;
                            }
                        }
                    }
                    matrix[playerRow, playerCol] = 'f';
                }
                else if (command == "left")
                {
                    matrix[playerRow, playerCol] = '-';
                    if (playerCol - 1 < 0)
                    {
                        playerCol = sizeOfMatrix - 1;
                    }
                    else
                    {
                        playerCol--;
                    }

                    if (matrix[playerRow, playerCol] == 'T')
                    {
                        if (playerCol == sizeOfMatrix - 1)
                        {
                            playerCol = 0;
                        }
                        else
                        {
                            playerCol++;
                        }
                        matrix[playerRow, playerCol] = 'f';
                        continue;
                    }
                    else if (matrix[playerRow, playerCol] == 'F')
                    {
                        playerWon = true;
                        matrix[playerRow, playerCol] = 'f';
                        break;
                    }
                    else if (matrix[playerRow, playerCol] == 'B')
                    {
                        matrix[playerRow, playerCol] = 'B';
                        playerCol--;
                        if (playerCol - 1 < 0)
                        {
                            playerCol = sizeOfMatrix - 1;
                        }
                        else
                        {
                            playerCol--;
                        }

                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            playerWon = true;
                            matrix[playerRow, playerCol] = 'f';
                            break;
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            if (playerCol == sizeOfMatrix - 1)
                            {
                                playerCol = 0;
                            }
                            else
                            {
                                playerCol++;
                            }
                        }
                    }
                    matrix[playerRow, playerCol] = 'f';
                }
                else if (command == "right")
                {
                    matrix[playerRow, playerCol] = '-';
                    if (playerCol + 1 == sizeOfMatrix)
                    {
                        playerCol = 0;
                    }
                    else
                    {
                        playerCol++;
                    }

                    if (matrix[playerRow, playerCol] == 'T')
                    {
                        if (playerCol == sizeOfMatrix)
                        {
                            playerCol = 0;
                        }
                        else
                        {
                            playerCol--;
                        }
                        matrix[playerRow, playerCol] = 'f';
                        continue;
                    }
                    else if (matrix[playerRow, playerCol] == 'F')
                    {
                        playerWon = true;
                        matrix[playerRow, playerCol] = 'f';
                        break;
                    }
                    else if (matrix[playerRow, playerCol] == 'B')
                    {
                        matrix[playerRow, playerCol] = 'B';
                        playerCol++;
                        if (playerCol == sizeOfMatrix)
                        {
                            playerCol = 0;
                        }
                        else
                        {
                            playerCol++;
                        }

                        if (matrix[playerRow, playerCol] == 'F')
                        {
                            playerWon = true;
                            matrix[playerRow, playerCol] = 'f';
                            break;
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            if (playerCol == 0)
                            {
                                playerCol = sizeOfMatrix - 1;
                            }
                            else
                            {
                                playerCol--;
                            }
                        }
                    }
                    matrix[playerRow, playerCol] = 'f';
                }
            }

            if (playerWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
