
namespace AlisverisUygulamasi
{
    partial class AddProduct
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProduct));
            this.txtBox_productName = new System.Windows.Forms.TextBox();
            this.txtBox_productDetails = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBox_productAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.picBox_productImage = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox_productCategory = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_saveProduct = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.isProductNameEmpty = new System.Windows.Forms.Label();
            this.isProductPriceEmpty = new System.Windows.Forms.Label();
            this.isProductDetailsEmpty = new System.Windows.Forms.Label();
            this.isProductAmountEmpty = new System.Windows.Forms.Label();
            this.isProductCategoryEmpty = new System.Windows.Forms.Label();
            this.isProductImageEmpty = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtBox_productPrice = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_productImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBox_productName
            // 
            this.txtBox_productName.Location = new System.Drawing.Point(208, 35);
            this.txtBox_productName.Name = "txtBox_productName";
            this.txtBox_productName.Size = new System.Drawing.Size(253, 20);
            this.txtBox_productName.TabIndex = 1;
            // 
            // txtBox_productDetails
            // 
            this.txtBox_productDetails.Location = new System.Drawing.Point(208, 120);
            this.txtBox_productDetails.Multiline = true;
            this.txtBox_productDetails.Name = "txtBox_productDetails";
            this.txtBox_productDetails.Size = new System.Drawing.Size(253, 126);
            this.txtBox_productDetails.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(118, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ürün Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(101, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ürün Fiyatı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(59, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ürün Açıklaması:";
            // 
            // txtBox_productAmount
            // 
            this.txtBox_productAmount.Location = new System.Drawing.Point(208, 279);
            this.txtBox_productAmount.Name = "txtBox_productAmount";
            this.txtBox_productAmount.Size = new System.Drawing.Size(253, 20);
            this.txtBox_productAmount.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(151, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Stok:";
            // 
            // picBox_productImage
            // 
            this.picBox_productImage.Image = ((System.Drawing.Image)(resources.GetObject("picBox_productImage.Image")));
            this.picBox_productImage.Location = new System.Drawing.Point(542, 23);
            this.picBox_productImage.Name = "picBox_productImage";
            this.picBox_productImage.Size = new System.Drawing.Size(200, 200);
            this.picBox_productImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox_productImage.TabIndex = 2;
            this.picBox_productImage.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(542, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 60);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ürün Resmi Ekle";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox_productCategory
            // 
            this.comboBox_productCategory.FormattingEnabled = true;
            this.comboBox_productCategory.Items.AddRange(new object[] {
            "Elektronik",
            "Moda",
            "Ev Yaşam",
            "Oto, Bahçe, Yapı Malzemesi",
            "Anne, Bebek, Oyuncak",
            "Spor, Outdoor",
            "Kozmetik, Kişisel Bakım",
            "Süpermarket",
            "Kitap, Müzik, Film, Hobi"});
            this.comboBox_productCategory.Location = new System.Drawing.Point(208, 330);
            this.comboBox_productCategory.Name = "comboBox_productCategory";
            this.comboBox_productCategory.Size = new System.Drawing.Size(253, 21);
            this.comboBox_productCategory.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(121, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Kategori:";
            // 
            // button_saveProduct
            // 
            this.button_saveProduct.BackColor = System.Drawing.Color.DarkGreen;
            this.button_saveProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.button_saveProduct.Location = new System.Drawing.Point(99, 404);
            this.button_saveProduct.Name = "button_saveProduct";
            this.button_saveProduct.Size = new System.Drawing.Size(184, 68);
            this.button_saveProduct.TabIndex = 5;
            this.button_saveProduct.Text = "Kaydet";
            this.button_saveProduct.UseVisualStyleBackColor = false;
            this.button_saveProduct.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkRed;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.Location = new System.Drawing.Point(322, 404);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(184, 68);
            this.button3.TabIndex = 6;
            this.button3.Text = "Temizle";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // isProductNameEmpty
            // 
            this.isProductNameEmpty.AutoSize = true;
            this.isProductNameEmpty.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.isProductNameEmpty.Location = new System.Drawing.Point(205, 58);
            this.isProductNameEmpty.Name = "isProductNameEmpty";
            this.isProductNameEmpty.Size = new System.Drawing.Size(0, 13);
            this.isProductNameEmpty.TabIndex = 7;
            // 
            // isProductPriceEmpty
            // 
            this.isProductPriceEmpty.AutoSize = true;
            this.isProductPriceEmpty.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.isProductPriceEmpty.Location = new System.Drawing.Point(205, 101);
            this.isProductPriceEmpty.Name = "isProductPriceEmpty";
            this.isProductPriceEmpty.Size = new System.Drawing.Size(0, 13);
            this.isProductPriceEmpty.TabIndex = 7;
            // 
            // isProductDetailsEmpty
            // 
            this.isProductDetailsEmpty.AutoSize = true;
            this.isProductDetailsEmpty.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.isProductDetailsEmpty.Location = new System.Drawing.Point(205, 249);
            this.isProductDetailsEmpty.Name = "isProductDetailsEmpty";
            this.isProductDetailsEmpty.Size = new System.Drawing.Size(0, 13);
            this.isProductDetailsEmpty.TabIndex = 7;
            // 
            // isProductAmountEmpty
            // 
            this.isProductAmountEmpty.AutoSize = true;
            this.isProductAmountEmpty.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.isProductAmountEmpty.Location = new System.Drawing.Point(205, 302);
            this.isProductAmountEmpty.Name = "isProductAmountEmpty";
            this.isProductAmountEmpty.Size = new System.Drawing.Size(0, 13);
            this.isProductAmountEmpty.TabIndex = 7;
            // 
            // isProductCategoryEmpty
            // 
            this.isProductCategoryEmpty.AutoSize = true;
            this.isProductCategoryEmpty.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.isProductCategoryEmpty.Location = new System.Drawing.Point(205, 354);
            this.isProductCategoryEmpty.Name = "isProductCategoryEmpty";
            this.isProductCategoryEmpty.Size = new System.Drawing.Size(0, 13);
            this.isProductCategoryEmpty.TabIndex = 7;
            // 
            // isProductImageEmpty
            // 
            this.isProductImageEmpty.AutoSize = true;
            this.isProductImageEmpty.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.isProductImageEmpty.Location = new System.Drawing.Point(539, 302);
            this.isProductImageEmpty.Name = "isProductImageEmpty";
            this.isProductImageEmpty.Size = new System.Drawing.Size(0, 13);
            this.isProductImageEmpty.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.GreenYellow;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(542, 405);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(184, 68);
            this.button2.TabIndex = 8;
            this.button2.Text = "Geri Dön";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // txtBox_productPrice
            // 
            this.txtBox_productPrice.Location = new System.Drawing.Point(208, 78);
            this.txtBox_productPrice.Name = "txtBox_productPrice";
            this.txtBox_productPrice.Size = new System.Drawing.Size(253, 20);
            this.txtBox_productPrice.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(758, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 511);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.isProductImageEmpty);
            this.Controls.Add(this.isProductCategoryEmpty);
            this.Controls.Add(this.isProductAmountEmpty);
            this.Controls.Add(this.isProductDetailsEmpty);
            this.Controls.Add(this.isProductPriceEmpty);
            this.Controls.Add(this.isProductNameEmpty);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_saveProduct);
            this.Controls.Add(this.comboBox_productCategory);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picBox_productImage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBox_productDetails);
            this.Controls.Add(this.txtBox_productAmount);
            this.Controls.Add(this.txtBox_productPrice);
            this.Controls.Add(this.txtBox_productName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddProduct";
            this.Load += new System.EventHandler(this.AddProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_productImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBox_productName;
        private System.Windows.Forms.TextBox txtBox_productDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBox_productAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picBox_productImage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox_productCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_saveProduct;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label isProductNameEmpty;
        private System.Windows.Forms.Label isProductPriceEmpty;
        private System.Windows.Forms.Label isProductDetailsEmpty;
        private System.Windows.Forms.Label isProductAmountEmpty;
        private System.Windows.Forms.Label isProductCategoryEmpty;
        private System.Windows.Forms.Label isProductImageEmpty;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtBox_productPrice;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}