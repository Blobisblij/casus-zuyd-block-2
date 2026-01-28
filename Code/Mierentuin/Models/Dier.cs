using casus.Mierentuin.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;


// deze klas word vooral gebruik voor de data dus eigelijk is het alleen de constructor
namespace casus.Mierentuin.Models
{
    public class Dier
    {
        public string Naam;
        public readonly int DierID;
        private string typedier;
        private int verblijfID;

        public int VerblijfID
        {
            get { return verblijfID; }
            set { verblijfID = value; }
        }

        public string Typedier
        {
            get { return typedier; }
        }
        public string Notitie;
        

        public Dier(string Naam, string Notitie, string typedier)
        {
            this.Naam = Naam;
            this.Notitie = Notitie;
            this.typedier = typedier;
        }

        public Dier(int DierID, string Naam, string Notitie, string typedier, int verblijfID)
        {
            this.DierID = DierID;
            this.Naam = Naam;
            this.Notitie = Notitie;
            this.typedier = typedier;
            this.verblijfID = verblijfID;
        }

        public void doenaam()
        {
            Console.WriteLine(Naam);
        }


    }
}
