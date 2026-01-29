using casus.Mierentuin.Models;
using System.Runtime.CompilerServices;
using casus.Mierentuin.DataAccess;

namespace casus.Mierentuin
{
    internal class Program
    {
        public static void Main()
        {
            //maak hier alle interfaces aan

            //login
            //comment uit als we een database hebben
            List<Werknemer> werknemersSQL = DALSQL.GetAllWerknemers();
            List<Dier> dierenSQL = DALSQL.GetAllDieren();

            //Voerschema
            //VoerSchema voerSchema = new VoerSchema("Voerschema", DALSQL.GetAllVoerbeurt());
            //schoonmaakschema
            
            //Testclass.TestSQL();

            Testclass.TestSQL();

        }
    }
}