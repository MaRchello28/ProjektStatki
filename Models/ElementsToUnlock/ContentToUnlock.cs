using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.ElementsToUnlock
{
    public class ContentToUnlock
    {
        List<Element> elements;
        public ContentToUnlock(List<Element> elements) 
        { 
            this.elements = elements;
        }

        public Element HowToUnlock(List<Element> element, int lvl)
        {
            for(int i = 0; i < elements.Count; i++)
            {
                if(elements[i].Requiredlvl == lvl)
                    return elements[i];
            }
            return null;
        }
    }
}
