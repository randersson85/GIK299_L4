using GIK299_L4;
using System.Collections.Generic;

namespace gik299_l4
{
    public class AddPerson
    {
        private List<Person> people = new List<Person>();

        public List<Person> Persons
        {
            get { return people; }
        }

        public void AddPersonToList(Person person)
        {
            people.Add(person);
        }

        public override string ToString()
        {
            string result = "";

            foreach (var person in people)
            {
                result += $"Namn:\t \t {person.Name}\n" +
                          $"Kön:\t \t {person.Gender}\n" +
                          $"Ögonfärg:\t {person.EyeColor}\n" +
                          $"Hår:\t \t {person.Hair.Haircolor},{person.Hair.HairLength}\n" +
                          $"Födelsedatum:\t {person.BirthDate}\n\n";
            }

            return result;
        }
    }
}
