using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.History
{
    public class GameHistoryProxy : History
    {
        private GameHistory realHistory; 
        private int userId; 

        public GameHistoryProxy(GameHistory realHistory, int userId)
        {
            this.realHistory = realHistory;
            this.userId = userId;
        }

        // Metoda, która ładuje historię gier tylko dla konkretnego użytkownika
        public void LoadHistory()
        {
            if (realHistory.gameHistory != null)
            {
                var userGames = realHistory.gameHistory.Where(game => game.player1.playerId == userId || game.player2.playerId == userId).ToList(); //tu krzyczy bo nie ma zadnego id do przyjecia (chyba)
                ShowHistory(userGames);
            }
        }

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
