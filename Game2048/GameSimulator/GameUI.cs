using GameEngine2048;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSimulator
{
    public partial class GameUI : Form
    {
        private GameEngine engine;
        private int size;

        protected int startPointX = 22;
        protected int startPointY = 53;
        protected int gap = 10;
        protected Label[] theLabels;

        public GameUI(int size)
        {
            this.size = size;

            InitializeComponent();
            SetUI();

            CreateLabelsEvent();
            ManageKeyDownEvent();
            

            engine = new GameEngine(this.size);
            this.engine.StartGame();

            MakeDisplayChanges();

            ManageGameOverEvent();
        }

        private void ManageGameOverEvent()
        {
            this.engine.GameOver += Engine_GameEnded;
        }

        private void Engine_GameEnded(object sender, EventArgs e)
        {
            MessageBox.Show("Game Over");
            this.Invoke((MethodInvoker)delegate { CreateNewGame(); });
        }

        private void MakeDisplayChanges()
        {
            DisplayMatrix(this.engine.CurrentMatrix);
            DisplayScore(this.engine.Score);
            DisplayNumberOfMoves(this.engine.Moves);
        }

        private void DisplayNumberOfMoves(int moves)
        {
            lblMoves.Text = string.Format("Moves = {0}", moves);
        }

        private void DisplayScore(int score)
        {
            lblScore.Text = string.Format("Score = {0}", score);
        }

        private void ManageKeyDownEvent()
        {
            this.KeyDown += Form1_KeyDown;
            this.KeyPreview = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            CheckKeyDown(e);
            MakeDisplayChanges();
            SetBtnUndoEnabledOrDisabled();
        }

        private void SetBtnUndoEnabledOrDisabled()
        {
            if (this.engine.Moves > 0)
            {
                this.btnUndo.Enabled = true;
            }
            else
            {
                this.btnUndo.Enabled = false;
            }
        }

        private void CheckKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Back:
                    if (btnUndo.Enabled)
                    {
                        this.engine.Undo();
                    }
                    break;
                case Keys.NumPad8: // Up
                    this.engine.ApplyMove(EMoveType.Up);
                    break;
                case Keys.NumPad5: // Down
                    this.engine.ApplyMove(EMoveType.Down);
                    break;
                case Keys.NumPad6: // Right
                    this.engine.ApplyMove(EMoveType.Right);
                    break;
                case Keys.NumPad4: // Left
                    this.engine.ApplyMove(EMoveType.Left);
                    break;
            }
        }


        private void SetUI()
        {
            int labelSize = SetLabelsSize();

            CreateTheSmallSquares(labelSize);
            CreateBackgroundSquareAndSetClientSize(labelSize);
        }

        private void CreateLabelsEvent()
        {
            foreach (Label currentLabel in this.theLabels)
            {
                currentLabel.TextChanged += new System.EventHandler(this.label_TextChanged);
            }
        }

        private void label_TextChanged(object sender, EventArgs e)
        {
            string labelName = ((Label)sender).Name;
            foreach (Label item in theLabels)
            {
                if (item.Name == labelName)
                {
                    int height = 0;
                    double fontHeight = 0;

                    switch (item.Text)
                    {
                        case "":
                            item.BackColor = Color.LightGray;
                            break;
                        case "2":
                            item.BackColor = Color.White;
                            item.ForeColor = Color.Black;
                            height = item.Size.Height;
                            fontHeight = height * 0.35;
                            item.Font = new System.Drawing.Font("Hobo Std", (float)fontHeight, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            //item.Text = "8192";
                            break;
                        case "4":
                            item.BackColor = Color.Wheat;
                            item.ForeColor = Color.Black;
                            height = item.Size.Height;
                            fontHeight = height * 0.35;
                            item.Font = new System.Drawing.Font("Hobo Std", (float)fontHeight, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            break;
                        case "8":
                            item.BackColor = Color.Coral;
                            item.ForeColor = Color.White;
                            height = item.Size.Height;
                            fontHeight = height * 0.35;
                            item.Font = new System.Drawing.Font("Hobo Std", (float)fontHeight, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            break;
                        case "16":
                            item.BackColor = Color.Purple;
                            item.ForeColor = Color.White;
                            height = item.Size.Height;
                            fontHeight = height * 0.35;
                            item.Font = new System.Drawing.Font("Hobo Std", (float)fontHeight, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            break;
                        case "32":
                            item.BackColor = Color.Violet;
                            item.ForeColor = Color.White;
                            height = item.Size.Height;
                            fontHeight = height * 0.35;
                            item.Font = new System.Drawing.Font("Hobo Std", (float)fontHeight, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            break;
                        case "64":
                            item.BackColor = Color.Red;
                            item.ForeColor = Color.White;
                            height = item.Size.Height;
                            fontHeight = height * 0.35;
                            item.Font = new System.Drawing.Font("Hobo Std", (float)fontHeight, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            break;
                        case "128":
                            item.BackColor = Color.Tomato;
                            item.ForeColor = Color.White;
                            height = item.Size.Height;
                            fontHeight = height * 0.288;
                            item.Font = new System.Drawing.Font("Hobo Std", (float)fontHeight, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            break;
                        case "256":
                            item.BackColor = Color.SteelBlue;
                            item.ForeColor = Color.White;
                            height = item.Size.Height;
                            fontHeight = height * 0.288;
                            item.Font = new System.Drawing.Font("Hobo Std", (float)fontHeight, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            break;
                        case "512":
                            item.BackColor = Color.SandyBrown;
                            item.ForeColor = Color.White;
                            height = item.Size.Height;
                            fontHeight = height * 0.288;
                            item.Font = new System.Drawing.Font("Hobo Std", (float)fontHeight, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            break;
                        case "1024":
                            item.BackColor = Color.RoyalBlue;
                            item.ForeColor = Color.White;
                            height = item.Size.Height;
                            fontHeight = height * 0.225;
                            item.Font = new System.Drawing.Font("Hobo Std", (float)fontHeight, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            break;
                        case "2048":
                            //if (!this.heAlreadyWon)
                            //{
                            //    this.heAlreadyWon = true;
                            //    MessageBox.Show("You won!! But keep going. You're doing just fine.", "You won!");
                            //}
                            item.BackColor = Color.Pink;
                            item.ForeColor = Color.White;
                            height = item.Size.Height;
                            fontHeight = height * 0.225;
                            item.Font = new System.Drawing.Font("Hobo Std", (float)fontHeight, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            break;
                        case "4096":
                        case "8192":
                            item.BackColor = Color.Black;
                            item.ForeColor = Color.White;
                            height = item.Size.Height;
                            fontHeight = height * 0.225;
                            item.Font = new System.Drawing.Font("Hobo Std", (float)fontHeight, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            break;
                        default:
                            item.BackColor = Color.Black;
                            item.ForeColor = Color.White;
                            height = item.Size.Height;
                            fontHeight = height * 0.2;
                            item.Font = new System.Drawing.Font("Hobo Std", (float)fontHeight, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            break;
                    }
                    break;
                }
            }
        }

        private void CreateBackgroundSquareAndSetClientSize(int labelSize)
        {
            int startX = this.startPointX - 10;
            int startY = this.startPointY - 10;
            int backgroundSize = labelSize * this.size + this.gap * (this.size + 1);

            Label backgroundLabel = new System.Windows.Forms.Label();
            backgroundLabel.BackColor = System.Drawing.Color.Gray;
            backgroundLabel.Font = new System.Drawing.Font("Hobo Std", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            backgroundLabel.Location = new System.Drawing.Point(startX, startY);
            backgroundLabel.Size = new System.Drawing.Size(backgroundSize, backgroundSize);
            backgroundLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Controls.Add(backgroundLabel);

            int clientSizeX = startX + backgroundSize + 12;
            int clientSizeY = startY + backgroundSize + 12;
            this.ClientSize = new Size(clientSizeX, clientSizeY);
        }

        private void CreateTheSmallSquares(int labelSize)
        {
            this.theLabels = new Label[this.size * this.size];
            int index = 0;
            string name = "a";

            int currentX = this.startPointX;
            int currentY = this.startPointY;

            for (int y = 0; y < this.size; y++)
            {
                for (int x = 0; x < this.size; x++)
                {
                    name = string.Format("{0}a", name);
                    theLabels[index] = new System.Windows.Forms.Label();
                    theLabels[index].BackColor = System.Drawing.Color.LightGray;
                    theLabels[index].Font = new System.Drawing.Font("Hobo Std", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    theLabels[index].Location = new System.Drawing.Point(currentX, currentY);
                    theLabels[index].Size = new System.Drawing.Size(labelSize, labelSize);
                    theLabels[index].Text = "";
                    theLabels[index].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    theLabels[index].Name = name;
                    this.Controls.Add(theLabels[index]);

                    index++;
                    currentX += labelSize + this.gap;
                }
                currentX = this.startPointX;
                currentY += labelSize + this.gap;
            }
        }

        private int SetLabelsSize()
        {
            switch (this.size)
            {
                case 4:
                case 5:
                    return 80;
                case 6:
                    return 67;
                case 7:
                    return 57;
                case 8:
                    return 50;
                case 9:
                    return 44;
                case 10:
                    return 40;
                default:
                    return 40;
            }
        }

        private void DisplayMatrix(int[,] matrix)
        {
            int index = -1;
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    index++;
                    if (matrix[i, j] != 0)
                    {
                        this.theLabels[index].Text = matrix[i, j].ToString();
                    }
                    else
                    {
                        this.theLabels[index].Text = "";
                    }
                }
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            this.engine.Undo();
            MakeDisplayChanges();
            SetBtnUndoEnabledOrDisabled();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            CreateNewGame();
        }

        private void CreateNewGame()
        {
            this.engine.StartGame();
            MakeDisplayChanges();
            SetBtnUndoEnabledOrDisabled();
        }
    }
}
