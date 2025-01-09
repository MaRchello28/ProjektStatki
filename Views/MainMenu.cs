using ProjektStatki.Models;
using ProjektStatki.Models.Data;
using ProjektStatki.Views;

namespace ProjektStatki
{
    public partial class MainMenu : Form
    {
        private string login;
        private string password;
        protected HumanPlayer humanPlayer;
        CreateAccountView create;
        MyDbContext db;
        public MainMenu(MyDbContext db)
        {
            InitializeComponent();
            this.db = db;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public string Run()
        {
            this.ShowDialog();
            return humanPlayer.id;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//Zaloguj
        {
            login = textBox1.Text;
            password = textBox2.Text;

            if (db.users.Any(s => s.name == login && s.password == password))
            {
                humanPlayer = db.users.FirstOrDefault(s => s.name == login && s.password == password);
                if (humanPlayer == null)
                {
                    MessageBox.Show("Nie znaleziono u¿ytkownika");
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Nie znaleziono u¿ytkownika");
            }
        }

        private void button2_Click(object sender, EventArgs e)//Utwórz
        {
            create = new CreateAccountView(this, db);
            this.Hide();
            create.ShowDialog();
        }
    }
}
