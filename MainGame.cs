﻿using Minefield.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Minefield
{
    public partial class MainGame : Form
    {   
        public MainGame()
        {
            InitializeComponent();
        }

        // Holds the player's Score
        int score = 0;

        // (0, 19) refers to the bottom left of the panel which is location (0, 380)
        int playerX = 0;
        int playerY = 19;

        // The Array used to hold the positon of bombs
        int[,] MineMap = new int[20, 20];

        // Holds the amount of lives the player has left
        int lives;

        // List to hold all squares which have already been discovered
        // Used a list over array because the size is variable
        List<String> discoveredSquares = new List<string>();

        // Create an instance of Stopwatch to record time taken to complete level
        // Stopwatch is imported from System.Diagnostics
        Stopwatch stopwatch = new Stopwatch();

        /// <summary>
        /// <para> Restarts the game by: </para>
        /// <br> - Generating a new minefield </br>
        /// <br> - Hiding the mines </br>
        /// <br> - Setting Lives to 3 </br>
        /// <br> - Moving player to starting point </br>
        /// <br> - Hiding the game over controls </br>
        /// </summary>
        private void startGame()
        {
            hideMines();
            GenerateMinefield();

            label381.BackColor = Color.Transparent; //Set starting square to be transparent

            lives = 3;
            score = 0;
            lblScore.Text = $"SCORE: {score}";

            playerX = 0;
            playerY = 19;

            pbGameOver.Visible = false;
            btnReplay.Visible = false;
            btnQuit.Visible = false;

            lblPlayer.Location = new Point(0, 380);

            lblPlayer.Image = Resources.up;
            lblPlayer.Visible = true;

            checkEnv(playerX, playerY);

            stopwatch.Reset();
            stopwatch.Start();
        }

        /// <summary>
        /// Gets the label at the given x and y coordinates
        /// </summary>
        /// <param name="x"> The x Position of the label </param>
        /// <param name="y"> The y Position of the label </param>
        /// <returns> Returns the label at the position </returns>
        private Label getLabel(int x, int y)
        {
            int labelNo = (y * 20) + x + 1;
            String labelName = "label" + labelNo.ToString();

            foreach (Control c in panel1.Controls)
            {
                if (c.Name == labelName)
                {
                    return (Label)c;
                }
            }
            return null;
        }

        /// <summary>
        /// Shows Game Over UI
        /// </summary>
        private void gameOver()
        {
            stopwatch.Stop();

            pbGameOver.Visible = true;
            btnReplay.Visible = true;
            btnQuit.Visible = true;
        }

        /// <summary>
        /// Calculates Final Score and goes to the Score Submit Screen
        /// </summary>
        private void completeLevel()
        {
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            int seconds = Convert.ToInt32(ts.TotalSeconds);

            int timeBonus = 10000 / seconds;

            int totalScore = score + timeBonus;
            
            //High Score Screen?
        }

        /// <summary>
        /// Shows the Player exploding animation
        /// </summary>
        private async Task explodeAsync()
        {
            lblPlayer.Image = Resources.explosionP1;
            await Task.Delay(500);
            lblPlayer.Image = Resources.explosionP2;
            await Task.Delay(500);
            lblPlayer.Image = Resources.explosionP3;
            await Task.Delay(500);
            lblPlayer.Image = Resources.explosionP4;
            await Task.Delay(500);

            lblPlayer.Visible = false;

            lblPlayer.Location = new Point(0, 380);
            playerX = 0;
            playerY = 19;

            if (lives != 0)
            {
                hideMines();
                lblPlayer.Image = Resources.up;
                lblPlayer.Visible = true;

                checkEnv(playerX, playerY);
            }
        }

        #region MineLogic

        /// <summary>
        /// <Para> Generates an 20 by 20 array to hold the location of mines. </Para>
        /// <Para> For each tile, there is a 10% chance of it being a mine. </Para>
        /// </summary>
        private void GenerateMinefield()
        {
            Random rand = new Random();

            for(int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if(rand.Next(1, 10) == 1)
                    {
                        MineMap[i, j] = 1;
                    }
                    else
                    {
                        MineMap[i, j] = 0;
                    }
                }
            }

            MineMap[0, 19] = 0; //Start Square cannot be a mine
            MineMap[19, 0] = 2; //Designates end square
        }

        /// <summary>
        /// Reveals all the mines on the grid using the MineMap
        /// </summary>
        private void showMines()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (MineMap[i, j] == 1)
                    {
                        Label label = getLabel(i, j);
                        label.BackColor = Color.Transparent;
                        label.Image = Resources.bombsmall;
                    }
                    else if (MineMap[i, j] == 0)
                    {
                        Label label = getLabel(i, j);
                        label.BackColor = Color.Transparent;
                    }
                }
            }
        }

        /// <summary>
        /// Hides all the mines on the grid
        /// </summary>
        private void hideMines()
        {
            foreach (Control c in panel1.Controls)
            {
                if (c.Name == "lblPlayer" || c.Name == "label381" || c.Name == "label20" || c.Name == "pbGameOver" || c.Name == "btnReplay" || c.Name == "btnQuit")
                    ;   //Skip

                else
                {
                    c.BackColor = Color.MidnightBlue;
                    ((Label)c).Image = null;
                }
            }
        }

        #endregion

        #region Movement

        /// <summary>
        /// <Para> Moves the player up by 1 square </Para>
        /// </summary>
        private void moveUp()
        {   
            if (playerY != 0)
            {
                lblPlayer.Image = Resources.up;
                lblPlayer.Location = new Point(lblPlayer.Location.X, lblPlayer.Location.Y - 20);
                playerY -= 1;
            }
        }

        /// <summary>
        /// <Para> Moves the player down by 1 square </Para>
        /// </summary>
        private void moveDown()
        {   
            if (playerY != 19)
            {
                lblPlayer.Image = Resources.down;
                lblPlayer.Location = new Point(lblPlayer.Location.X, lblPlayer.Location.Y + 20);
                playerY += 1;
            } 
        }

        /// <summary>
        /// <Para> Moves the player left by 1 square </Para>
        /// </summary>
        private void moveLeft()
        {   
            if (playerX != 0)
            {
                lblPlayer.Image = Resources.left;
                lblPlayer.Location = new Point(lblPlayer.Location.X - 20, lblPlayer.Location.Y);
                playerX -= 1;
            }
        }

        /// <summary>
        /// <Para> Moves the player right by 1 square </Para>
        /// </summary>
        private void moveRight()
        {
            if (playerX != 19)
            {
                lblPlayer.Image = Resources.right;
                lblPlayer.Location = new Point(lblPlayer.Location.X + 20, lblPlayer.Location.Y);
                playerX += 1;
            }
        }
        #endregion

        #region EnvironmentChecks

        private void checkEnv(int x, int y)
        {
            int dangerLevel = 0;

            Label label = getLabel(x, y);

            if (MineMap[x, y] == 1)
            {
                if (btnEndGame.Visible == true)
                {
                    btnEndGame.Visible = false;
                }

                if (lives >= 1)
                {
                    switch (lives)
                    {
                        case 3:
                            pbLife.BackgroundImage = Resources._2Lives;
                            lives -= 1;

                            score -= 5;
                            lblScore.Text = $"SCORE: {score}";

                            explodeAsync();
                            break;
                        case 2:
                            pbLife.BackgroundImage = Resources._1life;
                            lives -= 1;

                            score -= 5;
                            lblScore.Text = $"SCORE: {score}";

                            explodeAsync();                            
                            break;
                        case 1:
                            pbLife.BackgroundImage = Resources.nolife;
                            lives -= 1;

                            score -= 5;
                            lblScore.Text = $"SCORE: {score}";

                            explodeAsync();
                            showMines();
                            gameOver();
                            break;
                    }
                }
            }
            else if (MineMap[x, y] == 2)
            {
                btnEndGame.Visible = true;
            }
            else
            {   
                if (btnEndGame.Visible == true)
                {
                    btnEndGame.Visible = false;
                }

                label.BackColor = Color.Transparent;

                //Score Logic
                bool isSquareDiscovered = false;

                foreach (String square in discoveredSquares)
                {
                    if ($"({playerX},{playerY})" == square)
                    {
                        isSquareDiscovered = true;
                    }
                }

                if (isSquareDiscovered == false)
                {
                    score += 1;
                    lblScore.Text = $"SCORE: {score}";
                }

                //Add Square to discovered list
                discoveredSquares.Add($"({playerX},{playerY})");
            }

            //Danger Level Calculation
            if (playerY != 0)
            {
                if (MineMap[x, y - 1] == 1)
                {
                    dangerLevel += 1;
                }
            }
            if (playerY != 19)
            {
                if (MineMap[x, y + 1] == 1)
                {
                    dangerLevel += 1;
                }
            }
            if (playerX != 0)
            {
                if (MineMap[x - 1, y] == 1)
                {
                    dangerLevel += 1;
                }
            }
            if (playerX != 19)
            {
                if (MineMap[x + 1, y] == 1)
                {
                    dangerLevel += 1;
                }
            }
                
            switch (dangerLevel)
            {
                case 0:
                    pbDanger.BackgroundImage = Resources.nobomb;
                    break;
                case 1:
                    pbDanger.BackgroundImage = Resources._1bomb;
                    break;
                case 2:
                    pbDanger.BackgroundImage = Resources._2bomb;
                    break;
                case 3:
                    pbDanger.BackgroundImage = Resources._3bomb;
                    break;
            }
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            startGame();
        }

        #region DPadControls
        private void btnDpadUp_Click(object sender, EventArgs e)
        {
            moveUp();
            checkEnv(playerX, playerY);
        }

        private void btnDpadDown_Click(object sender, EventArgs e)
        {
            moveDown();
            checkEnv(playerX, playerY);
        }

        private void btnDpadLeft_Click(object sender, EventArgs e)
        {
            moveLeft();
            checkEnv(playerX, playerY);
        }

        private void btnDpadRight_Click(object sender, EventArgs e)
        {
            moveRight();
            checkEnv(playerX, playerY);
        }

        #endregion

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                moveUp();
                checkEnv(playerX, playerY);
            }

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                moveLeft();
                checkEnv(playerX, playerY);
            }

            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                moveDown();
                checkEnv(playerX, playerY);
            }

            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                moveRight();
                checkEnv(playerX, playerY);
            }

        }

        private void btnReplay_Click(object sender, EventArgs e)
        {
            startGame();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                form.Show();
            }

            this.Close();
        }

        private void btnEndGame_Click(object sender, EventArgs e)
        {
            completeLevel();
        }

        private void UpdateStopwatchInterval_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = stopwatch.Elapsed; 
            String time = String.Format("{0:00}:{1:00}.{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            lblTimer.Text = time;
        }
    }
}
