using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// <c>Wallet</c> class is an abstraction of costumers amount of money
    /// </summary>
    /// <remarks>It can be connected to the bank account and get the valid data from it</remarks>
    public class Wallet
    {
        /// <summary>
        /// Variable of current balance
        /// </summary>
        private double _money = 1000;
        public double Money { get { return _money; } set { _money = value; } }
        public Wallet()
        { }
        /// <summary>
        /// Method that can change costumer's current balance 
        /// </summary>
        /// <param name="sum">Sum of money that goes to the balance</param>
        public Wallet(int sum)
        {
            Money = sum;
        }
    }
}
