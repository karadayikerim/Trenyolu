using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
namespace AlisverisUygulamasi
{
    public partial class MainPage : Form
    {
        SQLiteConnection dbConnection;
        int urunListeSayac = 0;
        string productName_;
        string productImage_;
        string productCategory_;
        string productDetails_;
        int productAmount_;
        int productID_;
        double productPrice_;
        public int pageNumber = 0;
        int tmpPageNumber = 0;
        public static int k;

        public static int[] urunSepetID = new int[22];

        public MainPage()
        {
            InitializeComponent();
        }
        Products[] product;

        void UrunleriEslestir(int UrunSirasi, int UrunAdedi)
        {
            SQLiteCommand urunMainKomut = new SQLiteCommand("SELECT * FROM UrunListesi WHERE ID = @IDSorgu", dbConnection);

            product = new Products[UrunAdedi + 1];

            for (int i = 0; i <= UrunAdedi; i++)
            {
                dbConnection.Open();
                urunMainKomut.Parameters.AddWithValue("@IDSorgu", i + 1);
                SQLiteDataReader drUrun = urunMainKomut.ExecuteReader();

                while (drUrun.Read())
                {
                    productName_ = drUrun["urunAdi"].ToString();
                    productPrice_ = Convert.ToDouble(drUrun["urunFiyati"].ToString());
                    productImage_ = drUrun["urunResmi"].ToString();
                    productCategory_ = drUrun["urunKategorisi"].ToString();
                    productAmount_ = Convert.ToInt32(drUrun["urunStok"].ToString());
                    productDetails_ = drUrun["urunAciklamasi"].ToString();
                    productID_ = Convert.ToInt32(drUrun["urunID"].ToString());
                }

                product[i] = new Products();
                product[i].SetInfo(productName_, productPrice_, productImage_, productCategory_, productAmount_, productDetails_, productID_);

                drUrun.Close();
                dbConnection.Close();
            }
        }

        void UrunleriListele(int pageNumber)
        {
            urunListeSayac = 0;
            //Ürünleri listeleme
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    GroupBox groupboxListele = new GroupBox();
                    int count = panelProducts.Controls.OfType<GroupBox>().ToList().Count;
                    groupboxListele.Location = new Point(10 + (k * 150), i * 210 + 10);
                    groupboxListele.Size = new Size(150, 230);
                    groupboxListele.Name = "groupBox_" + product[urunListeSayac + pageNumber * 9].productid;
                    groupboxListele.Padding = new Padding(10);
                    panelProducts.Controls.Add(groupboxListele);


                    PictureBox pictureBoxUrunResmi = new PictureBox();
                    pictureBoxUrunResmi.Size = new Size(100, 100);
                    pictureBoxUrunResmi.Name = product[urunListeSayac + pageNumber * 9].productid.ToString();
                    pictureBoxUrunResmi.Image = new Bitmap(product[urunListeSayac + pageNumber * 9].productimage);
                    pictureBoxUrunResmi.Dock = DockStyle.Top;
                    pictureBoxUrunResmi.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBoxUrunResmi.Click += new System.EventHandler(UrunResmi_Click);
                    pictureBoxUrunResmi.Cursor = Cursors.Hand;
                    //pb.Margin = new Padding(100);
                    groupboxListele.Controls.Add(pictureBoxUrunResmi);


                    //Sepete ekle butonu
                    Button satinalListele = new Button();
                    satinalListele.BackColor = Color.Orange;
                    satinalListele.Dock = DockStyle.Bottom;
                    satinalListele.Size = new Size(80, 40);
                    satinalListele.Name = product[urunListeSayac + pageNumber * 9].productname;
                    satinalListele.Tag = product[urunListeSayac + pageNumber * 9].productid.ToString();

                    if (product[urunListeSayac + pageNumber * 9].productamount == 0)
                    {
                        satinalListele.Enabled = false;
                        satinalListele.Text = "Stokta Yok";
                    }

                    else
                    {
                        satinalListele.Text = "Sepete Ekle";
                    }
                    satinalListele.Margin = new Padding(20);
                    satinalListele.Cursor = Cursors.Hand;

                    satinalListele.Click += new System.EventHandler(this.ButtonSatinAl_Click);
                    groupboxListele.Controls.Add(satinalListele);

                    Label labelUrunAdi = new Label();
                    string tmpName;
                    labelUrunAdi.Margin = new Padding(0, 11, 0, 0);
                    labelUrunAdi.Dock = DockStyle.Bottom;
                    labelUrunAdi.Size = new Size(50, 40);
                    labelUrunAdi.Name = "label_" + product[urunListeSayac + pageNumber * 9].productid;

                    if ((product[urunListeSayac + pageNumber * 9].productname).Length > 70)
                    {
                        tmpName = product[urunListeSayac + pageNumber * 9].productname.Remove(70);
                        labelUrunAdi.Text = tmpName + "...";
                    }

                    else
                    {
                        labelUrunAdi.Text = product[urunListeSayac + pageNumber * 9].productname;
                    }
                    labelUrunAdi.TextAlign = ContentAlignment.MiddleCenter;
                    groupboxListele.Controls.Add(labelUrunAdi);
                    urunListeSayac++;
                }
            }
        }

        //Sayfa değişimlerinde ürünleri siler
        void UrunleriSil(int pageNumber)
        {
            int urunSilSayac = 0;

            if (pageNumber > tmpPageNumber)
            {
                for (int i = 0; i < 9; i++)
                {

                    string urunAdi = "groupBox_" + product[urunSilSayac + (tmpPageNumber) * 9].productid;
                    var urunPictureBox = panelProducts.Controls.Find(urunAdi, true).FirstOrDefault();
                    panelProducts.Controls.Remove(urunPictureBox);
                    urunSilSayac++;
                }
                tmpPageNumber = pageNumber;
            }

            else if (pageNumber < tmpPageNumber)
            {
                for (int i = 0; i < 9; i++)
                {
                    string urunAdi = "groupBox_" + product[urunSilSayac + (pageNumber + 1) * 9].productid;
                    var urunPictureBox = panelProducts.Controls.Find(urunAdi, true).FirstOrDefault();
                    panelProducts.Controls.Remove(urunPictureBox);
                    urunSilSayac++;
                }
                tmpPageNumber = pageNumber;
            }
        }
        ShoppingCart shoppingCart = new ShoppingCart();

        private void MainPage_Load(object sender, EventArgs e)
        {
            dbConnection = new SQLiteConnection("Data Source=TrenyoluDB.sqlite;Version=3;");
            Members member = new Members();
            

            dbConnection.Open();
            SQLiteCommand komut = new SQLiteCommand("SELECT * FROM kullaniciBilgileri WHERE kullaniciMail = @mailSorgu", dbConnection);
            komut.Parameters.AddWithValue("@mailSorgu", Members.memberMail);
            SQLiteDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Members.memberName = dr["kullaniciAd"].ToString();
                Members.memberSurname = dr["kullaniciSoyAd"].ToString();
                Members.memberAdress = dr["kullaniciAdres"].ToString();
                Members.memberPhone = dr["kullaniciTelefon"].ToString();
                Members.memberID = Convert.ToInt32(dr["kullaniciID"]);
                Members.memberGender = Convert.ToInt32(dr["kullaniciCinsiyet"]);
                Members.memberBirthdate = dr["kullaniciDogumTarihi"].ToString();
            }
            dr.Close();
            dbConnection.Close();

            shoppingCart.memberIDshop = Members.memberID;
            ShoppingCart.sepetUrunSayisi = 0;


            //Sepetteki ürünleri kontrol etme
            k = 0;
            for (int i = 0; i <= 20; i++)
            {
                dbConnection.Open();
                SQLiteCommand sepetUrunKomut = new SQLiteCommand("SELECT urun_" + i + " FROM kullaniciSepeti WHERE kullaniciIDSepet = @kullaniciSepetID", dbConnection);
                sepetUrunKomut.Parameters.AddWithValue("@kullaniciSepetID", Members.memberID);
                SQLiteDataReader daSepetUrun = sepetUrunKomut.ExecuteReader();

                while (daSepetUrun.Read())
                {
                    if (daSepetUrun["urun_" + i] != DBNull.Value)
                    {
                        MainPage.urunSepetID[k] = Convert.ToInt32(daSepetUrun["urun_" + i]);
                        ShoppingCart.veritabaniUrunSirasi[k] = i;
                        k++;
                        ShoppingCart.sepetUrunSayisi++;
                    }

                    else
                        break;
                }
                daSepetUrun.Close();

                dbConnection.Close();
            }

            SQLiteCommand kayitBulKomut = new SQLiteCommand("SELECT COUNT(*) FROM UrunListesi", dbConnection);
            dbConnection.Open();
            object urunSayisi = kayitBulKomut.ExecuteScalar();
            dbConnection.Close();
            int urunSayisi_ = Convert.ToInt32(urunSayisi);

            UrunleriEslestir(pageNumber * 9, urunSayisi_);
            UrunleriListele(pageNumber);

            for (int i = 0; i < 6; i++)
            {
                int x = 150 + 30 * i;
                Label label_siteMap = new Label();
                //label_siteMap.Dock = DockStyle.Fill;
                label_siteMap.Size = new Size(15, 15);
                label_siteMap.Name = "label_siteMap" + (i + 1);
                label_siteMap.Tag = i;
                label_siteMap.Cursor = Cursors.Hand;
                label_siteMap.Text = (i + 1).ToString();
                label_siteMap.TextAlign = ContentAlignment.MiddleCenter;
                label_siteMap.Location = new Point(x, 5);
                label_siteMap.Click += new System.EventHandler(sayfaDegistir_Click);

                //label_siteMap.BackColor = Color.Red;
                panel_siteMap.Controls.Add(label_siteMap);
            }
        }

        int urunSepetIDmain;

        private void ButtonSatinAl_Click(object sender, EventArgs e)
        {
            dbConnection = new SQLiteConnection("Data Source=TrenyoluDB.sqlite;Version=3;");

            Button button = (sender as Button);
            //MessageBox.Show(button.Name + " sepete eklendi");
            urunSepetIDmain = Convert.ToInt32(button.Tag);

            button.Enabled = false;
            button.Text = "Sepete eklendi.";

            if (ShoppingCart.sepetUrunSayisi == 0)
            {
                dbConnection.Open();
                SQLiteCommand sepetUrunKomut2 = new SQLiteCommand("INSERT INTO kullaniciSepeti (urun_" + ShoppingCart.sepetUrunSayisi + ", kullaniciIDSepet) VALUES (@urunIDSepet, @kullaniciSepetID)", dbConnection);
                sepetUrunKomut2.Parameters.AddWithValue("@urunIDSepet", urunSepetIDmain);
                sepetUrunKomut2.Parameters.AddWithValue("@kullaniciSepetID", Members.memberID);
                sepetUrunKomut2.ExecuteNonQuery();
                dbConnection.Close();
                ShoppingCart.sepetUrunSayisi++;

            }

            else
            {
                for (int i = 0; i <= 20; i++)
                {
                    if (!ShoppingCart.veritabaniUrunSirasi.Contains(i))
                    {
                        dbConnection.Open();
                        SQLiteCommand sepetUrunKomut = new SQLiteCommand("UPDATE kullaniciSepeti SET urun_" + i + " = @urunIDSepet WHERE kullaniciIDSepet = @kullaniciSepetID", dbConnection);
                        sepetUrunKomut.Parameters.AddWithValue("@kullaniciSepetID", Members.memberID);
                        sepetUrunKomut.Parameters.AddWithValue("@urunIDSepet", urunSepetIDmain);
                        sepetUrunKomut.ExecuteNonQuery();
                        dbConnection.Close();
                        ShoppingCart.veritabaniUrunSirasi[k] = i;
                        k++;
                        ShoppingCart.sepetUrunSayisi++;
                        break;
                    }
                }

            }

        }
        private void UrunResmi_Click(object sender, EventArgs e)
        {
            PictureBox pictureBoxUrunClick = (sender as PictureBox);
            ProductPage productPage = new ProductPage();
            productPage.urunIDgelenBilgi = Convert.ToInt32(pictureBoxUrunClick.Name);
            productPage.Show();
            this.Hide();
        }

        private void sayfaDegistir_Click(object sender, EventArgs e)
        {
            Label label_siteMapClick = (sender as Label);

            pageNumber = Convert.ToInt32(label_siteMapClick.Tag);
            UrunleriSil(pageNumber);
            UrunleriListele(pageNumber);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UrunleriListele(pageNumber);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UrunleriSil(pageNumber);

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ProfilePage profilePage = new ProfilePage();
            profilePage.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            shoppingCart.Show();
            this.Hide();
        }

        private void pictureBox18_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPage searchPage = new SearchPage();
            searchPage.Show();
            this.Hide();
        }
    }
}
