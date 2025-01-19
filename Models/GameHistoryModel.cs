using ProjektStatki.Models.Data;
using System;
using System.Linq;

namespace ProjektStatki.Models
{
    public class GameHistoryModel
    {
        public int Id { get; set; }
        public string Player1ID { get; set; } // Zawsze ID zalogowanego gracza
        public string Player2ID { get; set; } // Zawsze ID przeciwnika
        public DateTime GameDate { get; set; }
        public string Result { get; set; }
        public string GameModeName { get; set; }

        // Właściwość zamieniająca Player2ID na nazwę przeciwnika
        public string OpponentName
        {
            get
            {
                using (var context = new MyDbContext())
                {
                    var opponent = context.users.FirstOrDefault(u => u.Id == (Player2ID));
                    return opponent != null ? opponent.name : "Nieznany gracz";
                }
            }
        }

        public GameHistoryModel() { }
        public GameHistoryModel(string player1ID, string player2ID, string result, string gameModeName, DateTime gameDate)
        {
            Player1ID = player1ID; // Zalogowany gracz
            Player2ID = player2ID; // Przeciwnik
            Result = result;
            GameModeName = gameModeName;
            GameDate = gameDate;
        }
    }
}
