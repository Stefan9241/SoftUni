using System;

namespace TheBattleOfTheFiveArmies
{
    class Program
    {
        static void Main(string[] args)
        {
            int eArmor = int.Parse(Console.ReadLine());
            int numRows = int.Parse(Console.ReadLine());

            char[][] matrix = new char[numRows][];
            int armyRow = 0;
            int armyCol = 0;

            bool isWin = false;

            for (int i = 0; i < numRows; i++)
            {
                string chars = Console.ReadLine();
                matrix[i] = new char[chars.Length];
                for (int j = 0; j < chars.Length; j++)
                {
                    matrix[i][j] = chars[j];
                    if (matrix[i][j] == 'A')
                    {
                        armyRow = i;
                        armyCol = j;
                    }
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                matrix[int.Parse(command[1])][int.Parse(command[2])] = 'O';
                if (command[0] == "up")
                {
                    if (armyRow - 1 < 0)//doesnt move
                    {
                        eArmor--;
                        if (eArmor <= 0)
                        {
                            matrix[armyRow][armyCol] = 'X';
                            break;
                        }
                        else
                        {
                            continue;
                        }

                    }
                    else if (matrix[armyRow - 1][armyCol] == 'O')//enemy
                    {
                        eArmor -= 3;
                        matrix[armyRow][armyCol] = '-';
                        matrix[armyRow - 1][armyCol] = 'A';
                    }
                    else if (matrix[armyRow - 1][armyCol] == 'M')//win
                    {
                        matrix[armyRow - 1][armyCol] = '-';
                        matrix[armyRow][armyCol] = '-';
                        isWin = true;
                        eArmor--;
                        break;
                    }
                    else//just move
                    {
                        eArmor--;
                        matrix[armyRow][armyCol] = '-';
                        matrix[armyRow - 1][armyCol] = 'A';
                    }

                    if (eArmor <= 0)//if we die
                    {
                        matrix[armyRow - 1][armyCol] = 'X';
                        matrix[armyRow][armyCol] = '-';
                        armyRow--;
                        break;
                    }

                    armyRow--;
                }
                else if (command[0] == "down")
                {
                    if (armyRow + 1 == numRows)//doesnt move
                    {
                        eArmor -= 1;
                        if (eArmor <= 0)
                        {
                            matrix[armyRow][armyCol] = 'X';
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (matrix[armyRow + 1][armyCol] == 'O')//enemy
                    {
                        eArmor -= 3;
                        matrix[armyRow][armyCol] = '-';
                        matrix[armyRow + 1][armyCol] = 'A';
                    }
                    else if (matrix[armyRow + 1][armyCol] == 'M')//win
                    {
                        matrix[armyRow + 1][armyCol] = '-';
                        matrix[armyRow][armyCol] = '-';
                        isWin = true;
                        eArmor--;
                        break;
                    }
                    else//just move
                    {
                        eArmor--;
                        matrix[armyRow][armyCol] = '-';
                        matrix[armyRow + 1][armyCol] = 'A';
                    }

                    if (eArmor <= 0)//if we die
                    {
                        matrix[armyRow + 1][armyCol] = 'X';
                        matrix[armyRow][armyCol] = '-';
                        armyRow++;
                        break;
                    }

                    armyRow++;
                }
                else if (command[0] == "left")
                {
                    if (armyCol - 1 < 0)//doesnt move
                    {
                        eArmor -= 1;
                        if (eArmor <= 0)
                        {
                            matrix[armyRow][armyCol] = 'X';
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (matrix[armyRow][armyCol - 1] == 'O')//enemy
                    {
                        eArmor -= 3;
                        matrix[armyRow][armyCol] = '-';
                        matrix[armyRow][armyCol - 1] = 'A';
                    }
                    else if (matrix[armyRow][armyCol - 1] == 'M')//win
                    {
                        matrix[armyRow][armyCol - 1] = '-';
                        matrix[armyRow][armyCol] = '-';
                        isWin = true;
                        eArmor--;
                        break;
                    }
                    else//just move
                    {
                        eArmor--;
                        matrix[armyRow][armyCol] = '-';
                        matrix[armyRow][armyCol - 1] = 'A';
                    }

                    if (eArmor <= 0)//if we die
                    {
                        matrix[armyRow][armyCol - 1] = 'X';
                        matrix[armyRow][armyCol] = '-';
                        armyCol--;
                        break;
                    }

                    armyCol--;
                }
                else if (command[0] == "right")
                {
                    if (armyCol + 1 == matrix[armyRow].Length)//doesnt move
                    {
                        eArmor -= 1;
                        if (eArmor <= 0)
                        {
                            matrix[armyRow][armyCol] = 'X';
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (matrix[armyRow][armyCol + 1] == 'O')//enemy
                    {
                        eArmor -= 3;
                        matrix[armyRow][armyCol] = '-';
                        matrix[armyRow][armyCol + 1] = 'A';
                    }
                    else if (matrix[armyRow][armyCol + 1] == 'M')//win
                    {
                        matrix[armyRow][armyCol + 1] = '-';
                        matrix[armyRow][armyCol] = '-';
                        isWin = true;
                        eArmor--;
                        break;
                    }
                    else//just move
                    {
                        eArmor--;
                        matrix[armyRow][armyCol] = '-';
                        matrix[armyRow][armyCol + 1] = 'A';
                    }

                    if (eArmor <= 0)//if we die
                    {
                        matrix[armyRow][armyCol + 1] = 'X';
                        matrix[armyRow][armyCol] = '-';
                        armyCol++;
                        break;
                    }

                    armyCol++;
                }
            }

            if (isWin)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {eArmor}");
            }
            else
            {
                Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("",row));
            }
        }
    }
}
