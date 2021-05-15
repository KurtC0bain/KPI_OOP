using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// <c>IDish</c> is an interface that force us to realize a couple of things in inheritors
    /// </summary>
    /// <remarks>I determine two life-needed properties. Without them dish will not exist</remarks>
    public interface IDish
    {
        /// <summary>
        /// Name of a dish
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// A method that add a list of <typeparamref name="Product"/> to a dish
        /// </summary>
        /// <param name="compose">A list of that abstractions</param>
        void AddIngredient(List<Product> compose);
        /// <summary>
        /// A method that add one <typeparamref name="Product"/> to a dish
        /// </summary>
        /// <param name="product">A representative of <typeparamref name="Product"/></param>
        void AddIngredient(Product product);
    }
}
