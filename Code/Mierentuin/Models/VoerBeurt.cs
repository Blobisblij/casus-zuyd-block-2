using System;
using System.Collections.Generic;
using System.Text;

namespace casus.Mierentuin.Models
{
    internal class VoerBeurt
    {
        private string typevoer;
        private DateTime tijdstip;
        private Decimal hoeveelheidvoer;
        private Verblijf verblijf;
        private List<Werknemer> werknemers;
        public bool Voltooid;

        public VoerBeurt(string typevoer,DateTime tijdstip,Decimal hoeveelheidvoer,Verblijf verblijf,List<Werknemer> werknemers)
        {
            this.typevoer = typevoer;
            this.tijdstip = tijdstip;
            this.hoeveelheidvoer = hoeveelheidvoer;
            this.verblijf = verblijf;
            this.werknemers = werknemers;
            Voltooid = false;
        }
        
        
    }
}
