using casus.Mierentuin.Models;
using System.Runtime.CompilerServices;
using casus.Mierentuin.DataAccess;

namespace casus.Mierentuin
{
    internal class Program
    {
        public static void Main()
        {
            // Maak hier alle interfaces aan

            // Login
            // Comment uit als we een database hebben

            // Haal alle werknemers op uit de database
            List<Werknemer> werknemersSQL = DALSQL.GetAllWerknemers();

            // Maak het voerschema aan met data uit de database
            VoerSchema voerSchema = new VoerSchema("Voerschema", DALSQL.GetAllVoerbeurt());

            // Schoonmaakschema kan hier aangemaakt worden
            // SchoonmaakSchema schoonmaakSchema = new SchoonmaakSchema(...);

            // Zorgt dat het programma blijft draaien tot gebruiker stopt
            bool running = true;

            while (running)
            {
                // Toon menu opties
                Console.WriteLine("1. Dier aanmelden");
                Console.WriteLine("0. Stoppen");

                // Lees keuze van gebruiker
                string inputstring = Console.ReadLine();

                switch (inputstring)
                {
                    case "1":

                        // Vraag naam van het dier
                        Console.WriteLine("Voer de naam van het dier in:");
                        string naam = Console.ReadLine();

                        // Vraag type dier
                        Console.WriteLine("Voer het type dier in:");
                        string typedier = Console.ReadLine();

                        // Vraag notitie inclusief verblijf
                        Console.WriteLine("Voer een notitie in. Vermeld hier ook het verblijf:");
                        string notitie = Console.ReadLine();

                        // Maak nieuw Dier object aan
                        Dier dier = new Dier(naam, notitie, typedier);

                        // Voeg dier toe aan database
                        DALSQL.Adddata(dier);

                        Console.WriteLine("Het dier is succesvol aangemeld.");
                        break;

                    case "0":
                        // Stop het programma
                        running = false;
                        break;

                    default:
                        // Ongeldige invoer
                        Console.WriteLine("Ongeldige keuze.");
                        break;
                }
            }


        }
    }
}