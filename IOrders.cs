using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Assessment
{
    /// <summary>
    /// this is the interface that gives structral model for order with the functionality
    /// </summary>
    internal interface IOrders
    {
        // to add products in the order
        void Add(Product product);

        //to remove the product from order
        void Remove(int proCode);

        //get details of product by using product code
        Product GetProductByCode(int proCode);

        //get details of product by using product Name
        Product GetProductByName(string proName);

        //get all the products in order
        List<Product> GetAllProducts();
    }
}
