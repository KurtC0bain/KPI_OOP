using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Library
{
    /// <summary>
    /// <c>SoupGroup</c> class is an abstraction of soups that are present in the menu
    /// </summary>
    public class SoupGroup : Dish
    {
        public SoupGroup(string name, List<int> weight, List<int> price) : base(name, weight, price)
        {
        }
    }
}
