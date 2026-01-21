using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace casus.Mierentuin.Models
{
    internal class Interfaceprogram
    {
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

        public Interfaceprogram(Werknemer user,List<string> opties, string errormsg, string inputprompt)
        {
            this.user = user;
            this.opties= opties;
            this.errormsg= errormsg;
            this.inputprompt = inputprompt;
            functielijst = new List<Func<bool>>();
        }
        public void Startinterface(string errormsg)
        {
            bool Interfaceactief = true;
            int keuze = 0;

            while (Interfaceactief == true)
            {
                int optienummer = 1;
                foreach (string optie in opties)
                {
                    Console.WriteLine($"{optienummer}: {optie}");
                    optienummer = optienummer + 1;
                }
                Console.Write(inputprompt);
                //int intinvoer = notintvanger();
                string inputstring = Console.ReadLine();
                int intinvoer;
                try
                {
                    intinvoer = int.Parse(inputstring);
                }
                catch (System.FormatException)
                {
                    intinvoer = -1;
                }
                if (0 < intinvoer && opties.Count >= intinvoer)
                {
                    keuze = intinvoer;
                    Interfaceactief = false;
                }
                else
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

        
    }
}
