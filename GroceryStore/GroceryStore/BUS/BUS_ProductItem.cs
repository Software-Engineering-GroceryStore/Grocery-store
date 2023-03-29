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

        private List<DTO_ProductOrderItem> orders;
        private FlowLayoutPanel ItemOderPanel;
        private Label lb_totalMoney;
        private Label lb_pay;

        public BUS_ProductItem(List<DTO_ProductOrderItem> orders, FlowLayoutPanel ItemOderPanel, Label lb_totalMoney, Label lb_pay)
        {
            this.orders = orders;
            this.ItemOderPanel = ItemOderPanel;
            this.lb_pay = lb_pay;
            this.lb_totalMoney = lb_totalMoney;
        }
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
            //ItemOderPanel.Controls.Clear();
            DTO_ProductOrderItem order = new DTO_ProductOrderItem();
            order.NameItemOder = obj.NameProduct;
            order.PriceItemOder = obj.PriceProduct;
            order.NumberOfItem = "1";
            order.Click += new System.EventHandler(this.order_Click);
            orders.Add(order);
            loadItemOrder(ItemOderPanel);
            calculeteTotalMoney(orders, lb_totalMoney, lb_pay);
        }

        public void order_Click(object sender, EventArgs e)
        {
            DTO_ProductOrderItem obj = (DTO_ProductOrderItem)sender;
            obj.NumberOfItem = obj.NumberOfItem;
            if (int.Parse(obj.NumberOfItem) <= 0)
            {
                orders.Remove(obj);
                loadItemOrder(ItemOderPanel);
            }
            calculeteTotalMoney(orders, lb_totalMoney, lb_pay);
        }

        void calculeteTotalMoney(List<DTO_ProductOrderItem> orders, Label lb_totalMoney, Label lb_pay)
        {
            int totalMoney = 0;
            foreach (var item in orders)
            {
                totalMoney += int.Parse(item.PriceItemOder) * int.Parse(item.NumberOfItem);
            }
            lb_totalMoney.Text = totalMoney.ToString();
            lb_pay.Text = totalMoney.ToString();
        }

        void loadItemOrder(FlowLayoutPanel panel)
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
