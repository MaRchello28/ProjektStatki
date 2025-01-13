using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.ElementsToUnlock
{
    public class SkinElement:Element
    {
        public string type { get; set; }
        public string name { get; set; }

        public int Requiredlvl { get; set; }

        public SkinElement(string type, int Requiredlvl, string name) 
        { 
            this.type = type;
            this.Requiredlvl = Requiredlvl;
            this.name = name;
        }
        public Element SetElement(int lvl, string name)
        {
            return new SkinElement("Skin",lvl,name);
        }
    }
}
