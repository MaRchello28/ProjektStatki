using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektStatki.Models.Gamemodes;

namespace ProjektStatki.Models
{
    public class Game
    {
        //Tu skończyłem zobaczymy czy zadziała
        public int gameId { get; set; }
        //[NotMapped]
        public Board boardPlayer1 { get; set; }
        //[NotMapped]
        public Board boardPlayer2 { get; set; }
        public GameMode gameMode {  get; set; }
        public string result { get; set; }
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public DateTime gameStart { get; set; }


        public Game() { }
        public Game(Board b1, Board b2, GameMode g, Player p1, Player p2)
        {
            boardPlayer1 = b1;
            boardPlayer2 = b2;
            gameMode = g;
            result = "not resolved";
            player1 = p1;
            player2 = p2;
            gameStart = DateTime.Now;
        }

        public void StartGame()
        {
            boardPlayer1.player = player1;
            boardPlayer2.player = player2;
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
