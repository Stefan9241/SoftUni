using System;

namespace Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            string whatCategory = "";
            if (age >=0 && age <= 2)
            {
                whatCategory = "baby";
            }
            else if (age >= 3 && age <= 13)
            {
                whatCategory = "child";
            }
            else if (age >= 14 && age <= 19)
            {
                whatCategory = "teenager";
            }
            else if (age >= 20 && age <= 65)
            {
                whatCategory = "adult";
            }
            else
            {
                whatCategory = "elder";
            }
            Console.WriteLine(whatCategory);
        }
    }
}
