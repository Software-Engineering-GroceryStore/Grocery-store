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

        ProductItem[] ProductItem;
        List<ProductOrderItem> orders = new List<ProductOrderItem>();
        List<DTO_Product> list_product = new List<DTO_Product>();
        String typeOfProduct = "";

        //Create event when form loaded
        private void HomeForm_Load(object sender, EventArgs e)
        {

            //gán giá trị cho comboBox
            cbb_payment.SelectedIndex = 0;
            //tạo mảng chưa sản phẩm

            List<DTO_Product> products = new List<DTO_Product>();
            flowLayout.Controls.Clear();

            List<ProductOrderItem> orders = new List<ProductOrderItem>();
            loadProduct(products);
            ProductItem[] listProduct = new ProductItem[products.Count];
            list_product.Clear();
            for (int i = 0; i < products.Count; i++)
            {
                //thêm dữ liệu lên giao diện
                listProduct[i] = new ProductItem();
                listProduct[i].NameProduct = products[i].TenSP;
                listProduct[i].PriceProduct = (products[i].GiaSP).ToString() + " đ";

                listProduct[i].ImageProduct = handleUrlImage(products[i].HinhAnh);


                listProduct[i].Click += new System.EventHandler(this.select_Product);
                list_product.Add(products[i]);
                flowLayout.Controls.Add(listProduct[i]);
            }
            ProductItem = listProduct;
        }


        //Load Prodcut to show in homepage
        public void loadProduct(List<DTO_Product> products)
        {
            BUS_ListProduct bus_listproduct = new BUS_ListProduct();
            bus_listproduct.showAllProduct(products);
        }

        //Load FlowLayout when switch selector
        public void loadFlowLayout(String type)
        {
            List<DTO_Product> products = new List<DTO_Product>();
            flowLayout.Controls.Clear();
            loadProduct(list_product, products, type);
            ProductItem[] listProduct = new ProductItem[products.Count];
            for (int i = 0; i < products.Count; i++)
            {
                //thêm dữ liệu lên giao diện
                listProduct[i] = new ProductItem();
                listProduct[i].NameProduct = products[i].TenSP;
                listProduct[i].PriceProduct = (products[i].GiaSP).ToString() + " đ";

                listProduct[i].ImageProduct = handleUrlImage(products[i].HinhAnh);


                listProduct[i].Click += new System.EventHandler(this.select_Product);
                flowLayout.Controls.Add(listProduct[i]);
            }
            
        }

        public void loadProduct(List<DTO_Product> list_products, List<DTO_Product> products, String type)
        {
            BUS_ListProduct bus_listproduct = new BUS_ListProduct();
            bus_listproduct.getProductsByType(list_products, products, type);
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            typeOfProduct = "";
            HomeForm_Load(sender, e);
        }

        private void btn_drinks_Click(object sender, EventArgs e)
        {
            typeOfProduct = "DU";
            loadFlowLayout(typeOfProduct);
        }

        private void btn_fast_foods_Click(object sender, EventArgs e)
        {
            typeOfProduct = "DAV";
            loadFlowLayout(typeOfProduct);
        }

        private void btn_others_Click(object sender, EventArgs e)
        {
            typeOfProduct = "DGD";
            loadFlowLayout(typeOfProduct);
        }




        //Load image throught link
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

        //function to choose product which is showed in User Interface
        void select_Product(object sender, EventArgs e)
        {
            ProductItem obj = (ProductItem)sender;
            flowLayoutItemOder.Controls.Clear();
            ProductOrderItem order = new ProductOrderItem();
            order.NameItemOder = obj.NameProduct;
            order.PriceItemOder = obj.PriceProduct;
            order.NumberOfItem = 1.ToString();
            order.Click += new System.EventHandler(this.select_Product_Cart);
            orders.Add(order);
            show_product_cart();
            calculeteCart();
        }


        void select_Product_Cart(object sender, EventArgs e)
        {
            ProductOrderItem obj = (ProductOrderItem)sender;
            obj.NumberOfItem = obj.NumberOfItem;
            if (int.Parse(obj.NumberOfItem) <= 0)
            {
                orders.Remove(obj);
                show_product_cart();
            }
            calculeteCart();
        }


        //Calculate total money of user's cart
        void calculeteCart()
        {
            double totalMoney = 0;
            foreach (var item in orders)
            {
                totalMoney += int.Parse(item.PriceItemOder) * int.Parse(item.NumberOfItem);
            }
            lb_totalMoney.Text = totalMoney.ToString();
            lb_pay.Text = totalMoney.ToString();
        }

        //Show product in user's cart
        void show_product_cart()
        {
            flowLayoutItemOder.Controls.Clear();
            foreach (var item in orders)
            {
                flowLayoutItemOder.Controls.Add(item);
            }
        }

        //Responsive for homepage when change size of form
        private void HomeForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width > 1440)
            {
                panel2.Size = new Size((int)(0.7 * this.Width), (int)(0.78 * this.Height));
                flowLayout.Size = new Size((int)(0.7 * this.Width), (int)(0.78 * this.Height));
            }
            else
            {
                panel2.Size = new Size((int)(0.5 * this.Width), (int)(0.78 * this.Height));
                flowLayout.Size = new Size((int)(0.5 * this.Width), (int)(0.78 * this.Height));
            }
        }
    }
}
