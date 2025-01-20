using ProjektStatki.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProjektStatki.Views
{
    public partial class ShowPlayersRankingView : Form
    {
        private ShowPlayersRankingPresenter presenter;

        public ShowPlayersRankingView(MyDbContext db)
        {
            InitializeComponent();
            presenter = new ShowPlayersRankingPresenter(this, db);
            presenter.LoadRanking();
        }

        public void DisplayRanking(List<(int Rank, string Name, int Points, int Level)> players)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Rank", "Pozycja");
            dataGridView1.Columns.Add("Name", "Nazwa gracza");
            dataGridView1.Columns.Add("Points", "Punkty rankingowe");
            dataGridView1.Columns.Add("Level", "Poziom");

            foreach (var player in players)
            {
                dataGridView1.Rows.Add(player.Rank, player.Name, player.Points, player.Level);
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true; // Tabela tylko do odczytu
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
        }
    }

    public class ShowPlayersRankingPresenter
    {
        private readonly ShowPlayersRankingView view;
        private readonly MyDbContext db;

        public ShowPlayersRankingPresenter(ShowPlayersRankingView view, MyDbContext db)
        {
            this.view = view;
            this.db = db;
        }

        public void LoadRanking()
        {
            // Pobieramy graczy z bazy danych i sortujemy ich po punktach rankingowych
            var players = db.users
                            .OrderByDescending(p => p.raitingPoints)  // Sortowanie malejąco po punktach
                            .Select((player, index) => new
                            {
                                Rank = index + 1,
                                Name = player.name,
                                Points = player.raitingPoints,
                                Level = player.level.level
                            })
                            .ToList();

            var rankingData = players.Select(p => (p.Rank, p.Name, p.Points, p.Level)).ToList();

            // Wyświetlamy dane w widoku
            view.DisplayRanking(rankingData);
        }
    }
}
