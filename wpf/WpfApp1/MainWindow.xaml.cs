using System;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Decimal result = 0;
        //Decimal tempNum = 0, num2 = 0;
        const string DIGIT_FORMAT = "#,##0.##############";
        const int DIGIT_NUM_LIMIT = 12;

        public MainWindow()
        {
            InitializeComponent();

            txtResult.Text = "0";
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            UpdateResult(7);
        }

        private void UpdateResult(int v)
        {
            if (CountDigitNum(txtResult.Text) == -1)
            {
                return;
            }
            if (v == 0)
            {
                if (double.Parse(txtResult.Text) != 0)
                {
                    txtResult.Text += v.ToString();
                }
            }
            else if (txtResult.Text.Equals("0"))
            {
                txtResult.Text = "";
                txtResult.Text += v.ToString();
            }
            else if (txtResult.Text[txtResult.Text.Length - 1].Equals('.') && txtResult.Text.Length < DIGIT_NUM_LIMIT)
            {
                txtResult.Text += v.ToString();
            }
            else
            {
                txtResult.Text = FormatTxtResult(v.ToString());
            }
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            UpdateResult(1);
        }

        private string FormatTxtResult(string addS)
        {
            //MessageBox.Show(decimal.Parse(s, CultureInfo.InvariantCulture).ToString("N0"));
            //CountDecimalNum(s);
            if (CountDigitNum(Decimal.Parse(txtResult.Text + addS).ToString(DIGIT_FORMAT)) == -1)
                return txtResult.Text;
            //string x = new string ('#', 5);
            //MessageBox.Show(x);

            //MessageBox.Show(Decimal.Parse(s).ToString(DIGIT_FORMAT));
            //String.Format("{0:n}", 1234);  // Output: 1,234.00
            //return String.Format("{0:n0}", s); //9876 No digits after the decimal point. Output: 9,876
            return Decimal.Parse(txtResult.Text + addS).ToString(DIGIT_FORMAT);// dec.ToString("N0");
        }

        private int CountDigitNum(string s) // include . ,
        {
            if (s.Length  > DIGIT_NUM_LIMIT)
            {
                //MessageBox.Show("Over number!", "Alert...");
                return -1;
            }
            return s.Length;
        }

        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "0";
        }

        private void BtnDot_Click(object sender, RoutedEventArgs e)
        {
            if (txtResult.Text.Length < DIGIT_NUM_LIMIT && !txtResult.Text.Contains("."))
            {
                txtResult.Text += ".";
            }
        }

        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            UpdateResult(0);
        }

        private int CountDecimalNum(string s)
        {
            if (s.Contains('.'))
            {
                string[] temp = s.Split('.');
                if (temp[1].Length <= 0)
                {
                    return 0;
                }
                return temp[1].Length;
            }
            return 0;
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            UpdateResult(2);
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            UpdateResult(3);
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            UpdateResult(4);
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            UpdateResult(5);
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            UpdateResult(6);
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            UpdateResult(8);
        }

        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            UpdateResult(9);
        }

        
        private void TxtResult_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            txtView.Text = txtResult.Text;
        }

        private void BtnSign_Click(object sender, RoutedEventArgs e)
        {
            if (double.Parse(txtResult.Text) < 0)
            {
                txtResult.Text = txtResult.Text.Substring(1);
            }
            else
            {
                txtResult.Text = "-" + txtResult.Text;
            }
            
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OnTargetUpdated(object sender, DataTransferEventArgs e)
        {

        }
    }
}
