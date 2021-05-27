using System;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@#+[A-Z][a-zA-Z0-9]{4,}[A-Z]@#+";
            Regex barcodeValidator = new Regex(pattern);
            string numbersPattern = @"\d";
            Regex numbers = new Regex(numbersPattern);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();
                Match validOrNot = barcodeValidator.Match(barcode);
                if (validOrNot.Success)
                {
                    MatchCollection num = numbers.Matches(barcode);
                    if (num.Count > 0)
                    {
                        string productGroup = "";

                        foreach (Match item in num)
                        {
                            productGroup += item;
                        }
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                    else
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    
                   
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
