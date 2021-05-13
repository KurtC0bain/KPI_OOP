using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Library
{
    public class Dish : IDish
    {
        public Dish(string name, List<int> weight, List<int> price)
        {
            for (int i = 0; i < weight.Count; i++)
            {
                _weight.Add(weight[i]);
                _price.Add(price[i]);
            }
            Name = name;
        }

        public List<Product> ingredients = new List<Product>();

        public void AddIngredient(List<Product> compose)
        {
            for (int i = 0; i < compose.Count; i++)
            {
                ingredients.Add(compose[i]);
            }
        }
        public void AddIngredient(Product product)
        {
            ingredients.Add(product);
        }

        private string _name;

        public List<int> _weight = new List<int>();
        public List<int> _price = new List<int>();
        public string Name { get => _name;  set => _name = value; }

    }
}
