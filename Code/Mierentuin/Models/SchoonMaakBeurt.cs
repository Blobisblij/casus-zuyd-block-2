using casus.Mierentuin.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace casus.Mierentuin.Models
{
    internal class SchoonMaakBeurt
    {
        private List<Werknemer> werknemers;
        private DateTime tijdstip;
        private Verblijf verblijf;
        public bool Voltooid;

        public SchoonMaakBeurt(List<Werknemer> werknemers, DateTime tijdstip, Verblijf verblijf)
        {
            this.werknemers = werknemers;
            this.tijdstip = tijdstip;
            this.verblijf = verblijf;
            Voltooid = false;
        }
    }



}
