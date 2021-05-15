using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Library
{
    /// <summary>
    /// <c>DrinksGroup</c> class is an abstraction of drinks that are present in the menu
    /// </summary>
    public class DrinksGroup : Dish
    {
        public DrinksGroup(string name, List<int> weight, List<int> price) : base(name, weight, price)
        {
        }
    }
}
