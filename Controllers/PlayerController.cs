using ProjektStatki.Models.Data;
using ProjektStatki.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Controllers
{
    public class PlayerController
    {
        string LoggedUserId;
        MyDbContext db;
        PlayerView playerView;
        public PlayerController(MyDbContext db, string LoggedUserId) 
        { 
            this.db = db;
            this.LoggedUserId = LoggedUserId;
            playerView = new PlayerView(db);
        }
        public void RunController()
        {
            playerView.Run(LoggedUserId);
        }

        public void ShowRanking()
        {

        }

        public void ShowGameHistory()
        {

        }

        public void CreateGame()
        {

        }

        public void UnlockElement()
        {

        }
    }
}
