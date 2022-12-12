using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDesktopApp
{
    class AnotherClass
    {
        static void Main(string[] args)
        {
            MessageBox.Show("Hiiiiii");
            //form form = new form1();
            //form.show();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
