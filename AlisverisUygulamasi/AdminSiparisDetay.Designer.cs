
namespace AlisverisUygulamasi
{
    partial class AdminSiparisDetay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminSiparisDetay));
            this.label1 = new System.Windows.Forms.Label();
            this.label_siparisID = new System.Windows.Forms.Label();
            this.listBox_urunler = new System.Windows.Forms.ListBox();
            this.txtBox_kargotakipNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_siparisDurumu = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtBox_siparisNotu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Guncelle = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(228, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sipariş ID:";
            // 
            // label_siparisID
            // 
            this.label_siparisID.AutoSize = true;
            this.label_siparisID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_siparisID.ForeColor = System.Drawing.Color.Black;
            this.label_siparisID.Location = new System.Drawing.Point(319, 20);
            this.label_siparisID.Name = "label_siparisID";
            this.label_siparisID.Size = new System.Drawing.Size(52, 18);
            this.label_siparisID.TabIndex = 1;
            this.label_siparisID.Text = "label2";
            // 
            // listBox_urunler
            // 
            this.listBox_urunler.BackColor = System.Drawing.Color.Peru;
            this.listBox_urunler.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBox_urunler.ForeColor = System.Drawing.SystemColors.Menu;
            this.listBox_urunler.FormattingEnabled = true;
            this.listBox_urunler.ItemHeight = 16;
            this.listBox_urunler.Location = new System.Drawing.Point(75, 53);
            this.listBox_urunler.Name = "listBox_urunler";
            this.listBox_urunler.Size = new System.Drawing.Size(480, 292);
            this.listBox_urunler.TabIndex = 2;
            // 
            // txtBox_kargotakipNo
            // 
            this.txtBox_kargotakipNo.Location = new System.Drawing.Point(284, 395);
            this.txtBox_kargotakipNo.Name = "txtBox_kargotakipNo";
            this.txtBox_kargotakipNo.Size = new System.Drawing.Size(190, 20);
            this.txtBox_kargotakipNo.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(150, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kargo Takip No:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(156, 430);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Sipariş durumu:";
            // 
            // comboBox_siparisDurumu
            // 
            this.comboBox_siparisDurumu.FormattingEnabled = true;
            this.comboBox_siparisDurumu.Items.AddRange(new object[] {
            "Teslim edildi",
            "Teslim edilmedi"});
            this.comboBox_siparisDurumu.Location = new System.Drawing.Point(284, 430);
            this.comboBox_siparisDurumu.Name = "comboBox_siparisDurumu";
            this.comboBox_siparisDurumu.Size = new System.Drawing.Size(191, 21);
            this.comboBox_siparisDurumu.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // txtBox_siparisNotu
            // 
            this.txtBox_siparisNotu.Location = new System.Drawing.Point(285, 360);
            this.txtBox_siparisNotu.Name = "txtBox_siparisNotu";
            this.txtBox_siparisNotu.Size = new System.Drawing.Size(190, 20);
            this.txtBox_siparisNotu.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(173, 360);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Sipariş Notu:";
            // 
            // button_Guncelle
            // 
            this.button_Guncelle.BackColor = System.Drawing.Color.DarkGreen;
            this.button_Guncelle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_Guncelle.Location = new System.Drawing.Point(284, 469);
            this.button_Guncelle.Name = "button_Guncelle";
            this.button_Guncelle.Size = new System.Drawing.Size(190, 55);
            this.button_Guncelle.TabIndex = 4;
            this.button_Guncelle.Text = "Güncelle";
            this.button_Guncelle.UseVisualStyleBackColor = false;
            this.button_Guncelle.Click += new System.EventHandler(this.button_Guncelle_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(578, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // AdminSiparisDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(620, 536);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button_Guncelle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBox_siparisDurumu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBox_siparisNotu);
            this.Controls.Add(this.txtBox_kargotakipNo);
            this.Controls.Add(this.listBox_urunler);
            this.Controls.Add(this.label_siparisID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminSiparisDetay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminSiparisDetay";
            this.Load += new System.EventHandler(this.AdminSiparisDetay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_siparisID;
        private System.Windows.Forms.ListBox listBox_urunler;
        private System.Windows.Forms.TextBox txtBox_kargotakipNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_siparisDurumu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtBox_siparisNotu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Guncelle;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}