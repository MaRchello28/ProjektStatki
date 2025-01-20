using ProjektStatki.Models;
using ProjektStatki.Models.ElementsToUnlock;
using ProjektStatki.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ProjektStatki.Views;

namespace ProjektStatki
{
    public partial class MainMenu : Form
    {
        private string login;
        private string password;
        protected HumanPlayer humanPlayer;
        private CreateAccountView create;
        private List<Element> elements = new List<Element>();
        private MyDbContext db;

        public MainMenu(MyDbContext db)
        {
            InitializeComponent();
            this.db = db;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.InitElements();
            _presenter = new MainMenuPresenter(this, db);  // Zainicjalizowanie prezentera
        }

        private readonly MainMenuPresenter _presenter;

        public string Login { get { return textBox1.Text; } }
        public string Password { get { return textBox2.Text; } }

        public event EventHandler LoginClicked;
        public event EventHandler CreateAccountClicked;

        public void InitElements()
        {
            elements.Add(new SkinElement("Skin", 4, "Pink"));
            elements.Add(new GameModeElement("GameMode", 6, "Specjalne Statki"));
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void OpenPlayerView(HumanPlayer humanPlayer, List<Element> elements)
        {
            var playerView = new PlayerView(db, humanPlayer.name, elements);
            playerView.Run(humanPlayer.name);
        }

        private void button1_Click(object sender, EventArgs e) // Zaloguj
        {
            LoginClicked?.Invoke(this, EventArgs.Empty);
        }

        private void button2_Click(object sender, EventArgs e) // Utwórz
        {
            CreateAccountClicked?.Invoke(this, EventArgs.Empty);
        }

        public string Run()
        {
            this.ShowDialog();
            return humanPlayer.Id;
        }

        // Presenter
        public class MainMenuPresenter
        {
            private readonly MainMenu _view;
            private readonly MyDbContext _db;
            private List<Element> _elements;

            public MainMenuPresenter(MainMenu view, MyDbContext db)
            {
                _view = view;
                _db = db;
                _elements = new List<Element>();
                _view.LoginClicked += OnLoginClicked;
                _view.CreateAccountClicked += OnCreateAccountClicked;
                InitElements();
            }

            private void InitElements()
            {
                _elements.Add(new SkinElement("Skin", 4, "Pink"));
                _elements.Add(new GameModeElement("GameMode", 6, "Specjalne Statki"));
            }

            private void OnLoginClicked(object sender, EventArgs e)
            {
                var login = _view.Login;
                var password = _view.Password;

                var user = _db.users.FirstOrDefault(u => u.name == login && u.password == password);

                if (user != null)
                {
                    var humanPlayer = user;
                    _view.OpenPlayerView(humanPlayer, _elements);
                }
                else
                {
                    _view.ShowMessage("Nie znaleziono u¿ytkownika");
                }
            }

            private void OnCreateAccountClicked(object sender, EventArgs e)
            {
                var createAccountView = new CreateAccountView(_view, _db);
                _view.Hide();
                createAccountView.ShowDialog();
            }
        }

        // Interfejs widoku
        public interface IMainMenuView
        {
            string Login { get; }
            string Password { get; }
            event EventHandler LoginClicked;
            event EventHandler CreateAccountClicked;

            void ShowMessage(string message);
            void OpenPlayerView(HumanPlayer humanPlayer, List<Element> elements);
        }
    }
}
