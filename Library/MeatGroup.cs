using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Library
{
    /// <summary>
    /// <c>MeatGroup</c> class is an abstraction of meat and fish dishes that are present in the menu
    /// </summary>
    public class MeatGroup : Dish
    {
        public MeatGroup(string name, List<int> weight, List<int> price) : base(name, weight, price)
        {
        }
    }
}
