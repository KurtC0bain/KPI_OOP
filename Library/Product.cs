using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Library
{
    public class Product
    {
        public string Name { get; set; }
        public float Weight { get; set; }
        public Product(string name)
        {
            Name = name;
        }
        public Product(string name, float weight)
        {
            Name = name;
            Weight = weight;
        }

    }
}
