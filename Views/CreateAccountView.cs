using ProjektStatki.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektStatki.Views
{
    public partial class CreateAccountView : Form
    {
        private MainMenu mainMenu; MyDbContext db;
        public CreateAccountView(MainMenu mainMenu, MyDbContext db)
        {
            InitializeComponent();
            this.mainMenu = mainMenu;
            this.db = db;
        }

        private void CreateAccountView_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            string password2 = textBox3.Text;
            if(string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(password2))
            {
                MessageBox.Show("Niektóe pola są puste. Proszę uzupełnić wszystkie!");
            }
            else if(!Equals(password2, password))
            {
                MessageBox.Show("Hasło i powtórz hasło nie są takie same!");
            }
            else if(db.users.Any(s => s.name == login))
            {
                MessageBox.Show("Istnieje użytkownik o takim loginie!");
            }
            else
            {
                var user = new Models.HumanPlayer(login, password);
                db.users.Add(user);
                db.SaveChanges();
                MessageBox.Show("Stworzono konto");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            mainMenu.Show();
        }
    }
}
