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
    public partial class Item : System.Windows.Forms.UserControl
    {
        public Item()
        {
            InitializeComponent();
        }

        #region Properties
        private Image _imageProduct;
        private String _nameProduct;
        private String _priceProduct;

        private void itemClick(object sender, EventArgs e)
        {

        }

        private void Item_Load(object sender, EventArgs e)
        {
            pb_imageProduct.Click += new System.EventHandler((object sender, EventArgs e) => this.OnClick(e));
        }

        [Category("N5")]
        public Image ImageProduct
        {
            get { return _imageProduct; }
            set { _imageProduct = value; pb_imageProduct.Image = value; }
        }

        [Category("N5")]
        public String NameProduct
        {
            get { return _nameProduct; }
            set { _nameProduct = value; lb_nameProduct.Text = value; }
        }

        [Category("N5")]
        public String PriceProduct
        {
            get { return _priceProduct; }
            set { _priceProduct = value; lb_priceProduct.Text = value; }
        }

        #endregion
    }
}

