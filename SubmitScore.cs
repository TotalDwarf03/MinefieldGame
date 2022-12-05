using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minefield
{
    public partial class SubmitScore : Form
    {
        int finalScore;

        public SubmitScore(int score, int timeBonus, int totalScore)
        {
            InitializeComponent();

            lblScoreVal.Text = score.ToString();
            lblTimeBonusVal.Text = timeBonus.ToString();
            lblTotalScoreVal.Text = totalScore.ToString();

            finalScore = totalScore;
        }

        public async void statsAnimation()
        {
            lblScoreHeading.Visible = true;
            lblScoreVal.Visible = true;

            await Task.Delay(1000);

            lblTimeBonusHeading.Visible = true;
            lblTimeBonusVal.Visible = true;

            await Task.Delay(1000);

            lblTotalHeading.Visible = true;
            lblTotalScoreVal.Visible = true;

            await Task.Delay(1000);

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

            btnSubmitScore.Visible = true;
        }

        private void SubmitScore_Load(object sender, EventArgs e)
        {
            statsAnimation();
        }

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

        char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        Tuple<int, int, int> nameIndexes = new Tuple<int, int, int>(0, 0, 0);

        private void upChar(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonName = button.Name;

            //7th character is always the number of the label which it effects
            string characterNo = buttonName[7].ToString();

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

            lblChar1.Text = alphabet[nameIndexes.Item1].ToString();
            lblChar2.Text = alphabet[nameIndexes.Item2].ToString();
            lblChar3.Text = alphabet[nameIndexes.Item3].ToString();
        }

        private void downChar(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonName = button.Name;

            //7th character is always the number of the label which it effects
            string characterNo = buttonName[7].ToString();

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

            lblChar1.Text = alphabet[nameIndexes.Item1].ToString();
            lblChar2.Text = alphabet[nameIndexes.Item2].ToString();
            lblChar3.Text = alphabet[nameIndexes.Item3].ToString();
        }

        private void btnSubmitScore_Click(object sender, EventArgs e)
        {
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
            for (int i = 0; i < (scores.Count - 1); i++)
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


                        MessageBox.Show($"Well Done! You made it onto the {newScorePosition + 1}{findNumberPrefix(newScorePosition + 1)} spot on the Leaderboard!", "Congratulations!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Unlucky! You didn't make it on the leaderboard this time!", "Better Luck Next Time!");
            }

            var Leaderboard = new Leaderboard();
            Leaderboard.Show();
            this.Hide();
        }
    }
}
