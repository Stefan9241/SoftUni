using System;
using System.Collections.Generic;

namespace _2
{
    class Program
    {
        public static bool IsIndexValid(char[][] jaggedArray, int row, int col)
        {
            return row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length;
        }
        public static void Print(char[][] jaggedArray, string separator)
        {
            foreach (char[] col in jaggedArray)
            {
                Console.WriteLine(string.Join(separator, col));
            }
        }
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());
            var matrix = new char[sizeMatrix][];

            var list = new List<char>();
            list.Add('0');
            list.Add('1');
            list.Add('2');
            list.Add('3');
            list.Add('4');
            list.Add('5');
            list.Add('6');
            list.Add('7');
            list.Add('8');
            list.Add('9');

            bool counterM = false;

            var firstMirrorRow = -10;
            var firstMirrorCol = -10;

            var secondMirrorRow = -10;
            var secondMirrorCol = -10;

            var armyRow = -10;
            var armyCol = -10;
            for (int i = 0; i < sizeMatrix; i++)
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
                    else if (matrix[i][j] == 'M' && counterM == false)
                    {
                        counterM = true;
                        firstMirrorRow = i;
                        firstMirrorCol = j;
                    }
                    else if (matrix[i][j] == 'M' && counterM == true)
                    {
                        secondMirrorRow = i;
                        secondMirrorCol = j;
                    }
                }
            }

            var sum = 0;
            var command = Console.ReadLine();

            while (true)
            {
                if (command == "up")
                {
                    matrix[armyRow][armyCol] = '-';
                    if (IsIndexValid(matrix, armyRow - 1, armyCol) == false)
                    {
                        Console.WriteLine("I do not need more swords!");
                        Console.WriteLine($"The king paid {sum} gold coins.");
                        Print(matrix, "");
                        break;
                    }

                    armyRow--;
                }
                else if (command == "down")
                {
                    matrix[armyRow][armyCol] = '-';
                    if (IsIndexValid(matrix, armyRow + 1, armyCol) == false)
                    {
                        Console.WriteLine("I do not need more swords!");
                        Console.WriteLine($"The king paid {sum} gold coins.");
                        Print(matrix, "");
                        break;
                    }

                    armyRow++;
                }
                else if (command == "left")
                {
                    matrix[armyRow][armyCol] = '-';
                    if (IsIndexValid(matrix, armyRow, armyCol - 1) == false)
                    {
                        Console.WriteLine("I do not need more swords!");
                        Console.WriteLine($"The king paid {sum} gold coins.");
                        Print(matrix, "");
                        break;
                    }

                    armyCol--;
                }
                else if (command == "right")
                {
                    matrix[armyRow][armyCol] = '-';
                    if (IsIndexValid(matrix, armyRow, armyCol + 1) == false)
                    {
                        Console.WriteLine("I do not need more swords!");
                        Console.WriteLine($"The king paid {sum} gold coins.");
                        Print(matrix, "");
                        break;
                    }

                    armyCol++;
                }



                if (list.Contains(matrix[armyRow][armyCol]))
                {
                    var number = int.Parse(matrix[armyRow][armyCol].ToString());
                    sum += number;

                    matrix[armyRow][armyCol] = 'A';
                }

                if (firstMirrorRow >= 0)
                {
                    if (matrix[armyRow][armyCol].Equals(matrix[firstMirrorRow][firstMirrorCol]))
                    {
                        matrix[firstMirrorRow][firstMirrorCol] = '-';

                        armyRow = secondMirrorRow;
                        armyCol = secondMirrorCol;

                        matrix[armyRow][armyCol] = 'A';
                    }
                    else if (matrix[armyRow][armyCol].Equals(matrix[secondMirrorRow][secondMirrorCol]))
                    {
                        matrix[secondMirrorRow][secondMirrorCol] = '-';

                        armyRow = firstMirrorRow;
                        armyCol = firstMirrorCol;

                        matrix[armyRow][armyCol] = 'A';
                    }
                }
                else
                {
                    matrix[armyRow][armyCol] = 'A';
                }


                if (sum >= 65)
                {
                    Console.WriteLine("Very nice swords, I will come back for more!");
                    Console.WriteLine($"The king paid {sum} gold coins.");
                    Print(matrix, "");
                    break;
                }

                command = Console.ReadLine();
            }


        }
    }
}
