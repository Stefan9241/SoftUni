using System;

namespace Изготвяне_на_Проект
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int  projectCount = int.Parse(Console.ReadLine());

            Console.WriteLine($"The architect {name} will need {projectCount * 3 } hours to complete {projectCount} project/s. ");



        }
    }
}
