using System;

namespace _01.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new char[8, 8];
            var whiteRow = 0;
            var whiteCol = 0;

            var blackRow = 0;
            var blackCol = 0;

            for (int r = 0; r < 8; r++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int c = 0; c < 8; c++)
                {
                    matrix[r, c] = input[c];
                    if (matrix[r, c] == 'b')
                    {
                        blackRow = r;
                        blackCol = c;
                    }
                    else if (matrix[r, c] == 'w')
                    {
                        whiteRow = r;
                        whiteCol = c;
                    }
                }
            }

            var chessMatrix = new char[8,8];
            bool whiteMoved = false;
            while (true)
            {
                if (whiteRow - 1 >= 0 && whiteCol - 1 >= 0)
                {
                    if (matrix[whiteRow - 1, whiteCol - 1] == 'b')
                    {
                        matrix[whiteRow, whiteCol] = '-';
                        matrix[whiteRow - 1, whiteCol - 1] = 'w';
                        whiteRow = blackRow;
                        whiteCol = blackCol;
                        char toPrint = whiteCol == 0 ? 'a' : whiteCol == 1 ? 'b' : whiteCol == 2 ? 'c' : whiteCol == 3 ? 'd' : whiteCol == 4 ? 'e' :
                            whiteCol == 5 ? 'f' : whiteCol == 6 ? 'g' : whiteCol == 7 ? 'h' : default;
                        int intToPrint = whiteRow == 0 ? 8 : whiteRow == 1 ? 7 : whiteRow == 2 ? 6 : whiteRow == 3 ? 5 : whiteRow == 4 ? 4 :
                            whiteRow == 5 ? 3 : whiteRow == 6 ? 2 : whiteRow == 7 ? 1 : default;
                        Console.WriteLine($"Game over! White capture on {toPrint}{intToPrint}.");
                        break;
                    }
                }

                if (whiteRow - 1 >= 0 && whiteCol + 1 < 8)
                {
                    if (matrix[whiteRow-1 , whiteCol + 1] == 'b')
                    {
                        matrix[whiteRow, whiteCol] = '-';
                        matrix[whiteRow - 1, whiteCol + 1] = 'w';
                        whiteRow = blackRow;
                        whiteCol = blackCol;
                        char toPrint = whiteCol == 0 ? 'a' : whiteCol == 1 ? 'b' : whiteCol == 2 ? 'c' : whiteCol == 3 ? 'd' : whiteCol == 4 ? 'e' :
                            whiteCol == 5 ? 'f' : whiteCol == 6 ? 'g' : whiteCol == 7 ? 'h' : default;
                        int intToPrint = whiteRow == 0 ? 8 : whiteRow == 1 ? 7 : whiteRow == 2 ? 6 : whiteRow == 3 ? 5 : whiteRow == 4 ? 4 :
                           whiteRow == 5 ? 3 : whiteRow == 6 ? 2 : whiteRow == 7 ? 1 : default;
                        Console.WriteLine($"Game over! Black capture on {toPrint}{intToPrint}.");
                        break;
                    }
                }
                if (whiteMoved == false)
                {
                    matrix[whiteRow, whiteCol] = '-';
                    whiteRow--;
                    matrix[whiteRow, whiteCol] = 'w';
                    if (whiteRow == 0)
                    {
                        char toPrint = whiteCol == 0 ? 'a' : whiteCol == 1 ? 'b' : whiteCol == 2 ? 'c' : whiteCol == 3 ? 'd' : whiteCol == 4 ? 'e' :
                            whiteCol == 5 ? 'f' : whiteCol == 6 ? 'g' : whiteCol == 7 ? 'h' : default;
                        int intToPrint = whiteRow == 0 ? 8 : whiteRow == 1 ? 7 : whiteRow == 2 ? 6 : whiteRow == 3 ? 5 : whiteRow == 4 ? 4 :
                           whiteRow == 5 ? 3 : whiteRow == 6 ? 2 : whiteRow == 7 ? 1 : default;
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {toPrint}{intToPrint}.");
                        break;
                    }
                }

                if (blackRow + 1 < 8 && blackCol - 1 >= 0)
                {
                    if (matrix[blackRow + 1, blackCol - 1] == 'w')
                    {
                        matrix[blackRow, blackCol] = '-';
                        matrix[blackRow + 1, blackCol - 1] = 'b';
                        blackRow = whiteRow;
                        blackCol = whiteCol;
                        char toPrint = blackCol == 0 ? 'a' : blackCol == 1 ? 'b' : blackCol == 2 ? 'c' : blackCol == 3 ? 'd' : blackCol == 4 ? 'e' :
                            blackCol == 5 ? 'f' : blackCol == 6 ? 'g' : blackCol == 7 ? 'h' : default;
                        int intToPrint = blackRow == 0 ? 8 : blackRow == 1 ? 7 : blackRow == 2 ? 6 : blackRow == 3 ? 5 : blackRow == 4 ? 4 :
                            blackRow == 5 ? 3 : blackRow == 6 ? 2 : blackRow == 7 ? 1 : default;
                        Console.WriteLine($"Game over! Black capture on {toPrint}{blackRow}.");
                        break;
                    }
                }
                else if (blackRow + 1 < 8 && blackCol + 1 < 8)
                {
                    if (matrix[blackRow + 1, blackCol + 1] == 'w')
                    {
                        matrix[blackRow, blackCol] = '-';
                        matrix[blackRow + 1, blackCol + 1] = 'b';
                        blackRow = whiteRow;
                        blackCol = whiteCol;
                        char toPrint = blackCol == 0 ? 'a' : blackCol == 1 ? 'b' : blackCol == 2 ? 'c' : blackCol == 3 ? 'd' : blackCol == 4 ? 'e' :
                             blackCol == 5 ? 'f' : blackCol == 6 ? 'g' : blackCol == 7 ? 'h' : default;
                        int intToPrint = blackRow == 0 ? 8 : blackRow == 1 ? 7 : blackRow == 2 ? 6 : blackRow == 3 ? 5 : blackRow == 4 ? 4 :
                            blackRow == 5 ? 3 : blackRow == 6 ? 2 : blackRow == 7 ? 1 : default;
                        Console.WriteLine($"Game over! Black capture on {toPrint}{intToPrint}.");
                        break;
                    }
                }
                if (whiteMoved == false)
                {
                    matrix[blackRow, blackCol] = '-';
                    blackRow++;
                    matrix[blackRow, blackCol] = 'b';
                    if (blackRow == 7)
                    {
                        char toPrint = blackCol == 0 ? 'a' : blackCol == 1 ? 'b' : blackCol == 2 ? 'c' : blackCol == 3 ? 'd' : blackCol == 4 ? 'e' :
                             blackCol == 5 ? 'f' : blackCol == 6 ? 'g' : blackCol == 7 ? 'h' : default;
                        int intToPrint = blackRow == 0 ? 8 : blackRow == 1 ? 7 : blackRow == 2 ? 6 : blackRow == 3 ? 5 : blackRow == 4 ? 4 :
                            blackRow == 5 ? 3 : blackRow == 6 ? 2 : blackRow == 7 ? 1 : default;
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {toPrint}{intToPrint}");
                        break;
                    }
                }
            }
        }
    }
}
