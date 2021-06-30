using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> People { get; set; }
        public Family()
        {
            People = new List<Person>();
        }

        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
        {
            Person person = People.OrderByDescending(x => x.Age).FirstOrDefault();
            return person;
        }

    }
}
