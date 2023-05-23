using BoardLogic01;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TicTacToeGUI
{
    public partial class Form1 : Form
    {

        Board game = new Board();
        Button[] buttons = new Button[9];

        public Form1()
        {
            InitializeComponent();

            game = new Board();

            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            buttons[4] = button5;
            buttons[5] = button6;
            buttons[6] = button7;
            buttons[7] = button8;
            buttons[8] = button9;

            // add a common click event to each button
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += handleButtonClick;// gom func
                buttons[i].Tag = i;
            }

        }

        private void handleButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            MessageBox.Show($"button {clickedButton.Tag} was clicked.");

            int gameSquareNumber = (int)clickedButton.Tag;
            game.Grid[gameSquareNumber] = 1;

            UpdateBoard();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateBoard();
        }

        private void UpdateBoard()
        {
            // assign an X or O to the text of each button based on the values in Board
            for (int i = 0; i < game.Grid.Length; i++)
            {
                if (game.Grid[i] == 0)
                {
                    buttons[i].Text = "";
                }
                else if (game.Grid[i] == 1)
                {
                    buttons[i].Text = "X";
                }
                else if (game.Grid[i] == 2)
                {
                    buttons[i].Text = "O";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
