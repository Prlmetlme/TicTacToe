using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public class Node
        {
            public string Move { get; set; }
            public Node Next { get; set; }
            public Node(string move)
            {
                this.Move = move;
                this.Next = null;
            }
        }

        public class Stack
        {
            private Node top;

            public Stack()
            {
                this.top = null;
            }

            public void Push(string move)
            {
                Node newNode = new Node(move) { Next = top };
                top = newNode;
            }
            public string Pop()
            {
                if (top == null)
                {
                    throw new InvalidOperationException("Stack is empty");
                }
                string move = top.Move;
                top = top.Next;
                return move;
            }
            public bool IsEmpty()
            {
                return top == null;
            }
            public void Clear()
            {
                top = null;
            }
        }

        byte turnCount = 0;
        readonly Stack MoveStack = new Stack();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void WinCondition()
        {
            string[][] conditions = new string[8][]
            {
                new string[] { "button1", "button2", "button3" },
                new string[] { "button4", "button5", "button6" },
                new string[] { "button7", "button8", "button9" },
                new string[] { "button1", "button4", "button7" },
                new string[] { "button2", "button5", "button8" },
                new string[] { "button3", "button6", "button9" },
                new string[] { "button1", "button5", "button9" },
                new string[] { "button3", "button5", "button7" }
            };
            foreach (string[] condition in conditions)
            {
                Button button1 = (Button)Controls.Find(condition[0], true)[0];
                Button button2 = (Button)Controls.Find(condition[1], true)[0];
                Button button3 = (Button)Controls.Find(condition[2], true)[0];
                if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X")
                {
                    MessageBox.Show("Player 1 wins!");
                    ResetBoard(null, null);
                }
                else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O")
                {
                    MessageBox.Show("Player 2 wins!");
                    ResetBoard(null, null);
                }
            }
        }

        private void HandleClick(object sender, MouseEventArgs e)
        {
            Button bttn = (Button)sender;
            if (e.Button == MouseButtons.Left)
            {
                if (bttn.Text != " ")
                {
                    return;
                }
                turnCount++;
                if (turnCount % 2 == 0)
                {
                    bttn.Text = "O";
                }
                else
                {
                    bttn.Text = "X";
                }
                MoveStack.Push(bttn.Name + ";" + turnCount);
                WinCondition();
            }
            else if (e.Button == MouseButtons.Right)
            {
                return; // This will open a context menu
            }
        }

        private void Undo(object sender, EventArgs e)
        {
            if (MoveStack.IsEmpty())
            {
                return;
            }
            string lastMove = MoveStack.Pop().Split(';')[0];
            Button lastButton = (Button)Controls.Find(lastMove, true)[0];
            lastButton.Text = " ";
            turnCount--;
        }

        private void Undo2(object sender, EventArgs e)
        {
            for (byte i = 0; i < 2; i++)
            {
                Undo(sender, e);
            }
        }

        private void ResetBoard(object sender, EventArgs e)
        {
            for (byte i = 1; i < 10; i++)
            {
                string buttonName = String.Format("button{0}", i);
                Button button = (Button)Controls.Find(buttonName, true)[0];
                button.Text = " ";
            }
            MoveStack.Clear();
            turnCount = 0;

        }
    }
}
