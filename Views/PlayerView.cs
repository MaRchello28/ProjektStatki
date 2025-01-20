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
using NAudio.Wave;
using ProjektStatki.Models;

namespace ProjektStatki.Views
{
    public partial class PlayerView : Form
    {
        MyDbContext db;
        public int choose = 10;
        private IWavePlayer _waveOutDevice;
        private AudioFileReader _audioFileReader;
        private bool buttonPress = false;
        private  HumanPlayer _player;
        private  SettingsView _settingsView;
        public PlayerView(MyDbContext db, string player)
        {
            InitializeComponent();
            this.db = db;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += PlayerView_FormClosing;
            var tempFile = System.IO.Path.GetTempFileName();
            System.IO.File.WriteAllBytes(tempFile, Properties.Resources._02_Title_Theme);
            _waveOutDevice = new WaveOutEvent();
            _audioFileReader = new AudioFileReader(tempFile);
            _waveOutDevice.Init(_audioFileReader);
            _waveOutDevice.Play();
            _player = db.users
                        .FirstOrDefault(p => p.Id == player);
            _settingsView = new SettingsView(_player, _waveOutDevice, _audioFileReader);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PlayerView_Load(object sender, EventArgs e)
        {
            buttonPress = false;
        }

        public int Run(string LoggedUserId)
        {
            var user = db.users.FirstOrDefault(s => s.Id == LoggedUserId);
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
            return choose;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            choose = 1;
            buttonPress = true;
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            choose = 2;
            buttonPress = true;
            this.Close();
        }

        private void PlayerView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (buttonPress == false)
            {
                choose = 10;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            _settingsView.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            choose = 4;
            buttonPress = true;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            choose = 3;
            buttonPress = true;
            this.Close();
        }
    }
}
