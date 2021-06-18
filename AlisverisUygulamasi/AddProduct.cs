using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace AlisverisUygulamasi
{
    public partial class AddProduct : Form
    {
        //SQL BAĞLANTISI
        SQLiteConnection dbConnection = new SQLiteConnection("Data Source=TrenyoluDB.sqlite;Version=3;");

        string urunResmi;

        Random random = new Random();
        int RandomID;
        void IDCheck()
        {

            RandomID = random.Next(100000, 1000000);

            bool duplicatedID = true;
            while (duplicatedID == true)
            {
                dbConnection.Open();
                SQLiteCommand isIdDuplicate = new SQLiteCommand("SELECT * FROM UrunListesi WHERE urunID = @IDSorgu", dbConnection);
                isIdDuplicate.Parameters.AddWithValue("@IDSorgu", RandomID);
                SQLiteDataReader drID = isIdDuplicate.ExecuteReader();

                if (drID.Read())
                {
                    duplicatedID = true;
                    RandomID = random.Next(100000, 1000000);
                }

                else
                {
                    duplicatedID = false;
                }
                dbConnection.Close();
            }
        }

        public AddProduct()
        {
            InitializeComponent();
        }
        string fileExt;
        string destinationFile;
        private void button1_Click(object sender, EventArgs e)
        {
            IDCheck();

            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {

                fileExt = System.IO.Path.GetExtension(open.FileName);
                System.IO.Directory.CreateDirectory("images");
                destinationFile = "images\\" + RandomID + fileExt;

                File.Copy(open.FileName, destinationFile);

                // display image in picture box  
                picBox_productImage.Image = new Bitmap(destinationFile);
                // image file path  
                urunResmi = destinationFile;
            }
        }
        public void clearIsEmptyAndtxtBoxes()
        {
            isProductNameEmpty.Text = "";
            isProductPriceEmpty.Text = "";
            isProductDetailsEmpty.Text = "";
            isProductCategoryEmpty.Text = "";
            isProductDetailsEmpty.Text = "";
            isProductImageEmpty.Text = "";
            isProductAmountEmpty.Text = "";
            txtBox_productAmount.Text = "";
            txtBox_productDetails.Text = "";
            txtBox_productName.Text = "";
            txtBox_productPrice.Text = "";
            comboBox_productCategory.Text = "";
            urunResmi = null;
            picBox_productImage.Image = new Bitmap("sources\\no-image.png");
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

            for (int k = 0; k < 2; k++)
            {
                if (txtBox_productName.Text == "" || txtBox_productDetails.Text == "" || txtBox_productAmount.Text == "" || txtBox_productPrice.Text == ""
                    || urunResmi == null || comboBox_productCategory.Text == "")
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (i == 0)
                        {
                            if (txtBox_productName.Text == "")
                            {
                                isProductNameEmpty.Text = "Lütfen ürünün ismini giriniz!";
                            }

                            else
                            {
                                isProductNameEmpty.Text = "";
                            }
                        }

                        if (i == 1)
                        {
                            if (txtBox_productPrice.Text == "")
                            {
                                isProductPriceEmpty.Text = "Lütfen ürünün fiyatını giriniz!";
                            }

                            else
                            {
                                isProductPriceEmpty.Text = "";
                            }
                        }

                        if (i == 2)
                        {
                            if (txtBox_productDetails.Text == "")
                            {
                                isProductDetailsEmpty.Text = "Lütfen ürünün açıklamasını giriniz!";
                            }

                            else
                            {
                                isProductDetailsEmpty.Text = "";
                            }
                        }

                        if (i == 3)
                        {
                            if (txtBox_productAmount.Text == "")
                            {
                                isProductAmountEmpty.Text = "Lütfen ürünün stok adedini giriniz!";
                            }

                            else
                            {
                                isProductAmountEmpty.Text = "";
                            }
                        }

                        if (i == 4)
                        {
                            if (comboBox_productCategory.Text == "")
                            {
                                isProductCategoryEmpty.Text = "Lütfen ürünün kategorisini giriniz!";
                            }

                            else
                            {
                                isProductCategoryEmpty.Text = "";
                            }
                        }

                        if (i == 5)
                        {
                            if (urunResmi == null)
                            {
                                isProductImageEmpty.Text = "Lütfen ürünün resmini seçiniz!";
                            }

                            else
                            {
                                isProductImageEmpty.Text = "";
                            }
                        }
                    }
                }
                
                else
                {
                    dbConnection.Open();

                    SQLiteCommand addProduct = new SQLiteCommand("INSERT INTO UrunListesi (urunAdi, urunFiyati, urunAciklamasi, urunKategorisi, " +
                    "urunResmi, urunStok, urunID) " +
                    "values (@ad, @fiyat, @aciklama, @kategori, @resim, @stok, @ID)", dbConnection);
                    addProduct.Parameters.AddWithValue("@ad", txtBox_productName.Text);
                    addProduct.Parameters.AddWithValue("@fiyat", Convert.ToDouble(txtBox_productPrice.Text));
                    addProduct.Parameters.AddWithValue("@aciklama", txtBox_productDetails.Text);
                    addProduct.Parameters.AddWithValue("@kategori", comboBox_productCategory.Text);
                    addProduct.Parameters.AddWithValue("@resim", urunResmi); //Boolean cinsiyet
                    addProduct.Parameters.AddWithValue("@stok", Convert.ToInt32(txtBox_productAmount.Text));
                    addProduct.Parameters.AddWithValue("@ID", RandomID); //RANDOM ID
                    addProduct.ExecuteNonQuery();
                    dbConnection.Close();
                    MessageBox.Show("Ürün başarıyla kaydedildi!");
                    clearIsEmptyAndtxtBoxes();
                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clearIsEmptyAndtxtBoxes();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            adminPage.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
