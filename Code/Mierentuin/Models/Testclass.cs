using System;
using System.Collections.Generic;
using System.Text;

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

        public bool UnderConstruction(Func<bool> schermterug)
        {
            Console.WriteLine("under construction\n\n\n\n\n\n\n\n");
            schermterug();
            return true;
        }
    }
}
