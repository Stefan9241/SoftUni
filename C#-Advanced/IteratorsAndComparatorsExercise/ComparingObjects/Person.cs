using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        private string name;
        private string town;
        private int age;

        public Person(string name,int age,string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }
        public string Name => name;
        public string Town => town;
        public int Age => age;
        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = Age.CompareTo(other.Age);
            }

            if (result == 0)
            {
                result = Town.CompareTo(other.Town);
            }
            return result;
        }
    }
}
