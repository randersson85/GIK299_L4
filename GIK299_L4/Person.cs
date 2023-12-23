using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GIK299_L4
{
    public class Person
    {
        public string Name { get; private set; }
        public Gender Gender { get; private set; }
        public Hair Hair { get; private set; }
        public string EyeColor { get; private set; }
        public string BirthDate { get; private set; }

        public Person(string name, Gender gender, string eyeColor, Hair hair, string birthDate)
        {
            Name = name;
            Gender = gender;
            EyeColor = eyeColor;
            Hair = hair;
            BirthDate = birthDate;
        }

        public class AddPerson
        {
            public static List<Person> people = new List<Person>();
            public AddPerson(Person person)
            {
                people.Add(person);
            }
        }

        public class ListPersons
        {
            public string Result { get; private set; }

            public ListPersons()
            {
                Result = null;
                foreach (var person in AddPerson.people)
                {
                    Result += $"Namn:\t \t {person.Name}\n" +
                              $"Kön:\t \t {person.Gender}\n" +
                              $"Ögonfärg:\t {person.EyeColor}\n" +
                              $"Hår:\t \t {person.Hair.Haircolor},{person.Hair.HairLength}\n" +
                              $"Födelsedatum:\t {person.BirthDate}\n\n";
                }
            }
        }

    }
}