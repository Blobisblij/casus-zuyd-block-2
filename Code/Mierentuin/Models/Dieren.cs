using casus.Mierentuin.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace casus.Mierentuin.Models
{
    public class Dieren
    {
        public string Naam;
        public readonly int DierID;

        public Dieren(string Naam)
        {
            this.Naam = Naam;
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
