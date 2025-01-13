using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.ElementsToUnlock
{
    public interface Element
    {
        public string type { get; set; }
        public string name { get; set; }
        public int Requiredlvl { get; set; }
        public Element SetElement(int lvl, string name);
    }
}
