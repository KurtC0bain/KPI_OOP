using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Library
{
    public interface IDish
    {
        string Name { get; set; }
        void AddIngredient(List<Product> compose);
        void AddIngredient(Product product);
    }
}
