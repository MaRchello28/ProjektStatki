using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjektStatki.Models
{
    public class ComputerPlayer:Player
    {
        public string Id { get; set; }
        public string name { get; set; }
        public int DifficultyLevel { get; set; }
        public List<Point> PendingShots { get; set; }

        public ComputerPlayer(string name, int difficultyLevel)
        {
            name = name;
            DifficultyLevel = difficultyLevel;
            PendingShots = new List<Point>();
        }
        
    }
}
