using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Microsoft.VisualBasic;

namespace Minefield
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        // Holds all Gamemode names and descriptions

        // Search - Explored squares disappear over time
        // Flag - Explored squares stay uncovered. Squares can be clicked to be marked as a bomb

        string[,] Gamemodes = { { "Search", "The further you go, the less you remember, a true test of memory and skill!" }, { "Flag", "Plan your way through the minefield, making notes of bomb sites throughout the baron desert!" } };

        Bitmap[] GamemodeIcons = { Minefield.Properties.Resources.searchGameType, Minefield.Properties.Resources.flagGameType };

        // Holds all Loadout names and descriptions

        // Arsonist - Adds a search ability which reveals all tiles within a 2 block radius
        // Ninja - Adds a dash ability which makes the user move 3 tiles in their previously moved direction. Any bombs which are dashed over are not set off (apart from if you land on one at the end)

        string[,] Loadouts = { { "Arsonist", "Use your love for pyrotechnics to light up the nearby area!" }, { "Ninja", "Put your cutting edge agility to use and dash through the sand!" } };

        Bitmap[] LoadoutIcons = { Minefield.Properties.Resources.arsonistLoadType, Minefield.Properties.Resources.ninjaLoadType };

        UnmanagedMemoryStream[] LoadoutSounds = { Minefield.Properties.Resources.IgniteCrop, Minefield.Properties.Resources.Dash };

        // Indexes to determine current gamemode and loadout

        int gamemodeIndex;
        int loadoutIndex;

        // Holds the current soundplayer
        SoundPlayer player;

        /// <summary>
        /// Plays a given soundfile.
        /// </summary>
        /// <param name="soundFile">The name of the soundfile to play</param>
        /// <param name="looping">Whether or not the file should loop</param>
        private void playSound(UnmanagedMemoryStream soundFile, bool looping)
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
                    player.Stream.Position = 0;
                    player.Play();
                }
            }
        }

        private void UpdateSettingsFile()
        {
            string newString = $"gametype-{Gamemodes[gamemodeIndex, 0]},loadout-{Loadouts[loadoutIndex, 0]}";

            using (FileStream f = new FileStream("Settings.txt", FileMode.OpenOrCreate))
            {
                using (StreamWriter s = new StreamWriter(f))
                {
                    s.WriteLine(newString);
                }
            }
        }

        /// <summary>
        /// Gets the current settings from Settings.txt and updates the UI accordingly
        /// </summary>
        private void UpdateSettingsUI()
        {
            string contents;

            List<string> SettingValues = new List<string>();

            string curGamemode;
            string curLoadout;

            using (FileStream f = new FileStream("Settings.txt", FileMode.OpenOrCreate))
            {
                using (StreamReader r = new StreamReader(f))
                {
                    contents = r.ReadLine();
                }
            }

            string[] options = contents.Split(",");

            foreach (string option in options)
            {
                string[] splitElements = option.Split("-");

                // Add 2nd element in array to list as that is the value of the setting (<SettingName>-<SettingValue>) from Settings.txt
                SettingValues.Add(splitElements[1]);
            }

            curGamemode = SettingValues[0];
            curLoadout = SettingValues[1];

            for (int i = 0; i < Gamemodes.Length / 2; i++)
            {
                if (curGamemode == Gamemodes[i, 0])
                {
                    gamemodeIndex = i;
                }
            }

            for (int i = 0; i < Loadouts.Length / 2; i++)
            {
                if (curLoadout == Loadouts[i, 0])
                {
                    loadoutIndex = i;
                }
            }

            lblGameTypeVal.Text = Gamemodes[gamemodeIndex, 0];
            lblGameTypeDesc.Text = Gamemodes[gamemodeIndex, 1];
            pbGameIcon.BackgroundImage = GamemodeIcons[gamemodeIndex];

            lblLoadTypeVal.Text = Loadouts[loadoutIndex, 0];
            lblLoadTypeDesc.Text = Loadouts[loadoutIndex, 1];
            pbLoadIcon.BackgroundImage = LoadoutIcons[loadoutIndex];
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            UpdateSettingsUI();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            foreach(Form form in Application.OpenForms)
            {
                form.Show();
            }

            this.Close();
        }

        private void pbGameIcon_Click(object sender, EventArgs e)
        {
            if (gamemodeIndex == (Gamemodes.Length / 2) - 1)
            {
                gamemodeIndex = 0;
            }
            else
            {
                gamemodeIndex += 1;
            }

            playSound(Minefield.Properties.Resources.select, false);

            UpdateSettingsFile();
            UpdateSettingsUI();
        }

        private void pbLoadIcon_Click(object sender, EventArgs e)
        {
            if (loadoutIndex == (Loadouts.Length / 2) - 1)
            {
                loadoutIndex = 0;
            }
            else
            {
                loadoutIndex += 1;
            }

            playSound(LoadoutSounds[loadoutIndex], false);

            UpdateSettingsFile();
            UpdateSettingsUI();
        }
    }
}
