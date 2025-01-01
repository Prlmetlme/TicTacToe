using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        byte turn = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void handleClick(object sender, MouseEventArgs e)
        {
            Button bttn = (Button)sender;
            Console.WriteLine(e.Button);
            
            if (bttn.Text != " ")
            {
                return;
            }
            if (e.Button == MouseButtons.Left)
            {
                if (turn % 2 == 0)
                {
                    bttn.Text = "X";
                }
                else
                {
                    bttn.Text = "O";
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                return; // This will be used to open a context menu
            } 
        }
    }
}
