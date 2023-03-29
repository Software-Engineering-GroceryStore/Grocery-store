﻿using System;
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
    public partial class DTO_ProductOrderItem : UserControl
    {
        public DTO_ProductOrderItem()
        {
            InitializeComponent();
        }

        #region Properties
        private String _nameItemOder;
        private String _priceItemOder;
        private String _lb_totalItem;
        private void ItemOder_Load(object sender, EventArgs e)
        {
            pb_plus.Click += new System.EventHandler((object sender, EventArgs e) => this.OnClick(e));
            pb_minus.Click += new System.EventHandler((object sender, EventArgs e) => this.OnClick(e));
        }

        private void pb_plus_Click(object sender, EventArgs e)
        {
            int a = int.Parse(this._lb_totalItem) + 1;
            this._lb_totalItem = a.ToString();
        }

        private void pb_minus_Click(object sender, EventArgs e)
        {
            int a = int.Parse(this._lb_totalItem) - 1;
            this._lb_totalItem = a.ToString();
        }

        public DTO_ProductOrderItem(string name, string price, int number)
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