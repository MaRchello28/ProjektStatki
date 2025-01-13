using ProjektStatki.Models;
using ProjektStatki.Models.Data;
using ProjektStatki.Models.Gamemodes;
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
        ChooseGameModeView gameModeView;
        public PlayerController(MyDbContext db, string LoggedUserId) 
        { 
            this.db = db;
            this.LoggedUserId = LoggedUserId;
            playerView = new PlayerView(db);
            gameModeView = new ChooseGameModeView(db);
        }
        public void RunController()
        {
            int choose;
            while(true)
            {
                choose = playerView.Run(LoggedUserId);
                switch (choose)
                {
                    case 1:
                        {
                            gameModeView.ShowDialog();
                            GameMode selectedGameMode = gameModeView.ChoseGamemode();
                            if (selectedGameMode != null)
                            {
                                CreateGame(selectedGameMode);
                            }
                            else
                            {
                                MessageBox.Show("Nie wybrano trybu gry.");
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        public Player GetLoggedPlayer()
        {
            var user = db.users.FirstOrDefault(u => u.Id == LoggedUserId);
            return user;
        }

        public void ShowRanking()
        {

        }

        public void ShowGameHistory()
        {

        }

        public void CreateGame(GameMode gameMode)
        {   
            if(gameModeView.Enemy() != null)
            {
                GameController gameController = new GameController(db, gameMode, LoggedUserId, gameModeView.Enemy());
                gameController.RunController();
            }
            
        }

        public void UnlockElement()
        {

        }
    }
}
