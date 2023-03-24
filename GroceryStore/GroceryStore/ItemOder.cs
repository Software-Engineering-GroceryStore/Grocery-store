using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroceryStore
{
    public partial class ItemOder : UserControl
    {
        public ItemOder()
        {
            InitializeComponent();
        }

        #region Properties
        private String _nameItemOder;
        private String _priceItemOder;
        private String _lb_totalItem;

        public ItemOder(string name, string price, int number)
        {
            this.lb_nameItemOder.Text = name;
            this.lb_priceItemOder.Text = price;
            this.lb_totalItem.Text = number.ToString();
        }

        [Category("N5")]
        public String NameItemOder
        {
            get { return _nameItemOder; }
            set { _nameItemOder = value; lb_nameItemOder.Text = value; }
        }

        [Category("N5")]
        public String PriceItemOder
        {
            get { return _priceItemOder; }
            set { _priceItemOder = value; lb_priceItemOder.Text = value; }
        }

        [Category("N5")]
        public string NumberOfItem
        {
            get { return _lb_totalItem; }
            set { _lb_totalItem = value; lb_totalItem.Text = value; }
        }

        #endregion
    }
}
