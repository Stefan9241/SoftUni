using System;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            double Age = double.Parse(Console.ReadLine());
            string Gender = Console.ReadLine();

            if(Gender == "f")
            {
                if (Age >= 16)
                {
                    Console.WriteLine("Ms.");
                }
                else if ( Age < 16)
                {
                    Console.WriteLine("Miss");
                }
                    
            }
            else if (Gender == "m")
            {
                if (Age <16)
                {
                    Console.WriteLine("Master");
                }
                else
                {
                    Console.WriteLine("Mr.");
                }
            }
            
        }
    }
}
