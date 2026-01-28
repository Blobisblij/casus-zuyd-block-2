using casus.Mierentuin.Models;
using System.Runtime.CompilerServices;
using casus.Mierentuin.DataAccess;

namespace casus.Mierentuin
{
    internal class Program
    {
        public static void Main()
        {
            //VoerSchema voerSchema = new VoerSchema("weekschemavoer", DALSQL.GetAllVoerbeurt());
            //VerblijfsSchema Schoonmaakschema = new VerblijfsSchema("weekschemaSchoonmaak",DALSQL.GetAllSchoonMaakBeurt());
            
            /*Dier Willem = new Dier("wouws","","Koe");
            Willem.doenaam();
            List<string> opties = new List<string>() { "keuze 1", "keuze 2", "keuze 3" };

            W

            /*
            Interfaceprogram startpagina = new Interfaceprogram(jens, opties, "fout oen", "doe hier type:");

            startpagina.Startinterface("invoer moet een getal zijn")
                */
            
            Werknemer jens = new Werknemer("jens", "Dierenverzorger");
            Testclass testopbject = new Testclass(2);
            List<string> testopties = new List<string>() { "doe dit","NU DIT" };
            List<Func<bool>> testoptiemethodes = new List<Func<bool>>() { testopbject.test1,testopbject.test1 };

            Interfaceprogram Testinterface = new Interfaceprogram(jens,testoptiemethodes, testopties, "fout", "doe hier invoeren neef");
            Testinterface.Startinterface();





        }
    }
}
