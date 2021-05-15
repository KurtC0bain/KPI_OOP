using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Library
{
    /// <summary>
    /// <c>Product</c> class is an abstraction of products which dishes consist of
    /// </summary>
    /// <remarks>Describes ingredients with a few characteristics </remarks>
    public class Product
    {
        /// <summary>
        /// Property to work with a name of product
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Property to work with a weight of product
        /// </summary>
        public float Weight { get; set; }
        /// <summary>
        /// Constructor of a products that gets a name from the outside
        /// </summary>
        /// <param name="name">Name of a product</param>
        public Product(string name)
        {
            Name = name;
        }
        /// <summary>
        /// Constructor of a products that gets a name and a weight of ingredient
        /// </summary>
        /// <param name="name">Name of a product</param>
        /// <param name="weight">Weight of a product</param>
        public Product(string name, float weight)
        {
            Name = name;
            Weight = weight;
        }

    }
}
