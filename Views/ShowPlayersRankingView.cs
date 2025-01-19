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
    public partial class ShowPlayersRankingView : Form
    {
        MyDbContext db;
        public ShowPlayersRankingView(MyDbContext db)
        {
            InitializeComponent();
            this.db = db; 
            LoadRanking();
        }
        private void LoadRanking()
        {
            // Pobieramy graczy z bazy danych i sortujemy ich po punktach rankingowych
            var players = db.users
                            .OrderByDescending(p => p.raitingPoints)  // Sortowanie malejąco po punktach
                            .ToList();

            dataGridView1.Columns.Add("Rank", "Pozycja");
            dataGridView1.Columns.Add("Name", "Nazwa gracza");
            dataGridView1.Columns.Add("Points", "Punkty rankingowe");
            dataGridView1.Columns.Add("Level", "Poziom");

            // Wypełnienie danych w tabeli
            for (int i = 0; i < players.Count; i++)
            {
                var player = players[i];
                dataGridView1.Rows.Add(i + 1, player.name, player.raitingPoints, player.level.level);
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true; // Tabela tylko do odczytu
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
        }

    }
}
