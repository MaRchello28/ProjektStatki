using ProjektStatki.Models;
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
    public partial class HistoryView : Form
    {
        MyDbContext db;
        string playerId;
        public HistoryView(MyDbContext db, string playerId)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.db = db;
            this.playerId = playerId;
        }

        private void HistoryView_Load(object sender, EventArgs e)
        {
            DataGridView dgvHistory = new DataGridView
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new Size(760, 400),
                AutoGenerateColumns = false,
                ReadOnly = true
            };

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Przeciwnik",
                DataPropertyName = "OpponentName",
                Width = 200
            });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Rezultat",
                DataPropertyName = "Result",
                Width = 150
            });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Data rozgrywki",
                DataPropertyName = "GameDate",
                Width = 200
            });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tryb gry",
                DataPropertyName = "GameModeName",
                Width = 200
            });
            var historyData = db.gameHistory.Where(item => item.Player1ID == playerId || item.Player2ID == playerId).ToList();
            dgvHistory.DataSource = historyData;
            Controls.Add(dgvHistory);
        }


    }
}
