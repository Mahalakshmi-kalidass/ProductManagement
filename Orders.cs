using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Assessment
{
    internal class Orders : IOrders, IEnumerable<Product>
    {
        //list to maintain the roducts in order
        public static List<Product> Order = new List<Product>();

        //indexer property
        public Product this[int index]
        {
            get
            {
                return Order[index];
            }
            set
            {
                Order.Add(value);
            }
        }
        /// <summary>
        /// this method is for adding product in the Order 
        /// </summary>
        /// <param name="product">product object to be added to order</param>
        public void Add(Product product)
        {
            Order.Add(product);
            Console.WriteLine("Product Added Successfully!\n");
        }
        /// <summary>
        /// this method is to get all the products from the list
        /// </summary>
        /// <returns>returns all products</returns>
        public List<Product> GetAllProducts()
        {
            return Order;
        }

       

        /// <summary>
        /// this method is get the products by using its product code
        /// </summary>
        /// <param name="proCode">product code </param>
        /// <returns>return the product of specified product code</returns>
        public Product GetProductByCode(int proCode)
        {
            Product pr = Order.FirstOrDefault(pr => pr.ProCode.Equals(proCode));
            if (pr != null)
            {
                return pr;
            }
            Console.WriteLine($"Product {proCode} NOT Found!");
            return null;
        }

        /// <summary>
        /// this method is get the products by using its product Name
        /// </summary>
        /// <param name="proName">product Name </param>
        /// <returns>return the product of specified product Name</returns>
        public Product GetProductByName(string proName)
        {
          Product pr = Order.FirstOrDefault(pr => pr.ProName.Equals(proName));
            if (pr != null)
            {
                return pr;
            }
            Console.WriteLine($"Product {proName} NOT Found!");
            return null;
        }

        /// <summary>
        /// this method is to remove the product from the order using product code
        /// </summary>
        /// <param name="proCode">product code of product to be removed</param>
        public void Remove(int proCode)
        {
            //find the product and remove from order
            var removable = Order.FirstOrDefault(pr => pr.ProCode.Equals(proCode));
            if(removable != null)
            {
                Order.Remove(removable);
                Console.WriteLine($"Product {proCode} Removed from order successfully!\n");
            }
            else
            {
                Console.WriteLine($"Product {proCode}  NOT FOUND!\n");

            }

        }

        //methods to make the order enumerable i.e use in foreach loop
        public IEnumerator<Product> GetEnumerator()
        {
            return ((IEnumerable<Product>)Order).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Order).GetEnumerator();
        }

        //sort the products in order
        public void SortProducts()
        {
            Order.Sort(new Product());
        }
    }
}
