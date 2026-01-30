using casus.Mierentuin.Models;
using System.Runtime.CompilerServices;
using casus.Mierentuin.DataAccess;
using System.Linq.Expressions;

namespace casus.Mierentuin
{
    internal class Program
    {
        public static void Main()
        {
            List<Werknemer> werknemersSQL = DALSQL.GetAllWerknemers();
            List<Dier> dierenSQL = DALSQL.GetAllDieren();
            List<Verblijf> verblijfSQL = DALSQL.GetAllVerblijf();
            List<VoerBeurt> voerbeurtSQL = DALSQL.GetAllVoerbeurt();
            List<VoerBeurtWerknemer> voerBeurtWerknemersSQL = DALSQL.GetAllVoerbeurtWerknemer();
            List<SchoonMaakBeurt> schoonMaakBeurtSQL = DALSQL.GetAllSchoonMaakBeurt();
            List<SchoonmaakWerknemer> schoonmaakWerknemerSQL = DALSQL.GetAllSchoonmaakWerknemer();
            
            Testclass.TestSQL();
            
            bool mainloop = true;
            while (mainloop)
            {
                Console.WriteLine("Welkom bij de mierentuin" +
                                  "\n Selecteer uw functie");
                Console.WriteLine("0. Stop het programma\n" +
                                  "1. Dierenverzorger\n" +
                                  "2. Verblijfsvezorger\n" +
                                  "3. Manager Dierenverzorger\n" +
                                  "4. Manager Verblijfsverzorger\n");
                Console.WriteLine("Typ het getal voor uw keuze");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1" :
                        bool dierenverzorgermenu = true;
                        while (dierenverzorgermenu)
                        {
                            Console.WriteLine("U bent ingelogd als dierenverzorger");
                            Console.WriteLine("0. ga terug\n" +
                                              "1. dieren\n" +
                                              "2. verblijven\n");
                            Console.WriteLine("Typ het getal voor u keuze");
                            choice = Console.ReadLine();
                            switch (choice)
                            {
                                case "0" :
                                    dierenverzorgermenu = false;
                                    break;
                                case "1" :
                                    bool diermenu = true;
                                    while (diermenu)
                                    {
                                        Console.WriteLine("0. Ga terug\n" +
                                                          "1. Voeg een nieuw dier toe\n" +
                                                          "2. Maak een notitie voor een dier\n");
                                        Console.WriteLine("Typ het getal voor u keuze");
                                        choice = Console.ReadLine();
                                        switch (choice)
                                        {
                                            case "0":
                                                diermenu = false;
                                                break;
                                            case "1":
                                                //usecase ayman

                                                #region aymanusecase
                                                // Vraag naam van het dier
                                                bool invoercorrect = false;
                                                while (!invoercorrect)
                                                {
                                                        Console.WriteLine("Voer de naam van het dier in:");
                                                        string naam = Console.ReadLine();

                                                        // Vraag type dier
                                                        Console.WriteLine("Voer het type dier in:");
                                                        string typedier = Console.ReadLine();

                                                        // Vraag notitie inclusief verblijf
                                                        Console.WriteLine(
                                                            "Voer een notitie in.");
                                                        string notitie = Console.ReadLine();

                                                        if (naam.Length != 0 && typedier.Length != 0)
                                                        {
                                                            // Maak nieuw Dier object aan
                                                            Dier nieuwdier = new Dier(naam, notitie, typedier, 1);

                                                            // Voeg dier toe aan database
                                                            DALSQL.Adddata(nieuwdier);

                                                            Console.WriteLine("Het dier is succesvol aangemeld.");
                                                            invoercorrect = true;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("u heeft bij typedier of naam niks ingevuld");
                                                        }
                                                }
                                                #endregion
                                                break;
                                            case "2":
                                                //usecase sam

                                                
                                                bool dierselecteermenu = true;
                                                //selecteer een dier en voeg een notitie 
                                                while (dierselecteermenu)
                                                {
                                                    Console.WriteLine(
                                                        "Selecteer het dier waarbij u een notitie wil maken");
                                                    int keuzegetal = 1;
                                                    foreach (Dier dier in dierenSQL)
                                                    {
                                                        Console.WriteLine($"{keuzegetal}. {dier.Naam} {dier.Typedier} {dier.Notitie}");
                                                        keuzegetal++;
                                                    }

                                                    Console.WriteLine(
                                                        "typ het getal voor het dier wat u wil selecteren");
                                                    //try catch block om format fouten af te vangen
                                                    try
                                                    {
                                                        string invoer = Console.ReadLine();
                                                        int intinvoer = int.Parse(invoer);
                                                        if (intinvoer - 1 <= dierenSQL.Count && intinvoer - 1 >= 0)
                                                        {
                                                            Console.WriteLine("typ nu uw notitie");
                                                            dierenSQL[intinvoer - 1].Notitie = Console.ReadLine();
                                                            DALSQL.Adddata(dierenSQL[intinvoer - 1]);
                                                            Console.WriteLine("notitie opgeslagen");
                                                            dierselecteermenu = false;
                                                        }
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("invoer past niet binnen de gegeven keuzes");
                                                    }
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("invoer onjuist probeer opnieuw.");
                                                break;
                                        }
                                    }
                                    break;
                                case "2" :
                                    try
                                    {
                                        int getalkeuze = 1;
                                    Console.WriteLine("Welk verblijf wilt u inzien");
                                    foreach (Verblijf verblijf in verblijfSQL)
                                    {
                                        Console.WriteLine($"{getalkeuze}. {verblijf.Naam} ");
                                        getalkeuze++;
                                    }
                                    Console.WriteLine(
                                                        "typ het getal voor het dier wat u wil selecteren");

                                        string invoer = Console.ReadLine();
                                        int intinvoer = int.Parse(invoer);
                                        if (intinvoer - 1 <= verblijfSQL.Count && intinvoer - 1 >= 0)
                                        {

                                            Console.WriteLine($"Naam: {verblijfSQL[intinvoer - 1].Naam}\r\nBeschrijving: {verblijfSQL[intinvoer - 1].Beschrijving}\r\nIs de poort open: {verblijfSQL[intinvoer - 1].PoortOpen}");
                                            Console.WriteLine();
                                            foreach (Dier dier in verblijfSQL[intinvoer - 1].DiereninVerblijf)
                                            {
                                                Console.WriteLine($"{dier.Naam} - {dier.Typedier} - {dier.Notitie}");
                                            }
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("invoer past niet binnen de gegeven keuzes");
                                    }

                                    break;
                                default:
                                    Console.WriteLine("invoer onjuist probeer opnieuw.");
                                    break;
                            }
                        }
                        break;
                    case "2":
                        bool verblijfsverzorgermenu = true;
                        while (verblijfsverzorgermenu)
                        {
                            Console.WriteLine("Niet ontwikkeld voor project");
                            verblijfsverzorgermenu = false;
                        }
                        break;
                    case "3":
                        bool managerverblijfverzorgermenu = true;
                        while (managerverblijfverzorgermenu)
                        {
                            Console.WriteLine("Niet ontwikkeld voor project");
                            managerverblijfverzorgermenu = false;
                        }
                        break;
                    case "4":
                        bool managerdierenverzorgermenu = true;
                        while (managerdierenverzorgermenu)
                        {
                            Console.WriteLine("Niet ontwikkeld voor project");
                            managerdierenverzorgermenu = false;
                        }
                        break;
                    case "0":
                        mainloop = false;
                        break;
                    default:
                        Console.WriteLine("invoer onjuist probeer opnieuw.");
                        break;
                }
            }
        }
    }
}