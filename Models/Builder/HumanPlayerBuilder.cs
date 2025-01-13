using Microsoft.VisualBasic.Logging;
using ProjektStatki.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektStatki.Models.Builder
{
    public class HumanPlayerBuilder:PlayerBuilder
    {
        private string name="", password="", password2="";
        MyDbContext db;
        HumanPlayer user;
        public HumanPlayerBuilder() { db = new MyDbContext(); }
        public void reset()
        {
            
        }
        public void createSteps()
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(password2))
            {
                MessageBox.Show("Niektóe pola są puste. Proszę uzupełnić wszystkie!");
                user = new HumanPlayer();
            }
            else if (!Equals(password2, password))
            {
                MessageBox.Show("Hasło i powtórz hasło nie są takie same!");
                user = new HumanPlayer();
            }
            else if (password.Length < 5)
            {
                MessageBox.Show("Hasło nie może mieć mniej niż 5 znaków!");
                user = new HumanPlayer();
            }
            else if (db.users.Any(s => s.name == name))
            {
                MessageBox.Show("Istnieje użytkownik o takim loginie!");
                user = new HumanPlayer();
            }
            else
            {
                user = new HumanPlayer(name, password);
                db.users.Add(user);
                db.SaveChanges();
                MessageBox.Show("Stworzono konto");
            }
        }

        public void GetNameFromtextBox(string name)
        {
            this.name = name;
        }

        public void GetPasswordFromTextBox(string name)
        {
            this.password = name;
        }
        public void GetPassword2FromTextBox(string name)
        {
            this.password2 = name;
        }

        public Player GetResult()
        {
            return user;
        }
    }
}
