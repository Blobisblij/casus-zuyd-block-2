using casus.Mierentuin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace casus.Mierentuin
{
    internal class Program
    {
        public static void Main()
        {
            Dieren Willem = new Dieren("wouws");
            Willem.doenaam();
            List<string> opties = new List<string>() { "keuze 1", "keuze 2", "keuze 3" };

            Werknemer jens = new Werknemer("jens", "Dierenverzorger");

            Interfaceprogram startpagina = new Interfaceprogram(jens, opties, "fout oen", "doe hier type:");

            startpagina.Startinterface("invoer moet een getal zijn");
            
        }
    }
}
