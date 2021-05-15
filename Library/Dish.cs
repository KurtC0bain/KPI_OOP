using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Library
{
    /// <summary>
    /// <c>Dish</c> class - is an abstraction of the meal in a menu of the restaurant
    /// Contains methods, properties and fields that form a dish
    /// </summary>
    public class Dish : IDish
    {
        /// <summary>
        /// Variables for inheritable classes
        /// </summary>
        public bool needSauce = false;
        public bool needBread = false;
        public bool needSugar = false;
        /// <summary>
        /// Constructor with parameters that describe a dish
        /// </summary>
        /// <param name="name">A name of the dish</param>
        /// <param name="weight">A list of possible portions</param>
        /// <param name="price">A list of possible price for each portion</param>
        public Dish(string name, List<int> weight, List<int> price)
        {
            for (int i = 0; i < weight.Count; i++)
            {
                _weight.Add(weight[i]);
                _price.Add(price[i]);
            }
            Name = name;
        }
        /// <summary>
        /// A list of products of which the dish consist
        /// </summary>
        public List<Product> ingredients = new List<Product>();
        /// <summary>
        /// Method that add ingredients to the dish
        /// </summary>
        /// <param name="compose">A list of ingredients of <typeparamref name="Product"/> that we want to add to the dish</param>
        public void AddIngredient(List<Product> compose)
        {
            for (int i = 0; i < compose.Count; i++)
            {
                ingredients.Add(compose[i]);
            }
        }
        /// <summary>
        /// Method that add one ingredient <typeparamref name="Product"/> to the dish
        /// </summary>
        /// <typeparam name="product">An abstraction of products</typeparam>
        public void AddIngredient(Product product)
        {
            ingredients.Add(product);
        }
        /// <summary>
        /// Private field for name of the dish
        /// </summary>
        private string _name;
        /// <summary>
        /// Lists of possible weight and price for each weight
        /// </summary>
        public List<int> _weight = new List<int>();
        public List<int> _price = new List<int>();
        public string Name { get => _name;  set => _name = value; }

    }
}
