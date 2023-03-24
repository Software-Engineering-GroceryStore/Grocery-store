using GroceryStore.DAO;
using GroceryStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.BUS
{
    internal class BUS_Cart
    {
        public int calculateBill(DTO_Cart cart)
        {
            #region 1.Calculate bill
            int sumMoney = 0;
            foreach(DTO_Product product in cart.Products.GetAll())
            {
                sumMoney += product.GiaSP;
            }
            return sumMoney;
        }
        #endregion

        #region 2. Add product
        public void addProduct(DTO_Cart cart, DTO_Product product)
        {
            cart.Products.Add(product);
        }
        #endregion

        #region 3. Delete products
        public void deleteProduct(DTO_Cart cart, DTO_Product product)
        {
            cart.Products.Remove(product);
        }
        #endregion

        #region 4. Show product in Cart
        //ItemOder are products which are in cart
        public List<ItemOder> showProductsInCart(DTO_Cart cart)
        {
            List<ItemOder> listItem = new List<ItemOder>();

            foreach(DTO_Product product in cart.Products.GetAll())
            {
                listItem.Add(new ItemOder(product.TenSP, convertPrice(product.GiaSP), 1));
            }

            return listItem;
        }
        #endregion

        #region 5. convert price from int to string

        public string convertPrice(int price)
        {
            return price + " đ";
        }
        #endregion
    }
}
