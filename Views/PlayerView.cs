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
using ProjektStatki.Models.Gamemodes;
using ProjektStatki.Models.ElementsToUnlock;

namespace ProjektStatki.Views
{
    public partial class PlayerView : Form
    {
        MyDbContext db;
        public int choose = 10;
        private IWavePlayer _waveOutDevice;
        private AudioFileReader _audioFileReader;
        private bool buttonPress = false;
        private HumanPlayer _player;
        private SettingsView _settingsView;
        private ChooseGameModeView gameModeView;
        private HistoryView historyView;
        private ShowContentView ShowContentView;
        private ShowPlayersRankingView showPlayersRankingView;
        public PlayerView(MyDbContext db, string player, List<Element> elements)
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
                        .FirstOrDefault(p => p.name == player);
            _settingsView = new SettingsView(_player, _waveOutDevice, _audioFileReader);
            gameModeView = new ChooseGameModeView(db, _player.Id);
            historyView = new HistoryView(db, _player.Id);
            ShowContentView = new ShowContentView(elements);
            showPlayersRankingView = new ShowPlayersRankingView(db);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PlayerView_Load(object sender, EventArgs e)
        {
            buttonPress = false;
        }

        public Game InitGame(GameMode gamemode, Player player2)
        {
            Player player1;
            if (gamemode.board1.player == null)
            {
                player1 = db.users.FirstOrDefault(u => u.Id == _player.Id);
                Game game = new Game(gamemode.board1, gamemode.board2, gamemode, player1, player2);
                return game;
            }
            else
            {
                player1 = gamemode.board1.player;
                Game game = new Game(gamemode.board1, gamemode.board2, gamemode, player1, player2);
                return game;
            }
        }

        public void CreateGame(GameMode gameMode)
        {
            if (gameModeView.Enemy() != null)
            {
                if (gameModeView.Player1() == null)
                {
                    Game game = InitGame(gameMode, gameModeView.Enemy());
                    GameView gameView = new GameView(game, db);
                    gameView.ShowDialog();
                }
                else
                {
                    Game game = InitGame(gameMode, gameModeView.Enemy());
                    GameView gameView = new GameView(game, db);
                    gameView.ShowDialog();
                }
            }

        }

        public void SelectOption(int choose)
        {
            switch (choose)
            {
                case 1:
                    gameModeView.ShowDialog();
                    GameMode selectedGameMode = gameModeView.ChoseGamemode();
                    if (selectedGameMode != null)
                    {
                        CreateGame(selectedGameMode);
                    }
                    else
                    {
                        MessageBox.Show("Nie wybrano trybu gry.");
                    }
                    break;
                case 2:
                    historyView.ShowDialog();
                    break;
                case 3:
                    ShowContentView.ShowDialog();
                    break;
                case 4:
                    showPlayersRankingView.ShowDialog();
                    break;
                default:
                    this.Close();
                    break;
            }
        }

        public int Run(string LoggedUserId)
        {
            var user = db.users.FirstOrDefault(s => s.name == LoggedUserId);
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
            SelectOption(1);
            buttonPress = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectOption(2);
            buttonPress = true;
        }

        private void PlayerView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (buttonPress == false)
            {
                SelectOption(10);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            _settingsView.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SelectOption(4);
            buttonPress = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SelectOption(3);
            buttonPress = true;
        }
    }
}
