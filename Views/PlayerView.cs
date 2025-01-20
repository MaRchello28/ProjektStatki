using ProjektStatki.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NAudio.Wave;
using ProjektStatki.Models;
using ProjektStatki.Models.Gamemodes;
using ProjektStatki.Models.ElementsToUnlock;

namespace ProjektStatki.Views
{
    public partial class PlayerView : Form
    {
        private MyDbContext db;
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

            // Audio setup
            var tempFile = System.IO.Path.GetTempFileName();
            System.IO.File.WriteAllBytes(tempFile, Properties.Resources._02_Title_Theme);
            _waveOutDevice = new WaveOutEvent();
            _audioFileReader = new AudioFileReader(tempFile);
            _waveOutDevice.Init(_audioFileReader);
            _waveOutDevice.Play();

            // Initializing subviews
            _player = db.users.FirstOrDefault(p => p.name == player);
            _settingsView = new SettingsView(_player, _waveOutDevice, _audioFileReader);
            gameModeView = new ChooseGameModeView(db, _player.Id);
            historyView = new HistoryView(db, _player.Id);
            ShowContentView = new ShowContentView(elements);
            showPlayersRankingView = new ShowPlayersRankingView(db);

            // Bind presenter to view
            var presenter = new PlayerViewPresenter(this, db, _player, _settingsView, gameModeView, historyView, ShowContentView, showPlayersRankingView);
            presenter.Initialize();
        }

        private void PlayerView_Load(object sender, EventArgs e)
        {
            buttonPress = false;
        }

        public void SetUserData(string username, int progress, int level)
        {
            label2.Text = username;
            progressBar1.Value = progress;
            label1.Text = level.ToString();
        }

        public void ShowDialogForGameMode()
        {
            gameModeView.ShowDialog();
        }

        public void ShowDialogForHistory()
        {
            historyView.ShowDialog();
        }

        public void ShowDialogForContent()
        {
            ShowContentView.ShowDialog();
        }

        public void ShowDialogForPlayersRanking()
        {
            showPlayersRankingView.ShowDialog();
        }

        public void CloseView()
        {
            this.Close();
        }

        private void PlayerView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!buttonPress)
            {
                buttonPress = true;
                // Default action when the form is closing without a button press
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
                // Calculate progress bar and display user data
                int progresbarExp = 100 * user.level.exp / user.level.expToNextLevel;
                SetUserData(user.name, progresbarExp, user.level.level);
                this.ShowDialog();
            }
            return 10; // Default value (for example)
        }

        // Buttons for specific actions
        private void button1_Click(object sender, EventArgs e)
        {
            buttonPress = true;
            new PlayerViewPresenter(this, db, _player, _settingsView, gameModeView, historyView, ShowContentView, showPlayersRankingView).SelectOption(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonPress = true;
            new PlayerViewPresenter(this, db, _player, _settingsView, gameModeView, historyView, ShowContentView, showPlayersRankingView).SelectOption(2);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            _settingsView.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            buttonPress = true;
            new PlayerViewPresenter(this, db, _player, _settingsView, gameModeView, historyView, ShowContentView, showPlayersRankingView).SelectOption(4);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buttonPress = true;
            new PlayerViewPresenter(this, db, _player, _settingsView, gameModeView, historyView, ShowContentView, showPlayersRankingView).SelectOption(3);
        }
    }

    // Presenter class that handles the logic
    public class PlayerViewPresenter
    {
        private readonly PlayerView _view;
        private readonly MyDbContext _db;
        private readonly HumanPlayer _player;
        private readonly SettingsView _settingsView;
        private readonly ChooseGameModeView _gameModeView;
        private readonly HistoryView _historyView;
        private readonly ShowContentView _showContentView;
        private readonly ShowPlayersRankingView _showPlayersRankingView;

        public PlayerViewPresenter(
            PlayerView view,
            MyDbContext db,
            HumanPlayer player,
            SettingsView settingsView,
            ChooseGameModeView gameModeView,
            HistoryView historyView,
            ShowContentView showContentView,
            ShowPlayersRankingView showPlayersRankingView)
        {
            _view = view;
            _db = db;
            _player = player;
            _settingsView = settingsView;
            _gameModeView = gameModeView;
            _historyView = historyView;
            _showContentView = showContentView;
            _showPlayersRankingView = showPlayersRankingView;
        }

        public void Initialize()
        {
            // Setup initial actions
        }

        public void SelectOption(int choose)
        {
            switch (choose)
            {
                case 1:
                    _view.ShowDialogForGameMode();
                    GameMode selectedGameMode = _gameModeView.ChoseGamemode();
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
                    _view.ShowDialogForHistory();
                    break;
                case 3:
                    _view.ShowDialogForContent();
                    break;
                case 4:
                    _view.ShowDialogForPlayersRanking();
                    break;
                default:
                    _view.CloseView();
                    break;
            }
        }

        public void CreateGame(GameMode gameMode)
        {
            if (_gameModeView.Enemy() != null)
            {
                Player player1 = _gameModeView.Player1() ?? _player;
                Game game = new Game(gameMode.board1, gameMode.board2, gameMode, player1, _gameModeView.Enemy());
                GameView gameView = new GameView(game, _db);
                gameView.ShowDialog();
            }
        }
    }
}