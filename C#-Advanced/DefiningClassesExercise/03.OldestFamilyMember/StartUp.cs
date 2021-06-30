using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string name = cmdArgs[0];
                int age = int.Parse(cmdArgs[1]);
                Person currPerson = new Person(name, age);
                family.AddMember(currPerson);
            }

            Console.WriteLine(family.GetOldestMember());
        }
    }
}
