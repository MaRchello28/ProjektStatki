using ProjektStatki.Models;
using ProjektStatki.Models.Data;
using ProjektStatki.Models.ElementsToUnlock;
using ProjektStatki.Views;

namespace ProjektStatki
{
    public partial class MainMenu : Form
    {
        private string login;
        private string password;
        protected HumanPlayer humanPlayer;
        CreateAccountView create;
        List<Element> elements = new List<Element>();
        MyDbContext db;
        public MainMenu(MyDbContext db)
        {
            InitializeComponent();
            this.db = db;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitElements();
        }

        public string Run()
        {
            this.ShowDialog();
            return humanPlayer.Id;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e) //Zaloguj
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
                    PlayerView playerView = new PlayerView(db, humanPlayer.name, elements);
                    playerView.Run(humanPlayer.name);
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

        public void InitElements()
        {
            elements.Add(new SkinElement("Skin", 4, "Pink"));
            elements.Add(new GameModeElement("GameMode", 6, "Specjalne Statki"));
        }
    }
}
