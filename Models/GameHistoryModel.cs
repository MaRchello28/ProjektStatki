using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models
{
    public class GameHistoryModel
    {
        public int Id { get; set; }

        public int Player1ID { get; set; }
        public int Player2ID { get; set; }

        public DateTime GameDate { get; set; }
        public string Result { get; set; }
        public string GameModeName { get; set; }

        public GameHistoryModel(int Player1ID, int Player2ID, string Result, string GameModeName)
        {        
            this.Player1ID = Player1ID;
            this.Player2ID = Player2ID;
            this.Result = Result;
            this.GameModeName = GameModeName;
            this.GameDate = DateTime.Now;
        }
    }
}
