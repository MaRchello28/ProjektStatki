using ProjektStatki.Models;
using ProjektStatki.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Controllers
{
    public class GameController
    {
        MyDbContext db; Game game;
        public GameController(MyDbContext db, Game game) 
        { 
            this.db = db;
            this.game = game;
        }
        public void RunController()
        {
            //Zacznij grę
            game.StartGame();
            //Wykonywanie ruchów
            //Po ruchu, gdzie był strzał sprawdzasz czy wygrałeś
            //Jeżeli koniec gry wykonaj
        }

        public void UnlockAchievement()
        {

        }
    }
}
