namespace GroceryStore
{
    partial class Item
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            item_panel = new Guna.UI2.WinForms.Guna2GradientPanel();
            lb_nameProduct = new Label();
            lb_priceProduct = new Label();
            pb_imageProduct = new PictureBox();
            item_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_imageProduct).BeginInit();
            SuspendLayout();
            // 
            // item_panel
            // 
            item_panel.BackColor = Color.White;
            item_panel.BorderRadius = 10;
            item_panel.Controls.Add(lb_nameProduct);
            item_panel.Controls.Add(lb_priceProduct);
            item_panel.Controls.Add(pb_imageProduct);
            item_panel.CustomizableEdges = customizableEdges1;
            item_panel.Location = new Point(8, 8);
            item_panel.Name = "item_panel";
            item_panel.ShadowDecoration.CustomizableEdges = customizableEdges2;
            item_panel.Size = new Size(161, 249);
            item_panel.TabIndex = 0;
            // 
            // lb_nameProduct
            // 
            lb_nameProduct.BackColor = Color.White;
            lb_nameProduct.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lb_nameProduct.Location = new Point(13, 190);
            lb_nameProduct.MaximumSize = new Size(180, 50);
            lb_nameProduct.Name = "lb_nameProduct";
            lb_nameProduct.Size = new Size(136, 50);
            lb_nameProduct.TabIndex = 2;
            lb_nameProduct.Text = "Khoai tây chiên kdhdshdf";
            lb_nameProduct.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lb_priceProduct
            // 
            lb_priceProduct.AutoSize = true;
            lb_priceProduct.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            lb_priceProduct.Location = new Point(45, 167);
            lb_priceProduct.Name = "lb_priceProduct";
            lb_priceProduct.Size = new Size(72, 23);
            lb_priceProduct.TabIndex = 1;
            lb_priceProduct.Text = "15.000 đ";
            // 
            // pb_imageProduct
            // 
            pb_imageProduct.BackColor = Color.White;
            pb_imageProduct.Image = Properties.Resources.producDemo;
            pb_imageProduct.Location = new Point(3, 10);
            pb_imageProduct.Name = "pb_imageProduct";
            pb_imageProduct.Size = new Size(155, 146);
            pb_imageProduct.SizeMode = PictureBoxSizeMode.Zoom;
            pb_imageProduct.TabIndex = 0;
            pb_imageProduct.TabStop = false;
            // 
            // Item
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(item_panel);
            Margin = new Padding(0);
            MaximumSize = new Size(181, 259);
            MinimumSize = new Size(181, 259);
            Name = "Item";
            Size = new Size(181, 259);
            Load += Item_Load;
            Click += itemClick;
            item_panel.ResumeLayout(false);
            item_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_imageProduct).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel item_panel;
        private Label lb_nameProduct;
        private Label lb_priceProduct;
        private PictureBox pb_imageProduct;
    }
}
