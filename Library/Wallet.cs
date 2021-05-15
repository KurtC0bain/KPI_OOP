using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Wallet
    {
        private double _money = 1000;
        public double Money { get { return _money; } set { _money = value; } }
        public Wallet()
        { }
        public Wallet(int sum)
        {
            Money = sum;
        }
    }
}
