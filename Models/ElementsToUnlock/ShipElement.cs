﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.ElementsToUnlock
{
    public class ShipElement:Element
    {
        public string type { get; set; }
        public ShipElement(string type) 
        { 
            this.type = type;
        }

        public Element SetElement()
        {
            return new ShipElement("żaglówka");
        }
    }
}
