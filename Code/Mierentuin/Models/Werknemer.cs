using System;
using System.Collections.Generic;
using System.Text;

namespace casus.Mierentuin.Models
{
    internal class Werknemer
    {
        private int werknemerid;
        public int Werknemerid 
        {
            get { return werknemerid; }
            private set { werknemerid = value;}
        }

        private string naam;
        public string Naam 
        {
            get { return naam; }
            private set { naam = value; }
        }

        private string functie;
        public string Functie 
        {   get { return functie; }
            private set { functie = value; }
        }
    }
}
