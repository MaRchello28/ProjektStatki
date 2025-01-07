using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models
{
    public class ComputerPlayer:Player
    {
        public string name {  get; set; }
        public int difficultyLevel { get; set; }
        public ComputerPlayer(string name, int difficultyLevel)
        {
            this.name = name;
            this.difficultyLevel = difficultyLevel;
        }

        public void EasyMode()
        {

        }

        public void MediumMode()
        {

        }

        public void HardMode()
        {

        }

        public void ChooseDiffLevel()
        {

        }
    }
}
