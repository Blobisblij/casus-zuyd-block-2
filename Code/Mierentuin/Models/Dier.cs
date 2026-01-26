using casus.Mierentuin.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace casus.Mierentuin.Models
{
    public class Dier
    {
        public string Naam;
        public readonly int DierID;
        private string typedier;

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

        public Dier(int DierID, string Naam, string Notitie, string typedier)
        {
            this.DierID = DierID;
            this.Naam = Naam;
            this.Notitie = Notitie;
            this.typedier = typedier;
        }

        public void doenaam()
        {
            Console.WriteLine(Naam);
        }

        public void CreateDierenData()
        {
            DALSQL dalSql = new DALSQL();

            dalSql.AddDier(this);
        }
    }
}
