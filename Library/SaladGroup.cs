using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Library
{
    public class SaladGroup : Dish
    {
        public SaladGroup(string name, List<int> weight, List<int> price) : base(name, weight, price)
        {
        }
    }
}
