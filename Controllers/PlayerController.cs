using ProjektStatki.Models;
using ProjektStatki.Models.Data;
using ProjektStatki.Models.ElementsToUnlock;
using ProjektStatki.Models.Gamemodes;
using ProjektStatki.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjektStatki.Controllers
{
    public class PlayerController
    {
        string LoggedUserId;
        MyDbContext db;
        PlayerView playerView;
        ChooseGameModeView gameModeView;
        HistoryView historyView;
        ShowContentView ShowContentView;
        ShowPlayersRankingView showPlayersRankingView;
        public PlayerController(MyDbContext db, string LoggedUserId, List<Element>elements) 
        { 
            this.db = db;
            this.LoggedUserId = LoggedUserId;
            //playerView = new PlayerView(db,LoggedUserId);
            gameModeView = new ChooseGameModeView(db, LoggedUserId);
            historyView = new HistoryView(db, LoggedUserId);
            ShowContentView = new ShowContentView(elements);
            showPlayersRankingView = new ShowPlayersRankingView(db);
        }
        public void RunController()
        {
            int choose; bool run = true;
            while(run)
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
                    case 2:
                        historyView.ShowDialog();
                        break;
                    case 3:
                        ShowContentView.ShowDialog();
                        break;
                    case 4:
                        showPlayersRankingView.ShowDialog();
                        break;
                    default:
                        {
                            run = false;
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

        public void CreateGame(GameMode gameMode)
        {   
            if(gameModeView.Enemy() != null)
            {
                if(gameModeView.Player1() == null)
                {
                    GameController gameController = new GameController(db, gameMode, LoggedUserId, gameModeView.Enemy());
                    gameController.RunController();
                }
                else
                {
                    GameController gameController = new GameController(db, gameMode, gameModeView.Player1().name, gameModeView.Enemy());
                    gameController.RunController();
                }
            }
            
        }
    }
}
