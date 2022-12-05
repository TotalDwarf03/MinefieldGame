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

namespace Minefield
{
    public partial class Leaderboard : Form
    {
        public Leaderboard()
        {
            InitializeComponent();
        }

        private void Leaderboard_Load(object sender, EventArgs e)
        {
            string contents;

            List<string> scoreParts = new List<string>();

            using (FileStream f = new FileStream("Scores.txt", FileMode.OpenOrCreate))
            {
                using (StreamReader r = new StreamReader(f))
                {
                    contents = r.ReadLine();
                }
            }

            string[] scores = contents.Split(",");

            foreach (string element in scores)
            {
                string[] splitElements = element.Split("-");

                scoreParts.Add(splitElements[0]);
                scoreParts.Add(splitElements[1]);
            }

            string leaderboard = @$"1 - {scoreParts[0]} - {scoreParts[1]}{System.Environment.NewLine}2 - {scoreParts[2]} - {scoreParts[3]}{System.Environment.NewLine}3 - {scoreParts[4]} - {scoreParts[5]}{System.Environment.NewLine}4 - {scoreParts[6]} - {scoreParts[7]}{System.Environment.NewLine}5 - {scoreParts[8]} - {scoreParts[9]}{System.Environment.NewLine}";

            lblLeaderboard.Text = leaderboard;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            List<Form> formsToClose = new List<Form>();

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
    }
}
