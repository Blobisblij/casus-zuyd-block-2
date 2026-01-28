using System;
using System.Collections.Generic;
using System.Text;

namespace casus.Mierentuin.Models
{
    internal class VerblijfsSchema
    {
        private string naam;
        private List<SchoonMaakBeurt> schema;

        public VerblijfsSchema(string naam, List<SchoonMaakBeurt> schema)
        {
            this.naam = naam;
            this.schema = schema;
        }

        public bool VoltookSchoonmaakBeurt()
        {
            
            return true;
        }
    }
}
