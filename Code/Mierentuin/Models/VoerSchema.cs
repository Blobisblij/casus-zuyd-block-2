using System;
using System.Collections.Generic;
using System.Text;

namespace casus.Mierentuin.Models
{
    internal class VoerSchema
    {
        private string naam;
        private List<VoerBeurt> schema;
        
        public VoerSchema(string naam, List<VoerBeurt> schema)
        {
            this.naam = naam;
            this.schema = schema;
        }
        
        public bool VoltooiBeurt()
        {
            return true;
        }
    }
}
