using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using casus.Mierentuin.DataAccess;

/*TUTORIAL VOOR HET MAKEN VAN INTERFACES
 *Maak 2 lijsten
 *List<string> (Opieslist) new List<string>() {"optie 1","Optie 2"}; Hier staan de strings die de opties beschrijven
 *List<Func<bool>> (Methodeslist) new List<Func<bool>>() {objectnaam.methodenaam,objectnaam.methodenaam}; hier staan de methodes die uitgevoerd worden als er een keuze gemaakt word
 *
 *als er geen werknemer is dan kan je er een aan maken
 *Werknemer (werknemernaam) = new Werknemer(naam,Functie);
 *
 *maak nu het nieuwe interface object
 *Interfaceprogram NaamInterface = new Interfaceprogram(werknemernaam,Methodeslist,Optieslist,"string als invoer fout is","prompt");
 *Als je je interface wil starten gebruik dan Objectnaam.Startinterface
 *
 *LIMITATIE's
 *De einige methodes die aangeroepen kunnen worden zijn methodes waarvan de return Bool is en er geen param's zijn
 *
 *TIP's
 *Zorg er voor dat alle methodes die je aan roept ook een interface zijn
 *Als je terug moet naar een vorig interface kan je die gewoon aan roepen
 **/
namespace casus.Mierentuin.Models
{
    internal class Interfaceprogram
    {
        public Interfaceprogram Vorigmenu;
        private Werknemer user;
        public Werknemer Werknemer
        {
            get {  return user; }
            private set { user = value; }
        }
        private List<Func<bool>> functielijst;
        private List<string> opties;
        private string errormsg;
        private string inputprompt;

        public Interfaceprogram(Werknemer user,List<Func<bool>> functielijst,List<string> opties,string errormsg, string inputprompt)
        {
            this.user = user;
            this.functielijst = functielijst;
            this.opties = opties;      
            this.errormsg = errormsg;
            this.inputprompt = inputprompt;
        }

        //Startinterface() Start je interface ,displayed de opties en geeft je keuze door aan ExecKeuze()
        private void startinterface()
        {
            bool Interfaceactief = true;
            int keuze = 0;

            while (Interfaceactief)
            {
                int optienummer = 1;
                foreach (string optie in opties)
                {
                    Console.WriteLine($"{optienummer}: {optie}");
                    optienummer = optienummer + 1;
                }
                Console.Write(inputprompt);
                string inputstring = Console.ReadLine();
                int intinvoer;
                try
                {
                    intinvoer = int.Parse(inputstring);
                    if (0 < intinvoer && opties.Count >= intinvoer){
                        keuze = intinvoer;
                        Interfaceactief = false;
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine(errormsg);
                }
            }
             execkeuze(keuze);
        }

        private void execkeuze(int keuze)
        {
            bool succes = functielijst[keuze-1]();
        }

       //Gemaakt zodat je interface kan chainen kweet niet of het handig is
        public bool Startinterface()
        {
            startinterface();
            return true;
        }

        public bool GaTerugInterface()
        {
            Vorigmenu.startinterface();
            return true;
        }
        
        public bool Stopinterface()
        {
            return true;
        }
        
        
        
        
    }
}
