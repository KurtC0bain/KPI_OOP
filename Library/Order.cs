using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Library
{
    /// <summary>
    /// <c>Order</c> class in an abstraction of customer's order in the restaurant
    /// </summary>
    /// <remarks>The class can add, remove, clear the order, also give a sum of an order</remarks>
    public class Order
    {
        /// <summary>
        /// List of <typeparamref name="Dish"/> dishes in the order
        /// </summary>
        public List<Dish> order = new List<Dish>();

        /// <summary>
        /// The amount of money that the order costs
        /// </summary>
        private double _sum = 0;
        public double Sum { get { return _sum; } set { _sum = value; } }
        public Order()
        { }
        /// <summary>
        /// Constructor with a parameter of <typeparamref name="Dish"/>
        /// </summary>
        /// <param name="dish">A class <typeparamref name="Dish"/> instance</param>
        public Order(Dish dish)
        {
            order.Add(dish);
        }
        /// <summary>
        /// Method that add a dish to an order
        /// </summary>
        /// <param name="dish">A class <typeparamref name="Dish"/> instance</param>
        public void OrderAdd(Dish dish)
        {
            order.Add(dish);
        }
        /// <summary>
        /// Method that removes a dish with exact index from the order
        /// </summary>
        /// <param name="index1">Index of <typeparamref name="Dish"/> to be removed</param>
        public void OrderRemove(int index1)
        {
            order.RemoveAt(index1);
        }
        /// <summary>
        /// Method that removes a dish with exact name from the order
        /// </summary>
        /// <param name="nameOfDish">A name of dish to be removed</param>
        public void OrderRemove(string nameOfDish)
        {
            int counter = 0;
            for (int i = 0; i < order.Count; i++)
            {
                if (order[i].Name == nameOfDish)
                {
                    order.RemoveAt(counter);
                }
                counter++;
            }
        }

    }
}
