using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minefield
{
    public partial class SubmitScore : Form
    {
        public SubmitScore(int score, int timeBonus, int totalScore)
        {
            InitializeComponent();

            lblScoreVal.Text = score.ToString();
            lblTimeBonusVal.Text = timeBonus.ToString();
            lblTotalScoreVal.Text = totalScore.ToString();
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
    }
}
