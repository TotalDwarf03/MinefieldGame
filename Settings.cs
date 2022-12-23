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

        /// <summary>
        /// Adds the new Gamemode and Loadout Selection to Settings.txt
        /// </summary>
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

            // Using a StreamReader, get the contents of Settings.txt
            using (FileStream f = new FileStream("Settings.txt", FileMode.OpenOrCreate))
            {
                using (StreamReader r = new StreamReader(f))
                {
                    contents = r.ReadLine();
                }
            }

            // Split the contents of the text file into each option (separated by commas)
            string[] options = contents.Split(",");

            // For each option from Settings.txt,
            // Split it on hyphens
            // This is to split the setting's label and value
            foreach (string option in options)
            {
                string[] splitElements = option.Split("-");

                // Add 2nd element in array to list as that is the value of the setting (<SettingName>-<SettingValue>) from Settings.txt
                SettingValues.Add(splitElements[1]);
            }

            // Set current Gamemode and Loadout to the Setting's value
            curGamemode = SettingValues[0];
            curLoadout = SettingValues[1];

            // Get the indexes of both the Gamemode and Loadout so assets can be loaded correctly
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

            // Update the UI with loaded values
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
            // Go back to Main Menu
            foreach(Form form in Application.OpenForms)
            {
                form.Show();
            }

            this.Close();
        }

        private void pbGameIcon_Click(object sender, EventArgs e)
        {
            // If at the end of the Gamemode list, set index to 0, otherwise, increment it by 1
            if (gamemodeIndex == (Gamemodes.Length / 2) - 1)
            {
                gamemodeIndex = 0;
            }
            else
            {
                gamemodeIndex += 1;
            }

            playSound(Minefield.Properties.Resources.select);

            UpdateSettingsFile();
            UpdateSettingsUI();
        }

        private void pbLoadIcon_Click(object sender, EventArgs e)
        {
            // If at the end of the Loadouts list, set index to 0, otherwise, increment it by 1
            if (loadoutIndex == (Loadouts.Length / 2) - 1)
            {
                loadoutIndex = 0;
            }
            else
            {
                loadoutIndex += 1;
            }

            playSound(LoadoutSounds[loadoutIndex]);

            UpdateSettingsFile();
            UpdateSettingsUI();
        }
    }
}
