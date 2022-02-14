using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    #region problemStatement
    //Create a cart.
    //add items to cart.
    //cart may have multiple items to be added to it(discount,item)
    //3 types of discount, Fullcart discount, next item discount, nth item discount
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Product P1 = new Product("PRO12", Category.Electronics, 20);
            Product P2 = new Product("PRO13", Category.Clothing, 20);
            DiscountContext dc1 = new DiscountContext("DIS10",new NewDiscountStrategy("DIS10"));
            DiscountContext dc2 = new DiscountContext("DIS1",new NextItemDiscount("DIS1"));
            Product P3 = new Product("PRO14", Category.Furniture, 10);
            Product P4 = new Product("PRO13", Category.Clothing, 30);
            Cart mycart = new Cart();            
            mycart.ItemList = new List<ICartItem>() { P1, P2, dc1,dc2, P3, P4 };            
            Console.WriteLine(mycart.GetCartTotal());
            Console.ReadLine();
        }

       
    }
}
