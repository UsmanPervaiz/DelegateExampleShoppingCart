using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelClassLibrary;
using System.Threading;

namespace DelegateExampleShoppingCart
{
    class Program
    {
        static ShoppingCartModel cart = new ShoppingCartModel();
        
        static void Main(string[] args)
        {
            PopulateCartWithDemoData();

            cart.GenerateTotal(getSubtotal, GetTotalBeforeDiscount, computeDiscountedTotal, printTotalAfterDiscount);

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();

        }

        private static void PopulateCartWithDemoData()
        {
            cart.itemsInCart.Add(new ProductModel() { ProductName = "Cereal", ProductPrice = 2.99M});
            cart.itemsInCart.Add(new ProductModel() { ProductName = "Egg", ProductPrice = 1.99M });
            cart.itemsInCart.Add(new ProductModel() { ProductName = "Sugar", ProductPrice = 2.99M });
            cart.itemsInCart.Add(new ProductModel() { ProductName = "Bread", ProductPrice = 2.49M });
        }

        private static decimal getSubtotal(List<ProductModel> cartItems)
        {
            return cartItems.Sum(item => item.ProductPrice);
        }

        private static void GetTotalBeforeDiscount(decimal subtotal)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.WriteLine($"Total before discount is applied: {subtotal:C2}");
        }

        private static decimal computeDiscountedTotal(List<ProductModel> itemsInCart, decimal subtotal)
        {
            if (itemsInCart.Any())
            {
                if (itemsInCart.Count() > 2)
                {
                    return subtotal * 0.70M;
                }
                else if (itemsInCart.Count() > 1)
                {
                    return subtotal * 0.80M;
                }

                return subtotal * 0.90M;
            }

            else
            {
                return subtotal;
            }
        }

        private static void printTotalAfterDiscount(decimal total)
        {
            Console.SetCursorPosition(0, Console.CursorTop-1);
            Console.WriteLine($"Cart total after all discounts is : {total:C2}");
            Console.Write(new string(' ', Console.WindowWidth));
            
        }
    }
}
