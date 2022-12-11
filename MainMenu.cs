using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Minefield
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }


        // Holds the current soundplayer
        SoundPlayer player;

        /// <summary>
        /// Plays a given soundfile.
        /// </summary>
        /// <param name="soundFile">The name of the soundfile to play</param>
        /// <param name="looping">Whether or not the file should loop</param>
        private void playSound(string soundFile, bool looping)
        {
            if (looping)
            {
                using (player = new SoundPlayer(@$"{soundFile}"))
                {
                    player.Load();
                    player.PlayLooping();
                }
            }
            else
            {
                using (player = new SoundPlayer(@$"{soundFile}"))
                {
                    player.PlaySync();
                }
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            playSound("MainMenu.wav", true);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            playSound("select.wav", false);

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Quit?", "Quit?", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                playSound("MainMenu.wav", true);
            }
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            playSound("select.wav", false);

            var MainGame = new MainGame();
            MainGame.Show();
            this.Hide();
        }

        private void btnLeaderboard_Click(object sender, EventArgs e)
        {
            playSound("select.wav", false);

            var Leaderboard = new Leaderboard();
            Leaderboard.Show();
            this.Hide();
        }

        private void MainMenu_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                playSound("MainMenu.wav", true);
            }
        }
    }
}
