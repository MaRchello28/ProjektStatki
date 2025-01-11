﻿using ProjektStatki.Models;
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
    public class GameController
    {
        MyDbContext db; GameMode gamemode; string LoggedUserId; Player player2;
        public GameController(MyDbContext db, GameMode g, string LoggedUserId, Player player2) 
        { 
            this.db = db;
            gamemode = g;
            this.LoggedUserId = LoggedUserId;
            this.player2 = player2;
        }
        public void RunController()
        {
            Player player1 = db.users.FirstOrDefault(u => u.id == this.LoggedUserId);
            if(player1 == null)
            {
                MessageBox.Show("Nie znaleziono gracza!");
            }
            else
            {
                Game game = new Game(gamemode.board, gamemode.board, gamemode, player1, player2);
                GameView gameView = new GameView(game);
                gameView.ShowDialog();
                //Zacznij grę
                //Wykonywanie ruchów
                //Po ruchu, gdzie był strzał sprawdzasz czy wygrałeś
                //Jeżeli koniec gry wykonaj
            }
        }

        public void StartGame(Game game)
        {

        }

        public void UnlockAchievement()
        {

        }
    }
}
