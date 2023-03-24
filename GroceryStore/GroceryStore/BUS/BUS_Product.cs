using GroceryStore.DAO;
using GroceryStore.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.BUS
{
    internal class BUS_Product
    {
        #region 1. Insert product
        public void insertProduct(DTO_Product product)
        {
            DAO_Product dAO_Product = new DAO_Product();
            if(!dAO_Product.checkExistsProduct(product))
            {
                dAO_Product.insertProduct(product);
            }
            else
            {
                MessageBox.Show("Sản phẩm đã tồn tại, Vui lòng đổi sản phẩm khác", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region 2. Delete product
        public void deleteProduct(DTO_Product product)
        {
            DAO_Product dAO_product = new DAO_Product();
            DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này", "Warning", MessageBoxButtons.OKCancel);
            if(dialog == DialogResult.OK)
            {
                dAO_product.deleteProduct(product);
            }
        }
        #endregion

        #region 3. Update product
        public void updateProduct(DTO_Product product)
        {
            DAO_Product dAO_product = new DAO_Product();
            dAO_product.updateProduct(product);
            MessageBox.Show("Cập nhật thành công sản phầm");
        }
        #endregion
    }
}
