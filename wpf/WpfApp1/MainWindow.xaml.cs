using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Decimal result = 0;
        double tempNum = 0, num1 = 0;
        const string DIGIT_FORMAT = "#,##0.##############";
        const int DIGIT_NUM_LIMIT = 12;
        private string operatorFlag = "";

        public string OperatorFlag { get => operatorFlag; set => operatorFlag = value; }

        public MainWindow()
        {
            InitializeComponent();

            txtResult.Text = "0";
        }




        private void UpdateTempNum(string s)
        {
            string digit09 = "0123456789";
            // CHECK size txt then 
            if (digit09.Contains(s) && txtResult.Text.Length >= DIGIT_NUM_LIMIT)
            {
                return;
            }
            if (s.Equals("0"))
            {
                if (txtResult.Text.Equals("0")) { return; }
                else
                {
                    if (txtResult.Text.Contains("."))
                    {
                        //update result
                        updateResultText(s);
                    }                        
                    else
                    {
                        tempNum *= 10;//
                        updateResultText(s);
                    }
                }
            }
            else if (digit09.Contains(s))
            {
                // if OperatorFlag OFF update result & tempNum
                if (OperatorFlag.Length > 0) // ON then reset to num2
                {
                    setResultText(s);
                    tempNum = double.Parse(txtResult.Text);
                }
                else
                {
                    txtResult.Text = double.Parse(txtResult.Text + s).ToString(DIGIT_FORMAT);
                    tempNum = double.Parse(tempNum.ToString() + s);
                }
            }
            else if (s.Equals("."))
            {
                if (txtResult.Text.Contains(".")) {
                    if (OperatorFlag.Length > 0) // ON ready for num2
                    {
                        updateResultText("0."); //update result, tempNum still = 0
                    }
                    else return;
                } // && !ON
                else if (OperatorFlag.Length > 0 && tempNum == 0)
                {
                    setResultText("0.");
                }
                else
                {
                    updateResultText(s);  //update result
                }
            }
            else if (s.Equals("+") || s.Equals("-") || s.Equals("*") || s.Equals("/"))
            {
                // update view      tempNum ==> num1 operatorFlag ON ; tempNum = 0
                if (OperatorFlag.Equals(""))
                {
                    num1 = tempNum;
                    tempNum = 0;
                    txtNum1.Text = num1.ToString() + " " + s;

                    OperatorFlag = s;
                }
                else if (OperatorFlag.Equals(s)) return;
                else //if (!OperatorFlag.Equals(s) && tempNum == 0)
                {
                    OperatorFlag = s;
                    var temp = txtNum1.Text.Split(' ');
                    txtNum1.Text = temp[0] + " " + s;
                }

                
                
            }
            else if (s.Equals("C"))
            {
                // reset all tempNum, View, Result...
                setResultText("0");
                OperatorFlag = "";
                tempNum = 0;
                num1 = 0;
                txtNum1.Text = "0";
            }
            else if (s.Equals("+/-"))
            {
                // update tempNum, View, Result
                tempNum *= -1;
            }
            else if (s.Equals("Back"))
            {

            }
            else if (s.Equals("="))
            {
                equalSolving();
            }
            else
            {

            }
        }



        private void equalSolving()
        {
            double temp = num1 + tempNum;
            setResultText(temp.ToString(DIGIT_FORMAT));
        }


       private void updateResultText(string s)
        {
            txtResult.Text += s;
        }

        private void setResultText(string s)
        {
            txtResult.Text = s;
        }

        //private string FormatTxtResult(string addS)
        //{
        //    //MessageBox.Show(decimal.Parse(s, CultureInfo.InvariantCulture).ToString("N0"));
        //    //CountDecimalNum(s);
        //    if (CountDigitNum(Decimal.Parse(txtResult.Text + addS).ToString(DIGIT_FORMAT)) == -1)
        //        return txtResult.Text;
        //    //string x = new string ('#', 5);
        //    //MessageBox.Show(x);

        //    //MessageBox.Show(Decimal.Parse(s).ToString(DIGIT_FORMAT));
        //    //String.Format("{0:n}", 1234);  // Output: 1,234.00
        //    //return String.Format("{0:n0}", s); //9876 No digits after the decimal point. Output: 9,876
        //    return Decimal.Parse(txtResult.Text + addS).ToString(DIGIT_FORMAT);// dec.ToString("N0");
        //}

        private int CountDigitNum(string s) // include . ,
        {
            if (s.Length  > DIGIT_NUM_LIMIT)
            {
                //MessageBox.Show("Over number!", "Alert...");
                return -1;
            }
            return s.Length;
        }

        //private void BtnC_Click(object sender, RoutedEventArgs e)
        //{
        //    txtResult.Text = "0";
        //    OperatorFlag = "";
        //    tempNum = 0;
        //    txtNum1.Text = "0";
        //}

        

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            //UpdateResult(int.Parse(btn.Content.ToString()));
            //UpdateView_Num1();
            UpdateTempNum(btn.Content.ToString());
        }

        private void UpdateView_Num1()
        {
            tempNum = double.Parse(txtResult.Text);
            txtNum1.Text = tempNum.ToString();
        }

        private void UpdateView_Num1(string op)
        {
            if (op.Equals("-1"))    //sign button
            {
                txtNum1.Text = (tempNum * -1).ToString();
                return;
            }
            
            //number button
            txtNum1.Text = tempNum.ToString() + " " + op;
        }

        //private void BtnSign_Click(object sender, RoutedEventArgs e)
        //{
        //    if (double.Parse(txtResult.Text) < 0)
        //    {
        //        txtResult.Text = txtResult.Text.Substring(1);
        //    }
        //    else
        //    {
        //        txtResult.Text = "-" + txtResult.Text;
        //    }
            
        //}


        //public static double solvingNum(double num1, double num2, string operatorStr)
        //{
        //    switch (operatorStr)
        //    {
        //        case "+":
        //            return num1 + num2;
        //        case "-":
        //            return num1 - num2;
        //        case "*":
        //            return num1 * num2;
        //        case "/":
        //            if (num2 != 0)
        //                return num1 / num2;
        //            else
        //                MessageBox.Show("Can not divide by 0!");
        //            break;
        //        default:
        //            break;
        //    }
        //    return 0;
        //}

        
        private void OnTargetUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void TxtResult_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (true)
            {

            }
            MessageBox.Show(OperatorFlag);
        }

        //private void BtnBack_Click(object sender, RoutedEventArgs e)
        //{
        //    if (txtResult.Text.Length == 1)
        //    {
        //        txtResult.Text = "0";
        //        return;
        //    }
                
        //    if (txtResult.Text.Contains('.'))
        //        txtResult.Text = txtResult.Text.Substring(0, txtResult.Text.Length - 1); 
        //    else
        //        txtResult.Text = double.Parse(txtResult.Text.Substring(0, txtResult.Text.Length - 1)).ToString(DIGIT_FORMAT);
        //}
    }
}
