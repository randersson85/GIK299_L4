////using System.Xml.Linq;
////using Person;


//int menuSelector = 0;
//int menuSize = 3;

//while (menuSelector != menuSize) //en whileloop där variabeln menuSelector är villkoret som avgör om loopen ska fortsätta eller ej
//{
//    Console.WriteLine(
//        "------------------------------------------------" +
//        "\nVälj ett av alternativen: " +
//        "\n1.) Registrera uppgifter om ny person" +
//        "\n2.) Lista redan registrerade personer" +
//        "\n3.) Avsluta programmet" +
//        "\n------------------------------------------------"
//        );

//    try
//    {
//        string menuInput = Console.ReadLine();

//        if (!int.TryParse(menuInput, out menuSelector))
//        {
//            throw new FormatException($"Felaktigt menyval ange ett heltal mellan 1 och {menuSize} ");
//        }

//        menuSelector = int.Parse(Console.ReadLine());

//        if (menuSelector == 0 || menuSelector < 0 || menuSelector < menuSize)
//        {
//            throw new FormatException($"Felaktigt menyval ange ett heltal mellan 1 och {menuSize} ");
//        }
//    }

//    catch (FormatException ex)
//    {
//        Console.WriteLine(ex.Message);
//        Console.WriteLine("FormatException av någon anledning");
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine("Ett oväntat fel uppstod." + ex.ToString());
//    }

//    switch (menuSelector)
//    {
//        case 1:


//            break;
//    }
//}