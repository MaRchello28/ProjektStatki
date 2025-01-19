using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.Builder
{
    public class ComputerPlayerBuilder : PlayerBuilder
    {
        private ComputerPlayer _computerPlayer;
        private Random _random;

        public ComputerPlayerBuilder()
        {
            _random = new Random();
            reset();
        }

        public void reset()
        {
            _computerPlayer = new ComputerPlayer("DefaultBot", 1);
        }

        public void createSteps(string name)
        {
            
            _computerPlayer.name = name;
            _computerPlayer.DifficultyLevel = 1;
            _computerPlayer.PendingShots.Clear();
        }

        public Player GetResult()
        {
            return _computerPlayer;
        }
    }
}

