namespace Minefield
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.lblGameTypeHeading = new System.Windows.Forms.Label();
            this.lblLoadTypeHeading = new System.Windows.Forms.Label();
            this.pbGameIcon = new System.Windows.Forms.PictureBox();
            this.pbLoadIcon = new System.Windows.Forms.PictureBox();
            this.lblGameTypeVal = new System.Windows.Forms.Label();
            this.lblGameTypeDesc = new System.Windows.Forms.Label();
            this.lblLoadTypeDesc = new System.Windows.Forms.Label();
            this.lblLoadTypeVal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Minefield.Properties.Resources.settingsLogo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(189, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(422, 116);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.Color.Magenta;
            this.btnQuit.FlatAppearance.BorderSize = 0;
            this.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnQuit.Location = new System.Drawing.Point(12, 456);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(110, 32);
            this.btnQuit.TabIndex = 9;
            this.btnQuit.Text = "BACK";
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // lblGameTypeHeading
            // 
            this.lblGameTypeHeading.BackColor = System.Drawing.Color.Aqua;
            this.lblGameTypeHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGameTypeHeading.Location = new System.Drawing.Point(66, 184);
            this.lblGameTypeHeading.Name = "lblGameTypeHeading";
            this.lblGameTypeHeading.Size = new System.Drawing.Size(192, 31);
            this.lblGameTypeHeading.TabIndex = 10;
            this.lblGameTypeHeading.Text = "GAMEMODE:";
            // 
            // lblLoadTypeHeading
            // 
            this.lblLoadTypeHeading.BackColor = System.Drawing.Color.Magenta;
            this.lblLoadTypeHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLoadTypeHeading.Location = new System.Drawing.Point(94, 307);
            this.lblLoadTypeHeading.Name = "lblLoadTypeHeading";
            this.lblLoadTypeHeading.Size = new System.Drawing.Size(164, 31);
            this.lblLoadTypeHeading.TabIndex = 11;
            this.lblLoadTypeHeading.Text = "LOADOUT:";
            // 
            // pbGameIcon
            // 
            this.pbGameIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbGameIcon.BackgroundImage = global::Minefield.Properties.Resources.searchGameType;
            this.pbGameIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbGameIcon.Location = new System.Drawing.Point(264, 184);
            this.pbGameIcon.Name = "pbGameIcon";
            this.pbGameIcon.Size = new System.Drawing.Size(104, 101);
            this.pbGameIcon.TabIndex = 12;
            this.pbGameIcon.TabStop = false;
            this.pbGameIcon.Click += new System.EventHandler(this.pbGameIcon_Click);
            // 
            // pbLoadIcon
            // 
            this.pbLoadIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbLoadIcon.BackgroundImage = global::Minefield.Properties.Resources.arsonistLoadType;
            this.pbLoadIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbLoadIcon.Location = new System.Drawing.Point(264, 307);
            this.pbLoadIcon.Name = "pbLoadIcon";
            this.pbLoadIcon.Size = new System.Drawing.Size(104, 101);
            this.pbLoadIcon.TabIndex = 13;
            this.pbLoadIcon.TabStop = false;
            this.pbLoadIcon.Click += new System.EventHandler(this.pbLoadIcon_Click);
            // 
            // lblGameTypeVal
            // 
            this.lblGameTypeVal.BackColor = System.Drawing.Color.Aqua;
            this.lblGameTypeVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGameTypeVal.Location = new System.Drawing.Point(340, 184);
            this.lblGameTypeVal.Name = "lblGameTypeVal";
            this.lblGameTypeVal.Size = new System.Drawing.Size(192, 31);
            this.lblGameTypeVal.TabIndex = 14;
            this.lblGameTypeVal.Text = "ModeName";
            // 
            // lblGameTypeDesc
            // 
            this.lblGameTypeDesc.BackColor = System.Drawing.Color.Magenta;
            this.lblGameTypeDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGameTypeDesc.Location = new System.Drawing.Point(374, 223);
            this.lblGameTypeDesc.Name = "lblGameTypeDesc";
            this.lblGameTypeDesc.Size = new System.Drawing.Size(361, 62);
            this.lblGameTypeDesc.TabIndex = 16;
            this.lblGameTypeDesc.Text = "ModeDesc";
            // 
            // lblLoadTypeDesc
            // 
            this.lblLoadTypeDesc.BackColor = System.Drawing.Color.Aqua;
            this.lblLoadTypeDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLoadTypeDesc.Location = new System.Drawing.Point(374, 346);
            this.lblLoadTypeDesc.Name = "lblLoadTypeDesc";
            this.lblLoadTypeDesc.Size = new System.Drawing.Size(361, 62);
            this.lblLoadTypeDesc.TabIndex = 18;
            this.lblLoadTypeDesc.Text = "LoadDesc";
            // 
            // lblLoadTypeVal
            // 
            this.lblLoadTypeVal.BackColor = System.Drawing.Color.Magenta;
            this.lblLoadTypeVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLoadTypeVal.Location = new System.Drawing.Point(340, 307);
            this.lblLoadTypeVal.Name = "lblLoadTypeVal";
            this.lblLoadTypeVal.Size = new System.Drawing.Size(192, 31);
            this.lblLoadTypeVal.TabIndex = 17;
            this.lblLoadTypeVal.Text = "LoadName";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(222, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(357, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "** CLICK THE ICON TO CHANGE SETTING **";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Minefield.Properties.Resources.settingsBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblLoadTypeDesc);
            this.Controls.Add(this.lblLoadTypeVal);
            this.Controls.Add(this.lblGameTypeDesc);
            this.Controls.Add(this.lblGameTypeVal);
            this.Controls.Add(this.pbLoadIcon);
            this.Controls.Add(this.pbGameIcon);
            this.Controls.Add(this.lblLoadTypeHeading);
            this.Controls.Add(this.lblGameTypeHeading);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Minefield: Can you get to the end?";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label lblGameTypeHeading;
        private System.Windows.Forms.Label lblLoadTypeHeading;
        private System.Windows.Forms.PictureBox pbGameIcon;
        private System.Windows.Forms.PictureBox pbLoadIcon;
        private System.Windows.Forms.Label lblGameTypeVal;
        private System.Windows.Forms.Label lblGameTypeDesc;
        private System.Windows.Forms.Label lblLoadTypeDesc;
        private System.Windows.Forms.Label lblLoadTypeVal;
        private System.Windows.Forms.Label label6;
    }
}