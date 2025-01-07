using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models
{
    public class HumanPlayer : Player
    {
        public string name {  get; set; }
        public string password { get; set; }
        public int raitingPoints { get; set; }
        public Level level { get; set; }
        public List<Achievement> achievements { get; set; }
        public HumanPlayer(string name, string password) 
        {
            this.name = name;
            this.password = password;
            raitingPoints = 1000;
            level = new Level(1, 0, 6);
            achievements = new List<Achievement>();
        }
    }
}
