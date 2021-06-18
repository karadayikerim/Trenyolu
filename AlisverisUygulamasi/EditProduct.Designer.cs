
namespace AlisverisUygulamasi
{
    partial class EditProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditProduct));
            this.picBox_productImageEdit = new System.Windows.Forms.PictureBox();
            this.txtBox_urunAdiEdit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBox_urunStokEdit = new System.Windows.Forms.TextBox();
            this.txtBox_urunFiyatEdit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_urunKategoriEdit = new System.Windows.Forms.ComboBox();
            this.button_saveProductEdit = new System.Windows.Forms.Button();
            this.button_getBack = new System.Windows.Forms.Button();
            this.txtBox_urunID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_editImage = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBox_urunAciklamasi = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_productImageEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // picBox_productImageEdit
            // 
            this.picBox_productImageEdit.Location = new System.Drawing.Point(492, 81);
            this.picBox_productImageEdit.Name = "picBox_productImageEdit";
            this.picBox_productImageEdit.Size = new System.Drawing.Size(200, 200);
            this.picBox_productImageEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox_productImageEdit.TabIndex = 0;
            this.picBox_productImageEdit.TabStop = false;
            // 
            // txtBox_urunAdiEdit
            // 
            this.txtBox_urunAdiEdit.Location = new System.Drawing.Point(170, 44);
            this.txtBox_urunAdiEdit.Name = "txtBox_urunAdiEdit";
            this.txtBox_urunAdiEdit.Size = new System.Drawing.Size(195, 20);
            this.txtBox_urunAdiEdit.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(81, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ürün Adı:";
            // 
            // txtBox_urunStokEdit
            // 
            this.txtBox_urunStokEdit.Location = new System.Drawing.Point(170, 238);
            this.txtBox_urunStokEdit.Name = "txtBox_urunStokEdit";
            this.txtBox_urunStokEdit.Size = new System.Drawing.Size(195, 20);
            this.txtBox_urunStokEdit.TabIndex = 1;
            // 
            // txtBox_urunFiyatEdit
            // 
            this.txtBox_urunFiyatEdit.Location = new System.Drawing.Point(170, 201);
            this.txtBox_urunFiyatEdit.Name = "txtBox_urunFiyatEdit";
            this.txtBox_urunFiyatEdit.Size = new System.Drawing.Size(195, 20);
            this.txtBox_urunFiyatEdit.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(114, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Stok:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(114, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fiyat:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(84, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Kategori:";
            // 
            // comboBox_urunKategoriEdit
            // 
            this.comboBox_urunKategoriEdit.FormattingEnabled = true;
            this.comboBox_urunKategoriEdit.Items.AddRange(new object[] {
            "Elektronik",
            "Moda",
            "Ev Yaşam",
            "Oto, Bahçe, Yapı Malzemesi",
            "Anne, Bebek, Oyuncak",
            "Spor, Outdoor",
            "Kozmetik, Kişisel Bakım",
            "Süpermarket",
            "Kitap, Müzik, Film, Hobi"});
            this.comboBox_urunKategoriEdit.Location = new System.Drawing.Point(170, 276);
            this.comboBox_urunKategoriEdit.Name = "comboBox_urunKategoriEdit";
            this.comboBox_urunKategoriEdit.Size = new System.Drawing.Size(195, 21);
            this.comboBox_urunKategoriEdit.TabIndex = 3;
            // 
            // button_saveProductEdit
            // 
            this.button_saveProductEdit.BackColor = System.Drawing.Color.DarkGreen;
            this.button_saveProductEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_saveProductEdit.ForeColor = System.Drawing.Color.White;
            this.button_saveProductEdit.Location = new System.Drawing.Point(111, 363);
            this.button_saveProductEdit.Name = "button_saveProductEdit";
            this.button_saveProductEdit.Size = new System.Drawing.Size(123, 45);
            this.button_saveProductEdit.TabIndex = 4;
            this.button_saveProductEdit.Text = "Kaydet";
            this.button_saveProductEdit.UseVisualStyleBackColor = false;
            this.button_saveProductEdit.Click += new System.EventHandler(this.button_saveProductEdit_Click);
            // 
            // button_getBack
            // 
            this.button_getBack.BackColor = System.Drawing.SystemColors.Highlight;
            this.button_getBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_getBack.ForeColor = System.Drawing.Color.White;
            this.button_getBack.Location = new System.Drawing.Point(286, 363);
            this.button_getBack.Name = "button_getBack";
            this.button_getBack.Size = new System.Drawing.Size(123, 45);
            this.button_getBack.TabIndex = 5;
            this.button_getBack.Text = "Geri Dön";
            this.button_getBack.UseVisualStyleBackColor = false;
            this.button_getBack.Click += new System.EventHandler(this.button_getBack_Click);
            // 
            // txtBox_urunID
            // 
            this.txtBox_urunID.Location = new System.Drawing.Point(170, 312);
            this.txtBox_urunID.Name = "txtBox_urunID";
            this.txtBox_urunID.ReadOnly = true;
            this.txtBox_urunID.Size = new System.Drawing.Size(195, 20);
            this.txtBox_urunID.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(88, 310);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Ürün ID:";
            // 
            // button_editImage
            // 
            this.button_editImage.BackColor = System.Drawing.Color.SlateBlue;
            this.button_editImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_editImage.ForeColor = System.Drawing.Color.White;
            this.button_editImage.Location = new System.Drawing.Point(516, 287);
            this.button_editImage.Name = "button_editImage";
            this.button_editImage.Size = new System.Drawing.Size(158, 45);
            this.button_editImage.TabIndex = 6;
            this.button_editImage.Text = "Fotoğrafı Değiştir";
            this.button_editImage.UseVisualStyleBackColor = false;
            this.button_editImage.Click += new System.EventHandler(this.button_editImage_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(22, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Ürün Açıklaması:";
            // 
            // txtBox_urunAciklamasi
            // 
            this.txtBox_urunAciklamasi.Location = new System.Drawing.Point(170, 75);
            this.txtBox_urunAciklamasi.Multiline = true;
            this.txtBox_urunAciklamasi.Name = "txtBox_urunAciklamasi";
            this.txtBox_urunAciklamasi.Size = new System.Drawing.Size(195, 115);
            this.txtBox_urunAciklamasi.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkRed;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(516, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 44);
            this.button1.TabIndex = 8;
            this.button1.Text = "Ürünü Sil (X)";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(694, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // EditProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 452);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBox_urunAciklamasi);
            this.Controls.Add(this.button_editImage);
            this.Controls.Add(this.button_getBack);
            this.Controls.Add(this.button_saveProductEdit);
            this.Controls.Add(this.comboBox_urunKategoriEdit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBox_urunID);
            this.Controls.Add(this.txtBox_urunFiyatEdit);
            this.Controls.Add(this.txtBox_urunStokEdit);
            this.Controls.Add(this.txtBox_urunAdiEdit);
            this.Controls.Add(this.picBox_productImageEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditProduct";
            this.Load += new System.EventHandler(this.EditProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_productImageEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox_productImageEdit;
        private System.Windows.Forms.TextBox txtBox_urunAdiEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBox_urunStokEdit;
        private System.Windows.Forms.TextBox txtBox_urunFiyatEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_urunKategoriEdit;
        private System.Windows.Forms.Button button_saveProductEdit;
        private System.Windows.Forms.Button button_getBack;
        private System.Windows.Forms.TextBox txtBox_urunID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_editImage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBox_urunAciklamasi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}