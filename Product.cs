using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1Assessment
{
    /// <summary>
    /// this class holds the blueprint of the product object i.e properties
    /// </summary>
    internal class Product  : IComparer<Product>
    {
        //helps in product code auto increment
        private static int incrementer = 1;

        //Auto implemented Properties
        public int ProCode { get;  }
        public string ProName { get; set; }
        public string ProBrand { get; set;}

        //constructor
        public Product()
        {

        }
        public Product(string ProName, string proBrand)
        {
            this.ProName = ProName;
            this.ProCode = incrementer++; //Product Code - auto incremented
            this.ProBrand = proBrand;
        }

        //to sort
        public int Compare(Product pro1, Product pro2)
        {
            Console.WriteLine("How do you want to sort (code/ name)? : ");
            string sortOption = Console.ReadLine();
            int res = 0;
            takeinput:
            try
            {
                if (sortOption.ToLower().Equals("name"))
                {
                    res =  pro1.ProName.CompareTo(pro2.ProName);
                }
                else if (sortOption.ToLower().Equals("code"))
                {
                    res =  pro1.ProCode.CompareTo(pro2.ProCode);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                goto takeinput;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto takeinput;
            }
            
            return res;
        }

    }
}
