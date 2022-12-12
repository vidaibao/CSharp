using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ChangeText_Click(object sender, EventArgs e)
        {
            if (enableCheckbox.Checked)
            {
                if (labelToChange.Text == "Right")
                {
                    labelToChange.Text = "Left";
                    labelToChange.TextAlign = ContentAlignment.MiddleLeft;
                }
                else
                {
                    labelToChange.Text = "Right";
                    labelToChange.TextAlign = ContentAlignment.MiddleRight;
                }
            }
            else
            {
                labelToChange.Text = "Text changing is disabled";
                labelToChange.TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            //f2.show();
            this.Hide();
            f2.ShowDialog();
            this.Show();
        }
    }
}
