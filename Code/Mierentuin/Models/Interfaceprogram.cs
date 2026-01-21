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
        public int Startinterface()
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
                int intinvoer = notintvanger();
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
            return keuze;
        }

        public int notintvanger()
        {
            bool intcorrect = false;
            int intinput = 0;
            while (intcorrect == false)
            {
                string inputstring = Console.ReadLine();
                try
                {
                    intinput = int.Parse(inputstring);
                    intcorrect = true;
                }
                catch (System.FormatException)
                {
                    intcorrect = false;
                }
            }
            return intinput;
        }
    }
}
