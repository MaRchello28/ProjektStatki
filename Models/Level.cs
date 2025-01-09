using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models
{
    public class Level
    {
        public int level {  get; set; }
        public int exp { get; set; }
        public int expToNextLevel { get; set; }
        public Level() { }
        public Level(int l, int e, int et) 
        { 
            level = l;
            exp = e;
            expToNextLevel = et;
        }

        public void LevelUp()
        {

        }
    }
}
