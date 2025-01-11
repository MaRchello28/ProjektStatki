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
        public ComputerPlayerBuilder() {
            reset();
        }
        public void reset()
        {
            _computerPlayer = new ComputerPlayer("DefaultBot", 1);
        }
        public void createSteps()
        {
            _computerPlayer.name = "EasyBot";
            _computerPlayer.DifficultyLevel = 1;

            _computerPlayer.InitializePendingShots();
        }
        public ComputerPlayer GetResult()
        {
            return _computerPlayer;
        }
    }
}
