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
        Random random = new Random();

        int pointCCB = 0;
        int pointPC = 0;

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
                buttons[i].Click += handleButtonClick;// gom handle func
                buttons[i].Tag = i;
                buttons[i].Font = new Font(buttons[i].Font.FontFamily, 100);
            }

        }

        private void handleButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            //MessageBox.Show($"button {clickedButton.Tag} was clicked.");

            int gameSquareNumber = (int)clickedButton.Tag;
            if (game.Grid[gameSquareNumber] != 0)
            {
                MessageBox.Show("Try another button!");
                return;
            }
            game.Grid[gameSquareNumber] = 1;

            UpdateBoard();

            if (game.Check4Winner() == 1)
            {
                MessageBox.Show("Player CCB won");
                pointCCB++;
                disableAllButtons();
            }
            else if (game.IsBoardFull())
            {
                MessageBox.Show("The board is full");
                disableAllButtons();
            }
            else
            {
                // computer turn
                ComputerChoose();
            }
   

        }

        private void disableAllButtons()
        {
            SetPoint();

            foreach (var button in buttons)
            {
                button.Enabled = false;
            }
        }

        private void ComputerChoose()
        {
            int computerChoose = -1;
            while (computerChoose == -1 || game.Grid[computerChoose] != 0)
            {
                computerChoose = random.Next(9);
            }
            //MessageBox.Show($"Computer chooses {computerChoose}");
            game.Grid[computerChoose] = 2;

            UpdateBoard();

            if (game.Check4Winner() == 2)
            {
                MessageBox.Show("Player Computer won");
                pointPC++;
                disableAllButtons();
            }
            else if (game.IsBoardFull())
            {
                MessageBox.Show("The board is full");
                disableAllButtons();
            }

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
                    buttons[i].ForeColor = Color.Black;
                    buttons[i].Enabled = true;
                }
                else if (game.Grid[i] == 1)
                {
                    buttons[i].Text = "X";
                    buttons[i].ForeColor = Color.Red;
                    buttons[i].Enabled = false;
                }
                else if (game.Grid[i] == 2)
                {
                    buttons[i].Text = "O";
                    buttons[i].ForeColor = Color.Yellow;
                    buttons[i].Enabled = false;
                }
            }
        }

       
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            game = new Board();
            EnableAllButtons();
        }

        private void SetPoint()
        {
            lblPointCCB.Text = pointCCB.ToString();
            lblPointPC.Text = pointPC.ToString();
        }

        private void EnableAllButtons()
        {
            foreach (var item in buttons)
            {
                item.Enabled = true;
            }
            UpdateBoard();
        }

    }
}
