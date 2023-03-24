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
        String connectionString = "Data Source=MSI;Initial Catalog=CuaHangTienLoi;Integrated Security=True";
        public HomeForm()
        {
            InitializeComponent();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {

            //gán giá trị cho comboBox
            cbb_payment.SelectedIndex = 0;
            //tạo mảng chưa sản phẩm
            List<DTO_Product> products = new List<DTO_Product>();

            connectData(products);
            Item[] listProduct = new Item[products.Count];
            for (int i = 0; i < products.Count; i++)
            {
                //thêm dữ liệu lên giao diện
                listProduct[i] = new Item();
                listProduct[i].Click += new EventHandler((sender, e) => OnClick(e));
                listProduct[i].NameProduct = products[i].TenSP;
                listProduct[i].PriceProduct = (products[i].GiaSP).ToString() + " đ";

                listProduct[i].ImageProduct = handleUrlImage(products[i].HinhAnh);
                flowLayout.Controls.Add(listProduct[i]);
            }
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

        private Image handleUrlImage(string urlImage)
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] imageBytes = webClient.DownloadData(urlImage);
                using (MemoryStream stream = new MemoryStream(imageBytes))
                {
                    Image image = Image.FromStream(stream);
                    return image;
                }
            }
        }

        void OnClick(EventArgs e)
        {
            MessageBox.Show("aaa");
        }
    }
}
