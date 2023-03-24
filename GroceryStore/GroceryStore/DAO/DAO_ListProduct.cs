using GroceryStore.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.DAO
{
    internal class DAO_ListProduct
    {
        #region 1. Show all products 
        public DataTable showAllProducts()
        {
            string statement = "SELECT TenSP, GiaSP, HinhAnh, LoaiSP FROM SanPham";
            return DataProvider.Instance.ExecuteQuery(statement);
        }
        #endregion
    }
}
