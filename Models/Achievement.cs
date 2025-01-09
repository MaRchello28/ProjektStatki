using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models
{
    public class Achievement
    {
        public string id {  get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool wasUnlocked { get; set; }
        public Achievement(string n, string d, bool w)
        {
            name = n;
            description = d;
            wasUnlocked = w;
        }

        public void UnlockAchievement()
        {

        }

    }
}
