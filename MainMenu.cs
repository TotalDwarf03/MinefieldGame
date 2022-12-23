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
using System.IO;

namespace Minefield
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

            // If Scores and Settings text files do not exist in the current build, make them using the resource versions

            if (File.Exists("Scores.txt") == false)
            {
                using (FileStream f = new FileStream("Scores.txt", FileMode.OpenOrCreate))
                {
                    using (StreamWriter s = new StreamWriter(f))
                    {
                        s.WriteLine(Minefield.Properties.Resources.Scores);
                    }
                }
            }

            if (File.Exists("Settings.txt") == false)
            {
                using (FileStream f = new FileStream("Settings.txt", FileMode.OpenOrCreate))
                {
                    using (StreamWriter s = new StreamWriter(f))
                    {
                        s.WriteLine(Minefield.Properties.Resources.Settings);
                    }
                }
            }
        }


        // Initialises the sound player in global scope
        SoundPlayer player;

        /// <summary>
        /// Plays a given soundfile.
        /// </summary>
        /// <param name="soundFile">The name of the soundfile to play</param>
        /// <param name="looping">Whether or not the file should loop (Default: false)</param>
        /// <param name="sync">Whether the file should play synchronous (Default: false)</param>
        private void playSound(UnmanagedMemoryStream soundFile, bool looping = false, bool sync = false)
        {
            if (looping)
            {
                using (player = new SoundPlayer(soundFile))
                {
                    player.Load();
                    player.PlayLooping();
                }
            }
            else
            {
                using (player = new SoundPlayer(soundFile))
                {
                    if (sync == false)
                    {
                        player.Stream.Position = 0;
                        player.Play();
                    }
                    else
                    {
                        player.Stream.Position = 0;
                        player.PlaySync();
                    }
                }
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            playSound(Minefield.Properties.Resources.MainMenu, true);
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            playSound(Minefield.Properties.Resources.select);

            // Load MainGame Form
            var MainGame = new MainGame();
            MainGame.Show();
            this.Hide();
        }

        private void btnLeaderboard_Click(object sender, EventArgs e)
        {
            playSound(Minefield.Properties.Resources.select, false, true);

            // Load Leaderboard Form
            var Leaderboard = new Leaderboard();
            Leaderboard.Show();
            this.Hide();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            playSound(Minefield.Properties.Resources.select);

            // Load Settings Form
            var Settings = new Settings();
            Settings.Show();
            this.Hide();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            playSound(Minefield.Properties.Resources.select);

            // Show yes/no message box, if yes, Exit the application, if no, Stay on Main Menu
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Quit?", "Quit?", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                playSound(Minefield.Properties.Resources.MainMenu, true);
            }
        }

        private void MainMenu_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                playSound(Minefield.Properties.Resources.MainMenu, true);
            }
        }
    }
}
