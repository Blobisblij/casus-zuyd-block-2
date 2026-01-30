using System;
using System.Collections.Generic;
using System.Text;
using casus.Mierentuin.DataAccess;
//dit is een van de hoofd classes omdat er zoveel bij een komt
//probeer zo veel mogelijk vanuit hier te doen
namespace casus.Mierentuin.Models
{
    public class Verblijf
    {
        public int Verblijfid { get; set; }
        public string Naam { get; set; }
        public string Beschrijving;
        public bool PoortOpen;
        public List<Dier> DiereninVerblijf { get; set; }

        public Verblijf(string Naam, string Beschrijving)
        {
            this.DiereninVerblijf = new List<Dier>();
            this.Naam = Naam;
            this.Beschrijving = Beschrijving;
            PoortOpen = false;
        }

        public Verblijf(int Verblijfid, string Naam, string Beschrijving, bool PoortOpen)
        {
            this.Verblijfid = Verblijfid;
            this.Naam = Naam;
            this.Beschrijving = Beschrijving;
            this.PoortOpen = PoortOpen;
            this.DiereninVerblijf = new List<Dier>();
            List<Dier> allendieren = DALSQL.GetAllDieren();
            foreach (Dier dier in allendieren)
            {
                if (dier.VerblijfID == Verblijfid)
                {
                    this.DiereninVerblijf.Add(dier);
                }
            }
        }
    }
}
    

