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
        public Element SetElement();
    }
}
