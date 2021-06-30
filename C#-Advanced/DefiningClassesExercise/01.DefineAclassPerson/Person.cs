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

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
