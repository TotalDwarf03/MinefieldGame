using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Minefield
{
    public partial class SubmitScore : Form
    {
        int finalScore;

        public SubmitScore(int score, int timeBonus, int totalScore)
        {
            InitializeComponent();

            // Puts the passed score parts into the UI
            lblScoreVal.Text = score.ToString();
            lblTimeBonusVal.Text = timeBonus.ToString();
            lblTotalScoreVal.Text = totalScore.ToString();

            // Put final score into a global variable for later use
            finalScore = totalScore;
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

        /// <summary>
        /// Adds an animation when displaying the score summary (a 1 second delay between each part showing)
        /// </summary>
        public async void statsAnimation()
        {
            playSound(Minefield.Properties.Resources.scoreLine);
            lblScoreHeading.Visible = true;
            lblScoreVal.Visible = true;

            await Task.Delay(1000);

            playSound(Minefield.Properties.Resources.scoreLine);
            lblTimeBonusHeading.Visible = true;
            lblTimeBonusVal.Visible = true;

            await Task.Delay(1000);

            playSound(Minefield.Properties.Resources.scoreLine);
            lblTotalHeading.Visible = true;
            lblTotalScoreVal.Visible = true;

            await Task.Delay(1000);

            playSound(Minefield.Properties.Resources.scoreLine);
            lblNameHeading.Visible = true;

            lblChar1.Visible = true;
            lblChar2.Visible = true;
            lblChar3.Visible = true;

            btnChar1Up.Visible = true;
            btnChar2Up.Visible = true;
            btnChar3Up.Visible = true;

            btnChar1Down.Visible = true;
            btnChar2Down.Visible = true;
            btnChar3Down.Visible = true;

            await Task.Delay(1000);

            playSound(Minefield.Properties.Resources.scoreTotal);
            btnSubmitScore.Visible = true;
        }

        private void SubmitScore_Load(object sender, EventArgs e)
        {
            statsAnimation();
        }

        /// <summary>
        /// Gets the prefix of a given number
        /// </summary>
        /// <param name="number">The number you want to find the prefix of</param>
        /// <returns>The Prefix</returns>
        private string findNumberPrefix(int number)
        {
            string numAsString = number.ToString();
            switch (numAsString[numAsString.Length - 1].ToString())
            {
                case "1":
                    return "st";
                case "2":
                    return "nd";
                case "3":
                    return "rd";
            }

            return "th";
        }

        // Define alphabet array for spinners
        char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        // Tuple to hold current spinner selection
        Tuple<int, int, int> nameIndexes = new Tuple<int, int, int>(0, 0, 0);

        /// <summary>
        /// Goes to the next character in the alphabet
        /// </summary>
        private void upChar(object sender, EventArgs e)
        {
            playSound(Minefield.Properties.Resources.select);

            // Gets the button which was pressed
            Button button = (Button)sender;
            string buttonName = button.Name;

            //7th character is always the number of the label which it effects
            string characterNo = buttonName[7].ToString();

            // General Case Logic:
            //      if index is within alphabet,
            //          increase index in tuple
            //      otherwise,
            //          set index to 0
            switch (characterNo)
            {
                case "1":
                    if (nameIndexes.Item1 < 25)
                    {
                        nameIndexes = new Tuple<int, int, int>(nameIndexes.Item1 + 1, nameIndexes.Item2, nameIndexes.Item3);
                    }
                    else
                    {
                        nameIndexes = new Tuple<int, int, int>(0, nameIndexes.Item2, nameIndexes.Item3);
                    }
                    break;
                case "2":
                    if (nameIndexes.Item2 < 25)
                    {
                        nameIndexes = new Tuple<int, int, int>(nameIndexes.Item1, nameIndexes.Item2 + 1, nameIndexes.Item3);
                    }
                    else
                    {
                        nameIndexes = new Tuple<int, int, int>(nameIndexes.Item1, 0, nameIndexes.Item3);
                    }
                    break;
                case "3":
                    if (nameIndexes.Item3 < 25)
                    {
                        nameIndexes = new Tuple<int, int, int>(nameIndexes.Item1, nameIndexes.Item2, nameIndexes.Item3 + 1);
                    }
                    else
                    {
                        nameIndexes = new Tuple<int, int, int>(nameIndexes.Item1, nameIndexes.Item2, 0);
                    }
                    break;
            }

            // Update UI to show new character selection
            lblChar1.Text = alphabet[nameIndexes.Item1].ToString();
            lblChar2.Text = alphabet[nameIndexes.Item2].ToString();
            lblChar3.Text = alphabet[nameIndexes.Item3].ToString();
        }


        /// <summary>
        /// Goes to the previous character in the alphabet
        /// </summary>
        private void downChar(object sender, EventArgs e)
        {
            playSound(Minefield.Properties.Resources.select, false);

            // Gets the button which was pressed
            Button button = (Button)sender;
            string buttonName = button.Name;

            //7th character is always the number of the label which it effects
            string characterNo = buttonName[7].ToString();

            // General Case Logic:
            //      if index greater than 0,
            //          decrease index in tuple
            //      otherwise,
            //          set index to 25
            switch (characterNo)
            {
                case "1":
                    if (nameIndexes.Item1 > 0)
                    {
                        nameIndexes = new Tuple<int, int, int>(nameIndexes.Item1 - 1, nameIndexes.Item2, nameIndexes.Item3);
                    }
                    else
                    {
                        nameIndexes = new Tuple<int, int, int>(25, nameIndexes.Item2, nameIndexes.Item3);
                    }
                    break;
                case "2":
                    if (nameIndexes.Item2 > 0)
                    {
                        nameIndexes = new Tuple<int, int, int>(nameIndexes.Item1, nameIndexes.Item2 - 1, nameIndexes.Item3);
                    }
                    else
                    {
                        nameIndexes = new Tuple<int, int, int>(nameIndexes.Item1, 25, nameIndexes.Item3);
                    }
                    break;
                case "3":
                    if (nameIndexes.Item3 > 0)
                    {
                        nameIndexes = new Tuple<int, int, int>(nameIndexes.Item1, nameIndexes.Item2, nameIndexes.Item3 - 1);
                    }
                    else
                    {
                        nameIndexes = new Tuple<int, int, int>(nameIndexes.Item1, nameIndexes.Item2, 25);
                    }
                    break;
            }

            // Update UI to show new character selection
            lblChar1.Text = alphabet[nameIndexes.Item1].ToString();
            lblChar2.Text = alphabet[nameIndexes.Item2].ToString();
            lblChar3.Text = alphabet[nameIndexes.Item3].ToString();
        }

        private void btnSubmitScore_Click(object sender, EventArgs e)
        {
            playSound(Minefield.Properties.Resources.select);

            string contents;

            List<string> names = new List<string>();
            List<string> scores = new List<string>();

            int newScorePosition = -1;

            // Get Inputted Name
            string newName = alphabet[nameIndexes.Item1].ToString() + alphabet[nameIndexes.Item2].ToString() + alphabet[nameIndexes.Item3].ToString();

            // Read Scores.txt to get currently stored names and scores
            using (FileStream f = new FileStream("Scores.txt", FileMode.OpenOrCreate))
            {
                using (StreamReader r = new StreamReader(f))
                {
                    contents = r.ReadLine();
                }
            }

            // Split the data into each entry on the leaderboard
            string[] storedRecords = contents.Split(",");

            // Split each entry into its name and score
            foreach (string element in storedRecords)
            {
                string[] splitElements = element.Split("-");

                names.Add(splitElements[0]);
                scores.Add(splitElements[1]);
            }

            // Find index of new score
            // If new score not bigger than any of the current scores, newScorePosition stays as -1
            for (int i = 0; i < (scores.Count); i++)
            {
                if (Convert.ToInt32(scores[i]) < finalScore)
                {
                    newScorePosition = i;
                    break;
                }
            }

            if (newScorePosition != -1)
            {
                // Moves scores less than the new score to the next index
                for (int j = (scores.Count - 1); j > newScorePosition; j--)
                {
                    scores[j] = scores[j - 1];
                    names[j] = names[j - 1];
                }

                // Inserts new score into the list in the correct position
                scores[newScorePosition] = finalScore.ToString();
                names[newScorePosition] = newName;

                // Reformat names and scores to go back into text file
                string leaderboard = $"{names[0]}-{scores[0]},{names[1]}-{scores[1]},{names[2]}-{scores[2]},{names[3]}-{scores[3]},{names[4]}-{scores[4]}";

                // Write new leaderboard to file
                using (FileStream f = new FileStream("Scores.txt", FileMode.OpenOrCreate))
                {
                    using (StreamWriter s = new StreamWriter(f))
                    {
                        s.WriteLine(leaderboard);

                        playSound(Minefield.Properties.Resources.newHighScore);
                        MessageBox.Show($"Well Done! You made it onto the {newScorePosition + 1}{findNumberPrefix(newScorePosition + 1)} spot on the Leaderboard!", "Congratulations!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Unlucky! You didn't make it on the leaderboard this time!", "Better Luck Next Time!");
            }

            // Go to leaderboard form
            var Leaderboard = new Leaderboard();
            Leaderboard.Show();
            this.Hide();
        }
    }
}
