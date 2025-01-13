using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.History
{
    public interface History
    {
        public Game AddToGameHistory();
        public void ShowHistory(List<Game> userGames);
    }
}
