using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Library
{
    public class Order
    {
        public List<Dish> order = new List<Dish>();


        private double _sum = 0;
        public double Sum { get { return _sum; } set { _sum = value; } }
        public Order()
        { }
        public Order(Dish dish)
        {
            order.Add(dish);
        }
        public void OrderAdd(Dish dish)
        {
            order.Add(dish);
        }
        public void OrderRemove(int index1)
        {
            order.RemoveAt(index1);
        }
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
