using System;
using System.Collections.Generic;
using System.Text;

namespace casus.Mierentuin.Models
{
    public class Dieren
    {
        public string Naam;

        public Dieren(string Naam)
        {
            this.Naam = Naam;
        }

        public void doenaam()
        {
            Console.WriteLine(Naam);
        }
    }
}
