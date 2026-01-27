using System;
using System.Collections.Generic;
using System.Text;

namespace casus.Mierentuin.Models
{
    public class VoerBeurt
    {
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

        public VoerBeurt(string typevoer,DateTime tijdstip,Decimal hoeveelheidvoer,bool Voltooid)
        {
            this.typevoer = typevoer;
            this.tijdstip = tijdstip;
            this.hoeveelheidvoer = hoeveelheidvoer;
            this.Voltooid = Voltooid;
        }
        
        
    }
}
