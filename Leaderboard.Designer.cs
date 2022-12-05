namespace Minefield
{
    partial class Leaderboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Leaderboard));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblLeaderboard = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Minefield.Properties.Resources.leaderboardlogo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(229, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(343, 179);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblLeaderboard
            // 
            this.lblLeaderboard.BackColor = System.Drawing.Color.Transparent;
            this.lblLeaderboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLeaderboard.ForeColor = System.Drawing.Color.White;
            this.lblLeaderboard.Location = new System.Drawing.Point(229, 194);
            this.lblLeaderboard.Name = "lblLeaderboard";
            this.lblLeaderboard.Size = new System.Drawing.Size(343, 297);
            this.lblLeaderboard.TabIndex = 1;
            this.lblLeaderboard.Text = "1 - AAA - 000\r\n2 - BBB - 000\r\n3 - CCC - 000\r\n4 - DDD - 000\r\n5 - EEE - 000\r\n";
            this.lblLeaderboard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Leaderboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Minefield.Properties.Resources.leaderboardBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.lblLeaderboard);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Leaderboard";
            this.Text = "Minefield: Can you get to the end?";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblLeaderboard;
    }
}