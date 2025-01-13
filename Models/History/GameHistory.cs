using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.History
{
    public class GameHistory : History
    {
        public List<Game> gameHistory;

        public GameHistory(List<Game> g) { gameHistory = g; }

        public Game AddToGameHistory()
        {
            return new Game();
        }

        public void ShowHistory(List<Game> userGames)
        {
            foreach (var game in userGames)
            {
                Console.WriteLine($"Game ID: {game.gameId}, Player 1: {game.player1.name}, Player 2: {game.player2.name}, Result: {game.result}");
            }
        }
    }
}
