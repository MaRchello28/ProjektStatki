using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models
{
    public class HumanPlayer : Player
    {
        public string Id { get; set; }
        public string name {  get; set; }
        public string password { get; set; }
        public int raitingPoints { get; set; }
        public Level level { get; set; }
        public List<Achievement> achievements { get; set; }

        public HumanPlayer() { }
        public HumanPlayer(string name, string password) 
        {
            this.Id = GenerateId();
            this.name = name;
            this.password = password;
            raitingPoints = 1000;
            level = new Level(1, 0, 6);
            achievements = new List<Achievement>();
        }

        public HumanPlayer(string name, string password, int rait, int level, int exp, int expToNext)
        {
            this.Id = GenerateId();
            this.name = name;
            this.password = password;
            raitingPoints = rait;
            this.level.level = level;
            this.level.exp = exp;
            this.level.expToNextLevel = expToNext;
        }
        public Point Shot(Board b)
        {
            return new Point(0, 0);
        }

        private string GenerateId()
        {
            string datePart = DateTime.Now.ToString("yyyyMMddHHmmss");

            Random random = new Random();
            string randomDigits = random.Next(100000000, 999999999).ToString();

            return datePart + randomDigits;
        }

        public void LevelUp(bool gameWon)
        {
            if(gameWon)
            {
                level.exp += 5;
                if (level.exp > level.expToNextLevel)
                {
                    level.level++;
                    level.exp = level.exp - level.expToNextLevel;
                    level.expToNextLevel += 6;
                }
            }
            else
            {
                level.exp += 2;
                if (level.exp > level.expToNextLevel)
                {
                    level.level++;
                    level.exp = level.exp - level.expToNextLevel;
                    level.expToNextLevel += 6;
                }
            }
        }

        public void UpdateRanking(bool gameWon, int enemyRaitingPoints)
        {
            if(gameWon)
            {
                if(raitingPoints + 200 < enemyRaitingPoints )
                {
                    raitingPoints += 20;
                }
                else if(raitingPoints - 200 > enemyRaitingPoints )
                {
                    raitingPoints += 1;
                }
                else
                {
                    raitingPoints += 10;
                }
            }
            else
            {
                if (raitingPoints + 200 < enemyRaitingPoints)
                {
                    raitingPoints -= 1;
                }
                else if (raitingPoints - 200 > enemyRaitingPoints)
                {
                    raitingPoints -= 20;
                }
                else
                {
                    raitingPoints -= 10;
                }
            }
        }
    }
}
