using GroceryStore.BUS;
using GroceryStore.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroceryStore
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        DTO_ProductItem[] ProductItem;

        private void HomeForm_Load(object sender, EventArgs e)
        {

            //gán giá trị cho comboBox
            cbb_payment.SelectedIndex = 0;
            //tạo mảng chưa sản phẩm
            List<DTO_Product> products = new List<DTO_Product>();

            connectData(products);

            List<DTO_ProductOrderItem> orders = new List<DTO_ProductOrderItem>();
            BUS_ProductItem bus_prod = new BUS_ProductItem(orders, flowLayoutItemOder, lb_totalMoney, lb_pay);
            DTO_ProductItem[] listProduct = new DTO_ProductItem[products.Count];

            for (int i = 0; i < products.Count; i++)
            {
                //thêm dữ liệu lên giao diện
                listProduct[i] = bus_prod.createProductItem(products[i]);

                //listProduct[i].Click += new EventHandler((sender, e) => OnClick(e));
                //listProduct[i].NameProduct = products[i].TenSP;
                //listProduct[i].PriceProduct = (products[i].GiaSP).ToString() + " đ";

                //listProduct[i].ImageProduct = handleUrlImage(products[i].HinhAnh);


                flowLayout.Controls.Add(listProduct[i]);
            }
            ProductItem = listProduct;
        }


        private void connectData(List<DTO_Product> products)
        {
            // Kết nối đến database
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();

            //    string sql = "SELECT TenSP, GiaSP, HinhAnh FROM SanPham";
            //    SqlCommand command = new SqlCommand(sql, connection);

            //    using (SqlDataReader reader = command.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            string tenSp = reader.GetString(0);
            //            string giaSp = reader.GetString(1);
            //            string hinhAnh = reader.GetString(2);


            //            DTO_Product product = new DTO_Product(tenSp, giaSp, hinhAnh);
            //            products.Add(product);
            //        }
            //    }
            //}
            BUS_ListProduct bus_listproduct = new BUS_ListProduct();
            bus_listproduct.showAllProduct(products);
        }

        private void HomeForm_SizeChanged(object sender, EventArgs e)
        {
            //panel3.Size = new Size((int)(0.25 * this.Width), (int)(0.78 * this.Height));
            panel2.Size = new Size((int)(0.67 * this.Width), (int)(0.78 * this.Height));
            flowLayout.Size = new Size((int)(0.67 * this.Width), (int)(0.78 * this.Height));
        }
    }
}
