using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;

namespace GameSimulator
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private int gameSize;
        private bool currentCheck = true;

        private void SetGameSize(object sender)
        {
            if (this.currentCheck == true)
            {
                CheckBox chb = (CheckBox)sender;
                string name = chb.Text;
                int number = 0;

                if (int.TryParse(name[1].ToString(), out number))
                {
                    this.gameSize = int.Parse(name[0].ToString()) * 10 + int.Parse(name[1].ToString());
                }
                else
                {
                    this.gameSize = int.Parse(name[0].ToString());
                }

                AskForConfirmation();
                AllCheckboxesUnchecked();
            }
        }

        private void AskForConfirmation()
        {
            string message = "";
            if (this.gameSize < 10)
            {
                message = string.Format("Are you sure you want to play the 2024 game in {0} x {0} mode?", gameSize.ToString());
                if (MessageBox.Show(message, "2024", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    this.Hide();
                    GameUI fm = new GameUI(gameSize);
                    fm.ShowDialog();
                    this.Show();
                }
            }
            else
            {
                this.Hide();
                Chuck chuck = new Chuck();
                chuck.Show();
                chuck.Refresh();
                Thread.Sleep(3000);
                chuck.Dispose();
                this.Show();


                //message = "Calm down bro!!";
                //MessageBox.Show(message);
            }
        }

        private void AllCheckboxesUnchecked()
        {
            this.currentCheck = false;
            chb4.Checked = false;
            chb5.Checked = false;
            chb6.Checked = false;
            chb7.Checked = false;
            chb8.Checked = false;
            chb9.Checked = false;
            chb10.Checked = false;
            this.currentCheck = true;
        }

        private void chb4_CheckedChanged(object sender, EventArgs e)
        {
            SetGameSize(sender);
        }
    }
}
