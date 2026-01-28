using System;
using System.Collections.Generic;
using System.Text;
using casus.Mierentuin.DataAccess;

namespace casus.Mierentuin.Models
{
    public class VoerBeurt
    {
        private int voerbeurtID;

        public int VoerbeurtID
        {
            get { return voerbeurtID; }
            set { voerbeurtID = value; }
        }
        
        private string typevoer;
        public string Typevoer
        {
            get { return typevoer; }
            set { typevoer = value; }
        }
        
        
        private DateTime tijdstip;
        public DateTime Tijdstip
        {
            get { return tijdstip; }
            set { tijdstip = value; }
        }
        
        private Decimal hoeveelheidvoer;
        public Decimal Hoeveelheidvoer
        {
            get { return hoeveelheidvoer; }
            set { hoeveelheidvoer = value; }
        }
        
        private Verblijf verblijf;
        public Verblijf Verblijf
        {
            get { return verblijf; }
            set { verblijf = value; }
        }
        
        private List<Werknemer> werknemers;
        public List<Werknemer> Werknemers
        {
            get { return werknemers; }
            set { werknemers = value; }
        }
        
        public bool Voltooid;

        public VoerBeurt(int voerbeurtID,string typevoer,DateTime tijdstip,Decimal hoeveelheidvoer,bool Voltooid,int VerblijfID)
        {
            this.typevoer = typevoer;
            this.tijdstip = tijdstip;
            this.hoeveelheidvoer = hoeveelheidvoer;
            this.Voltooid = Voltooid;
            this.voerbeurtID = voerbeurtID;
           //Vind het goeie verblijf
            foreach (Verblijf verblijf in DALSQL.GetAllVerblijf())
            {
                if (VerblijfID == verblijf.Verblijfid)
                {
                    this.verblijf = verblijf;
                }
            }
            // vind de werknemers die bij te taak horen en voegt ze doe aan Werknemers
            List<int> werknemerids = new List<int>();
            foreach (VoerBeurtWerknemer voerBeurtWerknemer in DALSQL.GetAllVoerbeurtWerknemer())
            {
                if (voerbeurtID == voerBeurtWerknemer.VoerBeurtID)
                {
                    werknemerids.Add(voerBeurtWerknemer.WerknemerID);
                }
            }

            foreach (Werknemer werknemer in DALSQL.GetAllWerknemers())
            {
                foreach (int werknemerID in werknemerids)
                {
                    if (werknemer.Werknemerid == werknemerID)
                    {
                        Werknemers.Add(werknemer);
                    }
                }
            }
        }
        
        
    }
}
