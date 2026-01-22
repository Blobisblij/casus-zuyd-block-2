using System;
using System.Collections.Generic;
using System.Text;

namespace casus.Mierentuin.Models
{
    internal class Verblijf
    {
        private int verblijfid;
        private string naam;
        public string beschrijving;
        private List<int> afmetingen;
        public bool poortopen;
        private List<Dieren> diereninverblijf;
    }
}
