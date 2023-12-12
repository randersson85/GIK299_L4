using System.Reflection;
using System;

namespace GIK299_L3
{
    public class Program
    {
        static void Main(string[] args)
        {
            string name = "Alex";
            Gender gender = Gender.ickeBinär;
            string eyeColor = "Blå";
            Hair hair = new Hair { Haircolor = "Blond", HairLength = "Kort" };
            DateTime birthdate = new DateTime(2009, 2, 25);
            Person person = new Person(name, gender, eyeColor, hair, birthdate);

            Console.WriteLine(person.ToString());
            Console.WriteLine();
        }
    }
}