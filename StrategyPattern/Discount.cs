using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    //strategy interface
    public interface IDiscount
    {
        List<ICartItem> applyDiscount(List<ICartItem> cartItems);
    }

    //Discount context (must context class)
    public class DiscountContext : ICartItem
    {
        public string ItemCode { get; set; }
        public CartTypes ItemType
        {
            get { return CartTypes.Discount; }
        }

        public double Cost { get; set; }

        //must have strategy interface relationship(has a relationship)
        private IDiscount strategy;

        public DiscountContext(string itemCode,IDiscount strategy)
        {
            this.strategy = strategy;
            ItemCode = itemCode;
            Cost = 0;
        }

        public List<ICartItem> ExecuteStrategy(List<ICartItem> cartItems)
        {
            return strategy.applyDiscount(cartItems);
        }
    }

 
    //Concrete strategy class
    public class NewDiscountStrategy : IDiscount
    {
        private int discountPercentage;
        public NewDiscountStrategy(string itemCode)
        {
            this.discountPercentage = Convert.ToInt32(itemCode.Replace("DIS", ""));
        }

        public List<ICartItem> applyDiscount(List<ICartItem> cartItems)
        {
            cartItems.ForEach(cartItem =>
            cartItem.Cost = cartItem.Cost * (100 - discountPercentage) * 0.01);
            return cartItems;

        }
    }

    //Concrete strategy class
    public class NextItemDiscount : IDiscount
    {
        private int discountDollar;
        int cartIndex;
        public string itemCode;
        public NextItemDiscount(string itemCode)
        {           
            this.discountDollar = Convert.ToInt32(itemCode.Replace("DIS", ""));
            this.itemCode = itemCode;
        }


        public List<ICartItem> applyDiscount(List<ICartItem> cartItems)
        {

            cartIndex = cartItems.FindIndex(i => i.ItemCode == itemCode);
            if (cartIndex > -1 && cartIndex < cartItems.Count - 1)
            {
                cartItems[cartIndex + 1].Cost -= discountDollar;
            }
            return cartItems;
        }
    }

   
}
