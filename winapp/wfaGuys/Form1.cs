using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfaGuys
{
    public partial class Form1 : Form
    {
        Guy joe;
        Guy jack;
        int bank = 100;

        public Form1()
        {
            InitializeComponent();

            joe = new Guy("Joe", 50);
            
            jack = new Guy("Jack", 100);
            
            UpdateForm();
        }

        public void UpdateForm()
        {
            lblJoe.Text = joe.Name + " has $" + joe.Cash;
            lblJack.Text = jack.Name + " has $" + jack.Cash;
            lblBank.Text = "The bank has $" + bank;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (bank >= 10)
            {
                bank -= joe.ReceiveCash(10);
                UpdateForm();
            }
            else
            {
                MessageBox.Show("The bank is out of money.");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            bank += jack.GiveCash(5);
            UpdateForm();
        }

        private void ButtonJack2Joe_Click(object sender, EventArgs e)
        {
            if (jack.Cash >= 10)
            {
                //jack.Cash -= jack.GiveCash(10);
                jack.Cash -= 10;
                joe.Cash += 10;
                UpdateForm();
            }
            else
            {
                MessageBox.Show(jack.Name + " did not enough to give " + joe.Name, jack.Name + " says...");
            }
        }

        private void ButtonJoe2Jack_Click(object sender, EventArgs e)
        {
            if (joe.Cash >= 15)
            {
                joe.Cash -= 15;
                jack.Cash += 15;
                UpdateForm();
            }
            else
            {
                MessageBox.Show(joe.Name + " did not enough to give " + jack.Name, joe.Name + " says...");
            }
        }
    }

    
}

