using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_ListProduct
    {
        #region 1. Insert products
        public void insertProduct(DTO_ListProduct products)
        {
            foreach (DTO_Product product in products.GetAll())
            {
                DAO_Product dAO_Product = new DAO_Product();
                dAO_Product.insertProduct(product);
            }
        }
        #endregion


        #region 2.Delete products
        public void deleteProducts(DTO_ListProduct products)
        {
            foreach (DTO_Product product in products.GetAll())
            {
                DAO_Product dAO_Product = new DAO_Product();
                dAO_Product.deleteProduct(product);
            }
        }
        #endregion

        #region 3. Show all products
        public void showAllProduct(List<DTO_Product> products)
        {
            DAO_ListProduct dAO_listProduct = new DAO_ListProduct();
            foreach(DataRow row in dAO_listProduct.showAllProducts().Rows)
            {
                DTO_Product product = new DTO_Product((String)row[0],  Convert.ToInt32(row[1]), (String)row[2], (String)row[3]);
                products.Add(product);
            }
        }
        #endregion

        #region 4. get products by type
        public void getProductsByType(List<DTO_Product> list_products, List<DTO_Product> products, String type)
        {
            foreach (DTO_Product product in list_products)
            {
                if(product.LoaiSP == type)
                {
                    products.Add(product);
                }
            }
        }
        #endregion
    }
}
