using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            string name = "Quentin";
            int x = 3;
            x *= 17;
            double d = Math.PI / 2;
            myLabel.Text = "name is " + name + "\nx is " + x + "\nd is " + d;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            int x = 5;
            if (x == 10)
            {
                myLabel.Text = "x must be 10";
            }
            else
            {
                myLabel.Text = "x isn’t 10";
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            int someValue = 4;
            string name = "Bobbo Jr.";
            if ((someValue == 3) && (name == "Joe"))
            {
                myLabel.Text = "x is 3 and the name is Joe";
            }
            myLabel.Text = "this line runs no matter what";
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            while (count < 10)
            {
                count += 1;
            }
            for (int i = 0; i < 5; i++)
            {
                count -= 1;
            }
            myLabel.Text = "The answer is " + count;
        }

        private void ButtonExecices01_Click(object sender, RoutedEventArgs e)
        {
            //Execices01Page execices = new Execices01Page();
            //excecices.Show();

        }
    }
}
