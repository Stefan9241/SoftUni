using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] cmds = Console.ReadLine().Split();
                string name = cmds[0];
                int age = int.Parse(cmds[1]);

                Person currPerson = new Person(name, age);
                people.Add(currPerson);
            }

            people = people.Where(x => x.Age > 30).ToList();
            foreach (var person in people.OrderBy(x => x.Name))
            {
                Console.WriteLine(person);
            }
        }
    }
}
