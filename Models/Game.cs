using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektStatki.Models.Gamemodes;

namespace ProjektStatki.Models
{
    public class Game
    {
        public Board boardPlayer1;
        public Board boardPlayer2;
        public GameMode gameMode;
        public string result;

        public Game() { }//To potem do wyjebania ale to jest teraz. NIE UŻYWAĆ PUSTEGO!!!!!
        public Game(Board b1, Board b2, GameMode g)
        {
            boardPlayer1 = b1;
            boardPlayer2 = b2;
            gameMode = g;
            result = "not resolved";
        }

        public void StartGame()
        {

        }

        public void SaveGame()
        {

        }

        public void LoadGame() { }

        public void OnEndGame()
        {

        }
    }
}
