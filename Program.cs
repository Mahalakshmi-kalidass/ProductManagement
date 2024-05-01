using System.Collections.Immutable;
using System.Reflection;

namespace Sprint1Assessment
{
    class Program
    {
        static void Main(string[] args)
        {
            menu://label for menu
            int choice = Menu();
            Orders order    = new Orders();
            //choice to select operation
            switch (choice)
            {
                case 1:
                    Product pr = GetProductDetailsFromUser();
                    order.Add(pr);
                    break;
                case 2:
                    int code = GetProductCodeFromUser();
                    order.Remove(code);
                    break;
                case 3:
                    int proCode = GetProductCodeFromUser();
                    Product product = order.GetProductByCode(proCode);
                    printProductDetails(product);
                    break;
                case 4:
                    string proName = GetProductNameFromUser();
                    Product pro = order.GetProductByName(proName);
                    printProductDetails(pro);
                    break;
                case 5:
                    printAllProducts(order);
                    break;

                case 6:
                    order.SortProducts();
                    printAllProducts(order);
                    break;
            }

            Console.WriteLine("Do you want to continue?(Yes/No)");
            string userInp = Console.ReadLine();
            if (userInp.ToLower().Equals("yes"))
            {
                goto menu;
            }
        }
        /// <summary>
        /// this shows the menu to user and get the user choice
        /// </summary>
        /// <returns>returns user choice</returns>
        public static int Menu()
        {
            Console.WriteLine("Welcome to Order Management system ! \n");
            Console.WriteLine("Enter the Choice :\n1. Add Product\n2. Remove Product\n3.Get Product by Code \n" +
                "4. Get Product by Name \n5. Get All Products \n6. Sort product by Code/Name");

            int choice = Convert.ToInt32(Console.ReadLine());   
            return choice;
        }
        /// <summary>
        /// this method is get details of product from the user
        /// </summary>
        /// <returns>returns a product object with specified detials</returns>
        public static Product GetProductDetailsFromUser()
        {
            Console.WriteLine("Enter the Product name : ");
            string proName = Console.ReadLine();
            Console.WriteLine("Enter the Product brand : ");
            string proBrand = Console.ReadLine();

            Product pr = new Product(proName, proBrand);
            return pr;
        }
        /// <summary>
        /// print the product details of given product
        /// </summary>
        /// <param name="product">product object </param>
        public static void printProductDetails(Product product)
        {
            if(product!= null)
            {
                Console.WriteLine($"{product.ProCode}\t{product.ProName}\t{product.ProBrand}\n");

            }
        }
        /// <summary>
        /// this is to get the user input : the product code
        /// </summary>
        /// <returns>returns the user entered productcode</returns>
        public static int GetProductCodeFromUser()
        {
            int code = 0;
            Inp:
            try
            {
                Console.WriteLine("Enter the product code: ");
                 code = Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine("Invalid Input");
                goto Inp;
            }


            return code;

        }
        /// <summary>
        /// this method get the user input through the console
        /// </summary>
        /// <returns>returns user entered value</returns>
        public static string GetProductNameFromUser()
        {
            string name = null;
        Inp:
            try
            {
                Console.WriteLine("Enter the product name: ");
                name = Console.ReadLine();
               string res =  name ?? throw new Exception("input cannot be null");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Input");
                goto Inp;
            }


            return name;

        }
        /// <summary>
        /// this method prints all the product in order
        /// </summary>
        /// <param name="order">order object</param>
        public static void printAllProducts(Orders order)
        {
            foreach(var pr in order)
            {
                printProductDetails(pr);   
            }
        }
    }
}
