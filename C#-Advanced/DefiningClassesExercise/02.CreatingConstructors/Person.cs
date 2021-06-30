namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;
        
        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }
        public int Age
        {
            set
            {
                age = value;
            }
            get
            {
                return age;
            }
        }

        public Person()
        {
            Name = "No name";
            Age = 1;
        }
        public Person(int age):this()
        {
            Age = age;
        }
        public Person(string name, int age):this(age)
        {
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
