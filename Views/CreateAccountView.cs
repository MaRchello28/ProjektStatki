using ProjektStatki.Models.Builder;
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
        public HumanPlayerBuilder playerBuilder = new HumanPlayerBuilder();
        public PlayerDirector playerDirector;
        public CreateAccountView(MainMenu mainMenu, MyDbContext db)
        {
            InitializeComponent();
            this.mainMenu = mainMenu;
            this.db = db;
            playerDirector = new PlayerDirector(playerBuilder);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateAccountView_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playerBuilder.GetNameFromtextBox(textBox1.Text);
            playerBuilder.GetPasswordFromTextBox(textBox2.Text);
            playerBuilder.GetPassword2FromTextBox(textBox3.Text);
            playerDirector.BuildPlayer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            mainMenu.Show();
        }
    }
}
