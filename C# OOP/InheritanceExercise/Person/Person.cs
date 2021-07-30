using System;

namespace Person
{
    public class Person
    {
        private int age;
        public string Name { get; set; }

        public Person(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }
        public virtual int Age
        { 
            get 
            { 
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be less than zero");
                }
                this.age = value;
            }
        }
        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
