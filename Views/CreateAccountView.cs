using ProjektStatki.Models.Builder;
using ProjektStatki.Models.Data;
using System;
using System.Windows.Forms;

namespace ProjektStatki.Views
{
    public partial class CreateAccountView : Form
    {
        private CreateAccountPresenter presenter;
        private MainMenu menu;

        public CreateAccountView(MainMenu mainMenu, MyDbContext db)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            presenter = new CreateAccountPresenter(this, mainMenu, db);
            menu = new MainMenu(db);
        }

        // Metoda wywoływana po załadowaniu formularza
        private void CreateAccountView_Load(object sender, EventArgs e)
        {
            // Inicjalizacja lub ustawienie elementów, jeśli wymagane
        }

        // Obsługuje kliknięcie przycisku tworzenia konta
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string password = textBox2.Text;
            string password2 = textBox3.Text;
            presenter.CreateAccount(name, password, password2);
        }

        // Obsługuje kliknięcie przycisku zamknięcia okna
        private void button2_Click(object sender, EventArgs e)
        {
            presenter.CloseView();
        }

        // Metody do interakcji z widokiem
        public string GetPlayerName()
        {
            return textBox1.Text;
        }

        public string GetPassword()
        {
            return textBox2.Text;
        }

        public string GetPassword2()
        {
            return textBox3.Text;
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowMainMenu()
        {
            this.Close();
            // Zakładając, że mainMenu to obiekt Form, można go pokazać:
            menu.Show();
        }
    }

    public class CreateAccountPresenter
    {
        private readonly CreateAccountView view;
        private readonly MainMenu mainMenu;
        private readonly MyDbContext db;
        private HumanPlayerBuilder playerBuilder;
        private PlayerDirector playerDirector;

        public CreateAccountPresenter(CreateAccountView view, MainMenu mainMenu, MyDbContext db)
        {
            this.view = view;
            this.mainMenu = mainMenu;
            this.db = db;
            this.playerBuilder = new HumanPlayerBuilder();
            this.playerDirector = new PlayerDirector(playerBuilder);
        }

        public void CreateAccount(string name, string password, string password2)
        {
            // Walidacja nazwiska i hasła
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(password2))
            {
                view.ShowErrorMessage("Wszystkie pola muszą być wypełnione.");
                return;
            }

            if (password != password2)
            {
                view.ShowErrorMessage("Hasła muszą się zgadzać.");
                return;
            }

            // Budowanie gracza
            playerBuilder.GetPasswordFromTextBox(password);
            playerBuilder.GetPassword2FromTextBox(password2);
            playerDirector.BuildPlayer(name);

            // Można tu dodać zapisanie gracza do bazy danych, jeśli jest taka potrzeba
            db.SaveChanges();

            // Przekierowanie do menu głównego
            view.ShowMainMenu();
        }

        public void CloseView()
        {
            view.Close();
            mainMenu.Show();
        }
    }
}