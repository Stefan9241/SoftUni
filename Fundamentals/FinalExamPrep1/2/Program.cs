using System;
using System.Text.RegularExpressions;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@[#]+[A-Z][a-zA-Z0-9]{4,}[A-Z]@[#]+";
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string barcode = Console.ReadLine();
                var validator = Regex.Match(barcode, pattern);
                string digits = "";
                if (validator.Success)
                {
                    for (int ji = 0; ji < validator.Value.Length; ji++)
                    {
                        if (char.IsDigit(validator.Value[ji]))
                        {
                            digits += validator.Value[ji];
                        }
                    }

                    if (digits == "")
                    {
                        digits = "00";
                    }
                    Console.WriteLine($"Product group: {digits}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
