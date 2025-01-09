using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models
{
    public class HumanPlayer : Player
    {
        public string id { get; set; }
        public string name {  get; set; }
        public string password { get; set; }
        public int raitingPoints { get; set; }
        public Level level { get; set; }
        public List<Achievement> achievements { get; set; }

        public HumanPlayer() { }
        public HumanPlayer(string name, string password) 
        {
            this.id = GenerateId();
            this.name = name;
            this.password = password;
            raitingPoints = 1000;
            level = new Level(1, 0, 6);
            achievements = new List<Achievement>();
        }

        public HumanPlayer(string name, string password, int rait, int level, int exp, int expToNext)
        {
            this.id = GenerateId();
            this.name = name;
            this.password = password;
            raitingPoints = rait;
            this.level.level = level;
            this.level.exp = exp;
            this.level.expToNextLevel = expToNext;
        }

        private string GenerateId()
        {
            string datePart = DateTime.Now.ToString("yyyyMMddHHmmss");

            Random random = new Random();
            string randomDigits = random.Next(100000000, 999999999).ToString();

            return datePart + randomDigits;
        }
    }
}
