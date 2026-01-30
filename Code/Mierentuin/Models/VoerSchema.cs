using System;
using System.Collections.Generic;
using System.Text;

namespace casus.Mierentuin.Models
{
    internal class VoerSchema
    {
        private string naam;
        private List<VoerBeurt> schema;
        public Werknemer werknemer;
        
        public VoerSchema(string naam, List<VoerBeurt> schema)
        {
            this.naam = naam;
            this.schema = schema;
        }
        
        private List<VoerBeurt> werknemerwerkschema(Werknemer  werknemer)
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

        public bool Werkschemainterface(Werknemer werknemer)
        {
            List<VoerBeurt> werkschema = werknemerwerkschema(werknemer);
            Console.WriteLine("Werkschema Voerbeurten\nTypeVoer     Hoeveelheid     Verblijf       Voltooid");
            foreach (VoerBeurt beurt in werkschema)
            {
                string typevoer = beurt.Typevoer;
                decimal hoeveel = beurt.Hoeveelheidvoer;
                String verblijfnaam = beurt.Verblijf.Naam;
                bool voitooid = beurt.Voltooid;
                Console.Write($"{typevoer}      {hoeveel}     {verblijfnaam}        {voitooid}\n");
                
            }
            return true;
        }

        public bool Werkschemainterface()
        {
            throw new NotImplementedException();
        }
    }
}
