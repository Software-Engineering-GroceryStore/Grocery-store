using GroceryStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroceryStore.BUS
{
    internal class BUS_ProductItem
    {

        List<DTO_ProductOderItem> orders = new List<DTO_ProductOderItem>();
        #region 1. Create Product Item
        public DTO_ProductItem createProductItem(DTO_Product a)
        {
            DTO_ProductItem productItem = new DTO_ProductItem();
            productItem.Click += new System.EventHandler(this.Item_Click);
            productItem.NameProduct = a.TenSP;
            productItem.PriceProduct = a.GiaSP.ToString();
            productItem.ImageProduct = handleUrlImage(a.HinhAnh);
            return productItem;
        }
        #endregion


        public void Item_Click(object sender, EventArgs e)
        {

            DTO_ProductItem obj = (DTO_ProductItem)sender;
            FlowLayoutPanel panel = (FlowLayoutPanel)sender;
            Label lb_totalMoney = (Label)sender;
            Label lb_pay = (Label)sender;
            panel.Controls.Clear();
            DTO_ProductOderItem order = new DTO_ProductOderItem();
            order.NameItemOder = obj.NameProduct;
            order.PriceItemOder = obj.PriceProduct;
            order.NumberOfItem = "1";
            order.Click += new System.EventHandler(this.order_Click);
            orders.Add(order);
            loadItemOrder(panel); ;
            calculeteTotalMoney(lb_totalMoney, lb_pay);
        }

        public void order_Click(object sender, EventArgs e)
        {
            DTO_ProductOderItem obj = (DTO_ProductOderItem)sender;
            Label lb_totalMoney = (Label)sender;
            Label lb_pay = (Label)sender;
            FlowLayoutPanel panel = ( FlowLayoutPanel)sender;
            obj.NumberOfItem = obj.NumberOfItem;
            if (int.Parse(obj.NumberOfItem) <= 0)
            {
                orders.Remove(obj);
                loadItemOrder(panel);
            }
            calculeteTotalMoney(lb_totalMoney, lb_pay);
        }

        public void calculeteTotalMoney(Label lb_totalMoney, Label lb_pay)
        {
            int totalMoney = 0;
            foreach (var item in orders)
            {
                totalMoney += int.Parse(item.PriceItemOder) * int.Parse(item.NumberOfItem);
            }
            lb_totalMoney.Text = totalMoney.ToString();
            lb_pay.Text = totalMoney.ToString();
        }

        public void loadItemOrder(FlowLayoutPanel panel)
        {
            panel.Controls.Clear();
            foreach (var item in orders)
            {
                panel.Controls.Add(item);
            }
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
    }
}
