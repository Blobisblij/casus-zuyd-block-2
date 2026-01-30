using casus.Mierentuin.Models;
using System.Runtime.CompilerServices;
using casus.Mierentuin.DataAccess;

namespace casus.Mierentuin
{
    internal class Program
    {
        public static void Main()
        {
            //maak hier alle interfaces aan

        // inladen van alle Objecten uit de database
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
                                  "1. Dieren verzorger\n" +
                                  "2. Verblijfs vezorger\n" +
                                  "3. Manager Dieren verzorger\n" +
                                  "4. Manager Verblijfs verzorger\n");
                Console.WriteLine("Typ het getal voor uw keuze");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1" :
                        bool dierenverzorgermenu = true;
                        while (dierenverzorgermenu)
                        {
                            Console.WriteLine("U bent ingelogd als dierenverzorgd");
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
                                                Console.WriteLine("Niet ontwikkeld voor project");
                                                break;
                                            case "2":
                                                bool dierselecteermenu = true;
                                                while (dierselecteermenu)
                                                {


                                                    Console.WriteLine(
                                                        "Selecteer het dier waarbij u een notitie wil maken");
                                                    int keuegetal = 1;
                                                    foreach (Dier dier in dierenSQL)
                                                    {
                                                        Console.WriteLine($"{keuegetal}. {dier.Naam} {dier.Typedier} {dier.Notitie}");
                                                        keuegetal++;
                                                    }

                                                    Console.WriteLine(
                                                        "typ het getal voor het dier wat u wil selecteren");
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
                                    Console.WriteLine("Niet ontwikkeld voor project");
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