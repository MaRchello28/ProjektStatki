using NAudio.Wave;
using ProjektStatki.Models;
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
    public partial class SettingsView : Form
    {
        private WaveOutEvent waveOut;
        private AudioFileReader audioFile;

        public SettingsView(HumanPlayer player)
        {
            InitializeComponent();
            InitializePlayerProfile(player);
            InitializeAudio();
        }

        private void volumeTrackBar_Scroll(object sender, EventArgs e)
        {
            volumeLabel.Text = $"Głośność: {volumeTrackBar.Value}%";
            audioFile.Volume = volumeTrackBar.Value / 100f;
        }
        private void InitializePlayerProfile(HumanPlayer player)
        {
            nameLabel.Text = $"Nazwa gracza: {player.name}";
            ratingLabel.Text = $"Punkty rankingowe: {player.raitingPoints}";
            levelLabel.Text = $"Poziom: {player.level.level}";
            expLabel.Text = $"Doświadczenie: {player.level.exp}/{player.level.expToNextLevel}";
        }
        private void InitializeAudio()
        {
            // Tymczasowy plik z zasobu
            string tempFilePath = Path.GetTempFileName() + ".mp3";
            File.WriteAllBytes(tempFilePath, Properties.Resources.MuzyczkaMArio);

            waveOut = new WaveOutEvent();
            audioFile = new AudioFileReader(tempFilePath);
            waveOut.Init(audioFile);
            waveOut.Play();
        }
    }
}
