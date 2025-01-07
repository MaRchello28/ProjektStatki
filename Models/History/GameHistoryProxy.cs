using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.History
{
    public class GameHistoryProxy : History
    {
        public GameHistory realhistory { get; set; }
        public GameHistoryProxy(GameHistory realhistory)
        {
            this.realhistory = realhistory;
        }

        public void LoadHistory()
        {

        }

        public Game AddToGameHistory()
        {
            return new Game();
        }

        public void ShowHistory()
        {

        }
    }
}
