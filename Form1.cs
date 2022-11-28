using Minefield.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minefield
{
    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
        }

        // (0, 19) refers to the bottom left of the panel which is location (0, 380)
        int playerX = 0;
        int playerY = 19;

        // Used to detect bombs and calculate danger level
        Tuple<String, int> squareState;

        // The Array used to hold the positon of bombs
        int[,] MineMap = new int[20, 20];


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
        }

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

        private Tuple<String, int> checkEnv(int x, int y)
        {
            String squareStatus = "Clear";
            int dangerLevel = 0;

            Label label = getLabel(x, y);

            if (MineMap[x, y] == 1)
            {
                label.BackColor = Color.Red;
            }
            else
            {
                label.BackColor = Color.Transparent;
            }

            //Danger Level Calculation
            if (MineMap[x, y - 20] == 1)
            {
                dangerLevel += 1;
            }
            if (MineMap[x, y + 20] == 1)
            {
                dangerLevel += 1;
            }
            if (MineMap[x - 20, y] == 1)
            {
                dangerLevel += 1;
            }
            if (MineMap[x + 20, y] == 1)
            {
                dangerLevel += 1;
            }

            return Tuple.Create(squareStatus, dangerLevel);
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateMinefield();
        }

        #region DPadControls
        private void btnDpadUp_Click(object sender, EventArgs e)
        {
            moveUp();
            squareState = checkEnv(playerX, playerY);

            switch (squareState.Item2){
                
            }
        }

        private void btnDpadDown_Click(object sender, EventArgs e)
        {
            moveDown();
            squareState = checkEnv(playerX, playerY);
        }

        private void btnDpadLeft_Click(object sender, EventArgs e)
        {
            moveLeft();
            squareState = checkEnv(playerX, playerY);
        }

        private void btnDpadRight_Click(object sender, EventArgs e)
        {
            moveRight();
            squareState = checkEnv(playerX, playerY);
        }

        #endregion

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                moveUp();
                squareState = checkEnv(playerX, playerY);
            }

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                moveLeft();
                squareState = checkEnv(playerX, playerY);
            }

            if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                moveDown();
                squareState = checkEnv(playerX, playerY);
            }

            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                moveRight();
                squareState = checkEnv(playerX, playerY);
            }

        }
    }
}
