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
    public partial class PlayerView : Form
    {
        MyDbContext db;
        public int choose = 10;
        ChooseGameModeView gameModeView = new ChooseGameModeView();
        public PlayerView(MyDbContext db)
        {
            InitializeComponent();
            this.db = db;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PlayerView_Load(object sender, EventArgs e)
        {

        }

        public void Run(string LoggedUserId)
        {
            var user = db.users.FirstOrDefault(s => s.id == LoggedUserId);
            if (user == null)
            {
                MessageBox.Show("Coś poszło nie tak ze znalezieniem użytkownika");
                this.Close();
            }
            else
            {
                label2.Text = user.name;
                int progresbarExp = 100 * user.level.exp / user.level.expToNextLevel;
                progressBar1.Value = progresbarExp;
                label1.Text = user.level.level.ToString();
                this.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            choose = 1;
            if (gameModeView.IsDisposed)
            {
                gameModeView = new ChooseGameModeView();
            }

            gameModeView.Show();
        }
    }
}
