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
        public Order(Dish dish, int weight)
        {
            if (dish._weight[0] == weight)
            {
                dish._weight.RemoveAt(1);
                dish._price.RemoveAt(1);
            }
            else
            {
                dish._weight.RemoveAt(0);
                dish._price.RemoveAt(0);
            }
            order.Add(dish);
            Sum += dish._price[0];
        }
        public Order(Dish dish)
        {
            order.Add(dish);
            Sum += dish._price[0];

        }
        public void OrderAdd(Dish dish, int weight)
        {
            if (dish._weight[0] == weight)
            {
                dish._weight.RemoveAt(1);
                dish._price.RemoveAt(1);
            }
            else
            {
                dish._weight.RemoveAt(0);
                dish._price.RemoveAt(0);

            }
            order.Add(dish);
            Sum += dish._price[0];
        }
        public void OrderAdd(Dish dish)
        {
            order.Add(dish);
            Sum += dish._price[0];
        }
        public void OrderRemove(int index)
        {
            Sum -= order[index]._price[0];
            order.RemoveAt(index);
        }
        public void OrderRemove(string nameOfDish)
        {
            int counter = 0;
            for (int i = 0; i < order.Count; i++)
            {
                if (order[i].Name == nameOfDish)
                {
                    Sum -= order[counter]._price[0];
                    order.RemoveAt(counter);
                }
                counter++;
            }
        }

    }
}
