using casus.Mierentuin.Models;
using System.Runtime.CompilerServices;

namespace casus.Mierentuin
{
    internal class Program
    {
        public static void Main()
        {
            Dier Willem = new Dier("wouws","","Koe");
            Willem.doenaam();
            List<string> opties = new List<string>() { "keuze 1", "keuze 2", "keuze 3" };

            Werknemer jens = new Werknemer("jens", "Dierenverzorger");

            /*
            Interfaceprogram startpagina = new Interfaceprogram(jens, opties, "fout oen", "doe hier type:");

            startpagina.Startinterface("invoer moet een getal zijn")
                */

            Testclass testopbject = new Testclass(2);
            List<string> testopties = new List<string>() { "doe dit","NU DIT" };
            List<Func<bool>> testoptiemethodes = new List<Func<bool>>() { testopbject.test1,testopbject.test1 };

            Interfaceprogram Testinterface = new Interfaceprogram(jens,testoptiemethodes, testopties, "fout", "doe hier invoeren neef");
            Testinterface.Startinterface();


        }
    }
}
