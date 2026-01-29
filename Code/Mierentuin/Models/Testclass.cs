using System;
using System.Collections.Generic;
using System.Text;
using casus.Mierentuin.DataAccess;

namespace casus.Mierentuin.Models
{
    internal class Testclass
    {
        public int getal;

        public Testclass(int getal)
        {
            this.getal = getal;
        }

        public bool test1()
        {
            Console.WriteLine("Doet Het!");
            return true;
        }

        public static bool UnderConstruction(Func<bool> schermterug)
        {
            Console.WriteLine("under construction\n\n\n\n\n\n\n\n");
            schermterug();
            return true;
        }

        public static void TestSQL()
        {
            Console.WriteLine("dieren");
            List<Dier> dieren = DALSQL.GetAllDieren();
            Console.WriteLine("werknemers");
            List<Werknemer> werknemers = DALSQL.GetAllWerknemers();
            Console.WriteLine("verblijven");
            List<Verblijf> verblijven = DALSQL.GetAllVerblijf();
            Console.WriteLine("voerbeurten");
            List<VoerBeurt> voerbeurten = DALSQL.GetAllVoerbeurt();
            Console.WriteLine("schoonmaakbeurten");
            List<SchoonMaakBeurt> schoonMaakBeurten = DALSQL.GetAllSchoonMaakBeurt();

            foreach (Verblijf v in verblijven)
            {
                Console.WriteLine($"{v.Naam}{v.Beschrijving},{v.Verblijfid},{v.DiereninVerblijf}");
                foreach (Dier D in v.DiereninVerblijf)
                {
                    
                    Console.WriteLine($"{D.Naam}{D.Notitie}");
                }
                Console.WriteLine("doorloop");
            }
        }
    }
}
