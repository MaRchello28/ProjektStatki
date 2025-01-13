using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.ElementsToUnlock
{
    public class GameModeElement:Element
    {
        public string type { get; set; }
        public string name { get; set; }

        public int Requiredlvl { get; set; }

        public GameModeElement(string type, int requiredlvl, string name)
        {
            this.type = type;
            this.Requiredlvl = requiredlvl;
            this.name = name;
        }
        public Element SetElement(int lvl, string name)
        {
            return new GameModeElement("Gra",lvl , name);
        }
    }
}
