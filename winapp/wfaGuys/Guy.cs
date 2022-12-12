using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfaGuys
{
    class Guy
    {
        private string _name;
        private int _cash;

        public Guy(string name, int cash)
        {
            _name = name;
            _cash = cash;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            
        }

        public int Cash
        {
            get
            {
                return _cash;
            }
            set
            {
                _cash = value;
            }
        }

        public int GiveCash(int amount)
        {
            if (amount <= _cash && amount > 0)
            {
                _cash -= amount;
                return amount;
            }
            else
            {
                MessageBox.Show("I don't have enough cash to give you " + amount, Name + " says...");
                return 0;
            }
        }

        public int ReceiveCash(int amount)
        {
            if (amount > 0)
            {
                _cash += amount;
                return amount;
            }
            else
            {
                MessageBox.Show(amount + " isn’t an amount I’ll take",
                    Name + " says...");
                return 0;
            }
        }
    }
}
