using casus.Mierentuin.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace casus.Mierentuin.Models
{
    public class SchoonMaakBeurt
    {
        private int SchoonMaakBeurtID;
        public int SchoonmaakBeurtID
        {
            get { return SchoonMaakBeurtID; }
            set { SchoonMaakBeurtID = value; }
            
        }
        private List<Werknemer> werknemers;

        public List<Werknemer> Werknemers
        {
            get { return werknemers; }
            set { werknemers = value; }
        }
        
        private DateTime tijdstip;

        public DateTime Tijdstip
        {
            get { return tijdstip; }
            set { tijdstip = value; }
        }
    
        private Verblijf verblijf;

        public Verblijf Verblijf
        {
            get { return verblijf; }
            set { verblijf = value; }
        }
        public bool Voltooid;

        public SchoonMaakBeurt(int schoonMaakBeurtId, DateTime tijdstip,bool voltooid,int verblijfID)
        {
            this.SchoonmaakBeurtID = schoonMaakBeurtId;
            this.tijdstip = tijdstip;
            this.Voltooid = voltooid;
           // vind het bijbehordende verblijf
            foreach (Verblijf verblijf in DALSQL.GetAllVerblijf())
            {
                if (verblijfID == verblijf.Verblijfid)
                {
                    this.verblijf = verblijf;
                }
            }

            // vind de werknemer die aangewezen zijn voor de taak en voegt ze toe aan Werknemers
            List<int> werknemerids = new List<int>();
            foreach (SchoonmaakWerknemer schoonmaakWerknemer in DALSQL.GetAllSchoonmaakWerknemer())
            {
                if (SchoonmaakBeurtID == schoonmaakWerknemer.SchoonmaakBeurtID)
                {
                    werknemerids.Add(schoonmaakWerknemer.WerknemerID);
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
