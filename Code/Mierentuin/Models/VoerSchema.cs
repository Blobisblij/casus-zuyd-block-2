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
        
        public List<VoerBeurt> WerknemerWerkSchema(Werknemer  werknemer)
        {
            List<VoerBeurt> VoerbeurtvanWerknemer = new List<VoerBeurt>();
            foreach (VoerBeurt voerbeurt in schema)
            {
                foreach (Werknemer Voerbeurtwerknemer in voerbeurt.Werknemers)
                {
                    if (Voerbeurtwerknemer == werknemer)
                    {
                        VoerbeurtvanWerknemer.Add(voerbeurt);
                    }
                }
            }
            return VoerbeurtvanWerknemer;
        }
        
        
    }
}
