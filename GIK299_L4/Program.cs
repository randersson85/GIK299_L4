using System.Reflection;
using System;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace GIK299_L4
{
	public class Program
	{
		static void Main(string[] args)
		{
			try
			{

				int menuSelector = 0;
				int lastMenuOption = 3;
				bool loopMenu = true;

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
					bool parseSuccess;

                https://stackoverflow.com/questions/15294878/how-the-int-tryparse-actually-works

                        parseSuccess = int.TryParse(Console.ReadLine(), out menuSelector);

					if (parseSuccess == false) {
						Console.WriteLine($"Menyvalet måste vara ett heltal mellan 1 och {lastMenuOption}");
					}

					if (menuSelector == 0 || menuSelector < 0 || menuSelector > lastMenuOption)
					{
						Console.WriteLine($"Felaktigt menyval ange ett heltal mellan 1 och {lastMenuOption} ");
					}
					else
					{
						
					}

					switch (menuSelector)
					{
						case 1:
							{

								Console.WriteLine("1");

							}
							break;

						case 2:
							{

								Console.WriteLine("2");

							}
							break;

						case 3:
							{
								loopMenu = false;
								Console.WriteLine("Avslutar programmet");
							}
							break;







							string name = null;
							Gender gender = Gender.okänt;
							string eyeColor = null; ;
							string birthdate = null;
							string tempHairLength = null;
							string tempHairColor = null;
							int genderChoice = 0;


							try
							{
								bool loop = true;
								while (loop)
								{
									Console.Write("Ange namn på aktuell person: ");
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


							try
							{
								// https://stackoverflow.com/questions/856154/total-number-of-items-defined-in-an-enum
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

									// Read the user's input
									if (!int.TryParse(Console.ReadLine(), out genderChoice))
									{
										Console.WriteLine($"Felaktigt menyval ange ett heltal mellan 1 och {genderlength}");
									}
									if (genderChoice == 0 || genderChoice < 0 || genderChoice > 5)
									{
										Console.WriteLine($"Felaktigt menyval ange ett heltal mellan 1 och {genderlength}");
									}
									else
									{
										loop = false;
									}
								}

								// Use switch statement based on user's choice

								switch (genderChoice)
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

								Console.WriteLine($"Du har valt kön: {gender}");

							}
							catch (Exception)
							{

								throw;
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


								Console.Write("Ange hårfärg (Tryck om okänt eller inget hår tryck enter) ");
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
									birthdate = "Okänt / Ej känt";
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

							//Lagt initieringen av struct för hår utanför alla try catch för att den inte ville gå vidare till constructorn.
							//Felsöks i mån av tid.

							Hair hair = new Hair { HairLength = tempHairLength, Haircolor = tempHairColor };




							Person person = new Person(name, gender, eyeColor, hair, birthdate);

							Console.WriteLine(person.ToString());
							Console.WriteLine();


					}
				}
			}
			catch (Exception ex)//Catch för huvudmenyn
			{
				Console.WriteLine(ex.Message);
				

			}

		}
	}
}

