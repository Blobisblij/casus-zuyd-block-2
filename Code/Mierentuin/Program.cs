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
            //List<Werknemer> werknemers = DALSQL.GetAllWerknemers();
            Werknemer NotLoggedIn = new Werknemer("", "");
            Werknemer sam = new Werknemer("sam", "verblijfmedewerker");
            Werknemer Pieter = new Werknemer("Pieter", "Dierenverzorger");
            Werknemer ayman = new Werknemer("ayman", "verblijfsmagager");
            Werknemer Hans = new Werknemer("Hans", "MamagerDierenverzorgers");

            List<Werknemer> werknemers = new List<Werknemer>() { sam, Pieter, ayman };

            //startscherm
            //Maneger Dierenverzorgers
            string ManagerDierenverzorgerprompt = "";
            string ManagerDierenverzorgerErrormsg = "";
            List<string> MenukeuzesmanagerDierenverzorger = new List<string>()
            {
                
            };

            List<Func<bool>> MenuFuncManagerDierenverzorger = new List<Func<bool>>()
            {

            };
            

            //Verblijfs manager
            string Verblijfsmagagerprompt = "";
            string VerblijfsmagagerErrormsg = "";
            List<string> MenukeuzesVeblijfsmanager = new List<string>()
            {
                
            };

            List<Func<bool>> MenuFuncVerblijfsmagager = new List<Func<bool>>()
            {

            };
            //verblijfsmedewerler
            string Verblijfsmedewerkerprompt = "";
            string VerblijfsmedewerkerErrormsg = "";
            List<string> MenukeuzesVerblijfsmedewerker = new List<string>()
            {
                
            };

            List<Func<bool>> MenuFuncVerblijfsmedewerker = new List<Func<bool>>()
            {

            };
            //Dierenverzorger
            string Dierenverzorgerprompt = "";
            string DierenverzorgerErrormsg = "";
            List<string> MenukeuzesDierenverzorger = new List<string>()
            {
                
            };

            List<Func<bool>> MenuFuncDierenverzorger = new List<Func<bool>>()
            {

            };
            
            //maakt een list van alle users
            List<string> naamenfunctie = new List<string>();
            foreach (Werknemer werknemer in werknemers)
            {
                string naamfunctie = $"{werknemer.Naam}             {werknemer.Functie}";
                naamenfunctie.Add(werknemer.Naam);
            }
            //checkt de functie van de gebruiker en geeft het correcte vervolg interface
            List<Func<bool>> Loginfunc = new List<Func<bool>>();
            foreach (Werknemer werknemer in werknemers)
            {
                switch (werknemer.Functie)
                {
                    case "verblijfmedewerker":
                        Interfaceprogram Verblijfsmedewerkerinterface = new Interfaceprogram(werknemer,
                            MenuFuncVerblijfsmedewerker, MenukeuzesVerblijfsmedewerker, VerblijfsmedewerkerErrormsg,
                            Verblijfsmedewerkerprompt);
                        Loginfunc.Add(Verblijfsmedewerkerinterface.Startinterface);
                        break;
                    case "verblijfsmagager":
                        Interfaceprogram Verblijfsmagagerinterface = new Interfaceprogram(werknemer,MenuFuncVerblijfsmagager,MenukeuzesVeblijfsmanager,VerblijfsmedewerkerErrormsg,Verblijfsmedewerkerprompt);
                        Loginfunc.Add(Verblijfsmagagerinterface.Startinterface);
                        break;
                    case "Dierenverzorger":
                        Interfaceprogram Dierenverzorgerinterface = new Interfaceprogram(werknemer,MenuFuncDierenverzorger,MenukeuzesDierenverzorger,DierenverzorgerErrormsg,Dierenverzorgerprompt);
                        Loginfunc.Add(Dierenverzorgerinterface.Startinterface);
                        break;
                    case "MamagerDierenverzorgers":
                        Interfaceprogram ManagerDierenverzorgerinterface = new Interfaceprogram(werknemer,
                            MenuFuncManagerDierenverzorger, MenukeuzesmanagerDierenverzorger,
                            ManagerDierenverzorgerErrormsg, ManagerDierenverzorgerprompt);
                        Loginfunc.Add(ManagerDierenverzorgerinterface.Startinterface);
                        break;
                }
            }

            Interfaceprogram Loginmenu = new Interfaceprogram(NotLoggedIn, Loginfunc, naamenfunctie,
                "Typ een getal wat binnen de gegeven waarden valt",
                "Typ het getal wat voor de gebruiker staat waarmee u wil inloggen:");
            Loginmenu.Startinterface();




        }
    }
}
