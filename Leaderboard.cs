using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Reflection;

namespace Minefield
{
    public partial class Leaderboard : Form
    {
        public Leaderboard()
        {
            InitializeComponent();
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

        private void Leaderboard_Load(object sender, EventArgs e)
        {
            string contents;

            List<string> scoreParts = new List<string>();

            // Get the contents of Scores.txt using a StreamReader
            using (FileStream f = new FileStream("Scores.txt", FileMode.OpenOrCreate))
            {
                using (StreamReader r = new StreamReader(f))
                {
                    contents = r.ReadLine();
                }
            }

            // Split the contents by commas to get each score entry
            string[] scores = contents.Split(",");

            // For each score entry, split it on hyphens to get the Player's name and Score
            foreach (string element in scores)
            {
                string[] splitElements = element.Split("-");

                scoreParts.Add(splitElements[0]);
                scoreParts.Add(splitElements[1]);
            }

            // Format the file contents into a string
            string leaderboard = @$"1 - {scoreParts[0]} - {scoreParts[1]}{System.Environment.NewLine}2 - {scoreParts[2]} - {scoreParts[3]}{System.Environment.NewLine}3 - {scoreParts[4]} - {scoreParts[5]}{System.Environment.NewLine}4 - {scoreParts[6]} - {scoreParts[7]}{System.Environment.NewLine}5 - {scoreParts[8]} - {scoreParts[9]}{System.Environment.NewLine}";

            // Update Leaderboard label
            lblLeaderboard.Text = leaderboard;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            List<Form> formsToClose = new List<Form>();

            playSound(Minefield.Properties.Resources.select, false, true);

            // Identify which forms other than the MainMenu are open in the background (not visible)
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name != "MainMenu")
                {
                    formsToClose.Add(form);
                }
                else
                {
                    form.Show();
                }
            }

            // Close the open forms
            foreach (Form form in formsToClose)
            {
                form.Close();
            }
        }

        private void Leaderboard_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                playSound(Minefield.Properties.Resources.Leaderboard, true);
            }
        }
    }
}
