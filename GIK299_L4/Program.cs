using System.Reflection;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;


namespace GIK299_L4
{
    class Program
    {
        public static List<Person> people = new List<Person>();

        public class AddPerson
        {
            public AddPerson(Person person)
            {
                people.Add(person);
            }
        }

        static class ListPersons
        {
            internal static string Result { get; private set; }

            internal static string GetPerson()
            {
                string result = null;
                foreach (var person in people)
                {
                    Result += $"Namn:\t \t {person.Name}\n" +
                              $"Kön:\t \t {person.Gender}\n" +
                              $"Ögonfärg:\t {person.EyeColor}\n" +
                              $"Hår:\t \t {person.Hair.Haircolor},{person.Hair.HairLength}\n" +
                              $"Födelsedatum:\t {person.BirthDate}\n\n";
                }
                return result;
            }
        }

        static void Main(string[] args)
        {
            AddPerson addPerson = null;

            try
            {
                int menuSelector = 0; //Variabel för att menyval i huvudmenyn.
                int lastMenuOption = 3; //Variable för antalet val det finns i huvudmenyn.
                bool loopMenu = true; //Variabel som bestämmer om huvudmenyn ska loopas. Menyn körs tills variabeln sätts till false.


                while (loopMenu) //en whileloop där variabeln loopMenu är villkoret som avgör om loopen ska fortsätta eller ej
                {
                    Console.WriteLine(
                        "------------------------------------------------" +
                        "\nVälj ett av alternativen: " +
                        "\n1.) Registrera uppgifter om ny person" +
                        "\n2.) Lista redan registrerade personer" +
                        "\n3.) Avsluta programmet" +
                        "\n------------------------------------------------"
                        );


                    Console.Write("> ");



                    bool parseSuccess = int.TryParse(Console.ReadLine(), out menuSelector);
                    //("How the int.TryParse actually works," 2013)
                    // Kontrollerar om det går att parsea strängen, att selectorn inte är 0, innehåller negativa tal
                    // Eller är större än antalet val på menyn.
                    if (parseSuccess == false || menuSelector == 0 || menuSelector < 0 || menuSelector > lastMenuOption)
                    {
                        Console.WriteLine($"Menyvalet måste vara ett heltal mellan 1 och {lastMenuOption}");
                    }


                    switch (menuSelector) //Stora switchen för Huvudmenyn
                    {
                        case 1: //Case 1 som skapar upp personobjekt.
                            {

                                string name = null;
                                Gender gender = Gender.okänt;
                                string eyeColor = null; ;
                                string birthdate = null;
                                string tempHairLength = null;
                                string tempHairColor = null;
                                int genderChoice = 0;


                                try // Försöksblocket för personnamn.
                                {
                                    bool loop = true; //Loopvariabel för personnamn
                                    while (loop)
                                    {
                                        Console.WriteLine("Ange namn på aktuell person. \nOm namn saknas ange löpnummer från övervakningssystem");
                                        Console.Write(">");
                                        name = Console.ReadLine();

                                        //Kontrollerar inmatad sträng för att utesluta att strängen är tom.
                                        if (string.IsNullOrWhiteSpace(name))
                                        {
                                            Console.WriteLine("Inget namn angivet, vänligen ange ett korrekt namn. ");
                                        }
                                        else
                                        {
                                            loop = false;
                                        }

                                    }
                                }

                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error: {ex.Message}");
                                }


                                try //Tryblock för val av kön.
                                {   //("Total number of items defined in an enum," 2009)
                                    // Skapar en array med alla kön angivna i enum Gender, vi tar längden på denna array för att veta hur många val
                                    // som ska finnas i menyn där man väljer kön.

                                    int genderlength = Enum.GetValues(typeof(Gender)).Length;
                                    bool loop = true;
                                    while (loop)
                                    {


                                        Console.WriteLine("Välj könstillhörighet\n");
                                        Console.WriteLine(
                                            "1. Kvinna \n" +
                                            "2. Man\n" +
                                            "3. Icke Binär\n" +
                                            "4. Annat\n" +
                                            "5. Okänt"
                                        );

                                        bool genderParseSuccess;
                                        genderParseSuccess = int.TryParse(Console.ReadLine(), out genderChoice);

                                        if (genderParseSuccess == false || genderChoice == 0 || genderChoice < 0 || genderChoice > 5)
                                        {
                                            Console.WriteLine($"Felaktigt menyval ange ett heltal mellan 1 och {genderlength}");
                                        }
                                        else
                                        {
                                            loop = false;
                                        }
                                    }



                                    switch (genderChoice) // Switch för val av kön.
                                    {
                                        case 1:
                                            gender = Gender.kvinna;
                                            break;

                                        case 2:
                                            gender = Gender.man;
                                            break;

                                        case 3:
                                            gender = Gender.ickeBinar;
                                            break;

                                        case 4:
                                            gender = Gender.annat;
                                            break;

                                        case 5:
                                            gender = Gender.okänt;
                                            break;

                                        default:
                                            Console.WriteLine("Ogiltigt val");
                                            return;
                                    }
                                    //Hade varit fint med en metod som gjorde initialen stor.
                                    Console.WriteLine($"Du har valt kön: {gender}");

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);

                                }
                                //Kontrollerar inmatningen av ögonfärg, om inget värde anges värdet till okänt.
                                try
                                {
                                    Console.Write("Ange ögonfärg (Om okänt tryck endast enter):");
                                    string tempEyeColor = Console.ReadLine();

                                    if (string.IsNullOrWhiteSpace(tempEyeColor))
                                    {
                                        eyeColor = "Okänt";
                                    }
                                    else
                                    {
                                        eyeColor = tempEyeColor;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Ett oväntat fel uppstod");
                                }

                                try
                                {
                                    Console.Write("Ange hårlängd (Om okänt eller inget hår tryck enter) ");
                                    tempHairLength = Console.ReadLine();

                                    if (string.IsNullOrWhiteSpace(tempHairLength))
                                    {
                                        tempHairLength = "Okänt/Ej Hår";
                                    }


                                    Console.Write("Ange hårfärg (Om okänt eller inget hår tryck enter) ");
                                    tempHairColor = Console.ReadLine();
                                    if (string.IsNullOrWhiteSpace(tempHairColor))
                                    {
                                        tempHairColor = "Okänt / Ej Hår";
                                    }

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Ett oväntat fel uppstod");
                                }

                                try
                                {
                                    Console.Write("Ange födelsedatum (Om ej känt tryck enter): ");
                                    string tempBirtdate = Console.ReadLine();
                                    if (string.IsNullOrWhiteSpace(tempBirtdate))
                                    {
                                        birthdate = "Okänt";
                                    }
                                    else
                                    {
                                        birthdate = tempBirtdate;
                                    }
                                }
                                catch (Exception)
                                {

                                    throw;
                                }

                                //Lagt initieringen av struct för hår utanför alla try catch för att den inte ville gå vidare till constructorn

                                Hair hair = new Hair { HairLength = tempHairLength, Haircolor = tempHairColor };

                                Person person = new Person(name, gender, eyeColor, hair, birthdate);

                                if (addPerson == null)
                                {
                                    addPerson = new AddPerson(person);
                                }
                                else
                                {
                                    addPerson = new AddPerson(person);

                                }



                                break;
                            }

                        case 2: //Menyval 2, lista inmata personer.
                            {
                                if (people.Count == 0)
                                {
                                    Console.WriteLine("Listan över personer är tom, börja med att lägga till personer först.");
                                }
                                else
                                {
                                    // Hämta resultatet och skriv ut det
                                    string result = ListPersons.GetPerson();
                                    Console.WriteLine(result);
                                }

                                break;
                            }


                        case 3: //Menyval 3, Avsluta programmet.
                            {
                                loopMenu = false;
                                Console.WriteLine("Avslutar programmet");

                            }
                            break;
                    }
                }
            }

            catch (Exception ex)//Catch för huvudmenyn
            {
                Console.WriteLine(ex.Message);


            }

        }
    }

    /* Referenser:
     * https://stackoverflow.com/questions/15294878/how-the-int-tryparse-actually-works */
    // https://stackoverflow.com/questions/856154/total-number-of-items-defined-in-an-enum
}