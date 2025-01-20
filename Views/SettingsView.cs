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
        private IWavePlayer waveOut;
        private AudioFileReader audioFile;

        public SettingsView(HumanPlayer player, IWavePlayer existingWaveOut, AudioFileReader existingAudioFile)
        {
            InitializeComponent();
            waveOut = existingWaveOut;
            audioFile = existingAudioFile;

            InitializePlayerProfile(player);
        }

        private void volumeTrackBar_Scroll(object sender, EventArgs e)
        {
            // Zmiana głośności
            if (waveOut is WaveOutEvent waveOutEvent)
            {
                waveOutEvent.Volume = volumeTrackBar.Value / 100f;
                volumeLabel.Text = $"Głośność: {volumeTrackBar.Value}%";
            }
        }
        private void InitializePlayerProfile(HumanPlayer player)
        {
            nameLabel.Text = $"Nazwa gracza: {player.name}";
            ratingLabel.Text = $"Punkty rankingowe: {player.raitingPoints}";
            levelLabel.Text = $"Poziom: {player.level.level}";
            expLabel.Text = $"Doświadczenie: {player.level.exp}/{player.level.expToNextLevel}";
        }
        private void InitializeVolumeControl()
        {
            // Ustawienie suwaka głośności na aktualną wartość
            volumeTrackBar.Value = (int)(waveOut.Volume * 100);
            volumeLabel.Text = $"Głośność: {volumeTrackBar.Value}%";
        }
    }
}
