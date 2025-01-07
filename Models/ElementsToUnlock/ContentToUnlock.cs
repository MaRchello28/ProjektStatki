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

        public void HowToUnlock()
        {

        }
    }
}
