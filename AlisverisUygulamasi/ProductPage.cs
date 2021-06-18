using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace AlisverisUygulamasi
{
    public partial class ProductPage : Form
    {
        public int urunIDgelenBilgi;
        string productName_;
        string productImage_;
        string productCategory_;
        string productDetails_;
        int productAmount_;
        double productPrice_;

        SQLiteConnection dbConnection;

        public ProductPage()
        {
            InitializeComponent();
        }

        private void ProductPage_Load(object sender, EventArgs e)
        {
            dbConnection = new SQLiteConnection("Data Source=TrenyoluDB.sqlite;Version=3;");
            SQLiteCommand urunSayfasiKomut = new SQLiteCommand("SELECT * FROM UrunListesi WHERE urunID = @IDSorgu", dbConnection);

            dbConnection.Open();
            urunSayfasiKomut.Parameters.AddWithValue("@IDSorgu", urunIDgelenBilgi);
            SQLiteDataReader drUrun = urunSayfasiKomut.ExecuteReader();

            while (drUrun.Read())
            {
                productName_ = drUrun["urunAdi"].ToString();
                productPrice_ = Convert.ToDouble(drUrun["urunFiyati"].ToString());
                productImage_ = drUrun["urunResmi"].ToString();
                productCategory_ = drUrun["urunKategorisi"].ToString();
                productAmount_ = Convert.ToInt32(drUrun["urunStok"].ToString());
                productDetails_ = drUrun["urunAciklamasi"].ToString();
            }

            drUrun.Close();
            dbConnection.Close();

            pictureBox_urunResmi.Image = new Bitmap(productImage_);
            label_productPrice.Text = productPrice_.ToString() + "₺";
            label_productAmount.Text = productAmount_.ToString();


            //Ürün adı
            Label label_productName = new Label();
            //label.BackColor = Color.Red;
            label_productName.Dock = DockStyle.Fill;
            label_productName.Font = new Font("Segou UI", 11, FontStyle.Bold);
            label_productName.Size = new Size(455, 57);
            label_productName.Name = "label_productDetails";
            label_productName.ForeColor = Color.White;
            label_productName.BackColor = Color.Maroon;
            label_productName.Text = productName_;
            label_productName.TextAlign = ContentAlignment.MiddleCenter;


            panel1.Controls.Add(label_productName);

            //Ürün Detayları
            richTextBox1.Text = productDetails_;

            //Stokta yok için if sorgusu
            if (productAmount_ == 0)
            {
                label_productAmount.Text = "Stokta Yok";

            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.Show();
            this.Hide();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
