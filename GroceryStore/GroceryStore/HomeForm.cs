using BUS;
using DTO;
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


        ProductItem[] listProduct;
        List<ProductOrderItem> orders = new List<ProductOrderItem>();

        private void HomeForm_Load(object sender, EventArgs e)
        {

            //gán giá trị cho comboBox
            cbb_payment.SelectedIndex = 0;
            //tạo mảng chưa sản phẩm
            List<DTO_Product> products = new List<DTO_Product>();

            connectData(products);

            List<DTO_ProductOrderItem> orders = new List<DTO_ProductOrderItem>();
            DTO_ProductItem[] listProduct = new DTO_ProductItem[products.Count];
            for (int i = 0; i < products.Count; i++)
            {
                //thêm dữ liệu lên giao diện
                listProduct[i] = new DTO_ProductItem();
                listProduct[i].NameProduct = products[i].TenSP;
                listProduct[i].PriceProduct = (products[i].GiaSP).ToString() + " đ";

                listProduct[i].ImageProduct = handleUrlImage(products[i].HinhAnh);


                listProduct[i].Click += new System.EventHandler(this.Item_Click);
                flowLayout.Controls.Add(listProduct[i]);
            }
            ProductItem = listProduct;
        }


        private void connectData(List<DTO_Product> products)
        {
            // Kết nối đến database
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

        void Item_Click(object sender, EventArgs e)
        {

            ProductItem obj = (ProductItem)sender;
            flowLayoutItemOder.Controls.Clear();
            ProductOrderItem order = new ProductOrderItem();
            order.NameItemOder = obj.NameProduct;
            order.PriceItemOder = obj.PriceProduct;
            order.NumberOfItem = 1.ToString();
            order.Click += new System.EventHandler(this.order_Click);
            orders.Add(order);
            loadItemOrder();
            calculeteTotalMoney();
        }

        void order_Click(object sender, EventArgs e)
        {
            ProductOrderItem obj = (ProductOrderItem)sender;
            obj.NumberOfItem = obj.NumberOfItem;
            if (int.Parse(obj.NumberOfItem) <= 0)
            {
                orders.Remove(obj);
                loadItemOrder();
            }
            calculeteTotalMoney();
        }

        void calculeteTotalMoney()
        {
            double totalMoney = 0;
            foreach (var item in orders)
            {
                totalMoney += int.Parse(item.PriceItemOder) * int.Parse(item.NumberOfItem);
            }
            lb_totalMoney.Text = totalMoney.ToString();
            lb_pay.Text = totalMoney.ToString();
        }

        void loadItemOrder()
        {
            flowLayoutItemOder.Controls.Clear();
            foreach (var item in orders)
            {
                flowLayoutItemOder.Controls.Add(item);
            }
        }

        private void HomeForm_SizeChanged(object sender, EventArgs e)
        {
            if(this.Width > 1440)
            {
                panel2.Size = new Size((int)(0.65 * this.Width), (int)(0.78 * this.Height));
                flowLayout.Size = new Size((int)(0.65 * this.Width), (int)(0.78 * this.Height));
            }
            else
            {
                panel2.Size = new Size((int)(0.5 * this.Width), (int)(0.78 * this.Height));
                flowLayout.Size = new Size((int)(0.5 * this.Width), (int)(0.78 * this.Height));
            }
        }
    }
}
