using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SQLite;
namespace AlisverisUygulamasi
{
    public partial class ShoppingCart : Form
    {
        public static int sepetUrunSayisi;
        string productName_;
        string productImage_;
        double sepetTutari = 0;
        double productPrice_;
        public int memberIDshop;
        SQLiteConnection dbConnection;

        public ShoppingCart()
        {
            InitializeComponent();
        }

        public class Urunler
        {
            public string urunAd;
            public double urunFiyat;
            public string urunResim;
            public int urunID;
        }

        Urunler[] urunSepet;

        void SepeturunleriListeleme(int i, int sira)
        {
            //Ürünleri listeleme

            GroupBox groupboxListele = new GroupBox();
            groupboxListele.Location = new Point(10, i * 120 + 70);
            groupboxListele.Size = new Size(411, 110);
            groupboxListele.Name = "groupBox_" + MainPage.urunSepetID[i];
            groupboxListele.Padding = new Padding(10);
            panelSepetProducts.Controls.Add(groupboxListele);

            PictureBox pictureBoxUrunResmi = new PictureBox();
            pictureBoxUrunResmi.Size = new Size(100, 100);
            pictureBoxUrunResmi.Name = MainPage.urunSepetID[i].ToString();
            pictureBoxUrunResmi.Image = new Bitmap(urunSepet[i].urunResim);
            pictureBoxUrunResmi.Dock = DockStyle.Left;
            pictureBoxUrunResmi.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxUrunResmi.Click += new System.EventHandler(UrunResmi_Click);
            pictureBoxUrunResmi.Cursor = Cursors.Hand;
            //pb.Margin = new Padding(100);
            groupboxListele.Controls.Add(pictureBoxUrunResmi);


            //Ürün Adını yazdırma
            Label labelUrunAdi = new Label();
            string tmpName;
            //label.BackColor = Color.Red;
            labelUrunAdi.Margin = new Padding(0, 11, 0, 0);
            labelUrunAdi.Dock = DockStyle.Left;
            labelUrunAdi.Size = new Size(50, 25);
            labelUrunAdi.Name = "label_" + MainPage.urunSepetID[i].ToString();
            labelUrunAdi.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            if ((urunSepet[i].urunAd).Length > 70)
            {
                tmpName = (urunSepet[i].urunAd.Remove(70));
                labelUrunAdi.Text = tmpName + "...";
            }

            else
            {
                labelUrunAdi.Text = urunSepet[i].urunAd;
            }
            // label.AutoSize = true;
            labelUrunAdi.TextAlign = ContentAlignment.MiddleCenter;
            groupboxListele.Controls.Add(labelUrunAdi);


            //Ürün fiyatını yazdırma
            Label labelUrunFiyati = new Label();
            //label.BackColor = Color.Red;
            labelUrunFiyati.Margin = new Padding(0, 11, 0, 0);
            labelUrunFiyati.Dock = DockStyle.Right;
            labelUrunFiyati.Size = new Size(50, 25);
            labelUrunFiyati.Name = "label_" + MainPage.urunSepetID[i].ToString();

            labelUrunFiyati.Text = urunSepet[i].urunFiyat + "₺";
            labelUrunFiyati.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            // label.AutoSize = true;
            labelUrunFiyati.TextAlign = ContentAlignment.MiddleCenter;
            groupboxListele.Controls.Add(labelUrunFiyati);


            //Sepetten çıkar butonu
            Button sepettenCikar = new Button();
            // button.Location = new Point(150, 135 * count);
            sepettenCikar.BackColor = Color.Orange;
            sepettenCikar.Dock = DockStyle.Right;
            sepettenCikar.Size = new Size(120, 25);
            sepettenCikar.Name = MainPage.urunSepetID[i].ToString();
            sepettenCikar.AccessibleName = urunSepet[i].urunFiyat.ToString();
            sepettenCikar.Tag = "urun_" + sira;
            sepettenCikar.Text = "Sepetten Çıkar";
            sepettenCikar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            sepettenCikar.Margin = new Padding(20);
            sepettenCikar.Cursor = Cursors.Hand;
            sepettenCikar.Click += new System.EventHandler(this.SepettenCikar_Click);
            groupboxListele.Controls.Add(sepettenCikar);

        }

        int SiparisID;
        Random random = new Random();

        void IDCheck()
        {
            SiparisID = random.Next(100000, 1000000);

            bool duplicatedID = true;
            while (duplicatedID == true)
            {
                dbConnection.Open();
                SQLiteCommand isIdDuplicate = new SQLiteCommand("SELECT * FROM kullaniciSepeti WHERE siparisIDSepet = @IDSorgu", dbConnection);
                isIdDuplicate.Parameters.AddWithValue("@IDSorgu", SiparisID);
                SQLiteDataReader drID = isIdDuplicate.ExecuteReader();

                if (drID.Read())
                {
                    duplicatedID = true;
                    SiparisID = random.Next(100000, 1000000);
                }

                else
                {
                    duplicatedID = false;
                }
                dbConnection.Close();
            }
        }

        void UrunleriSil(int urunSepetID)
        {
            string urunAdi = "groupBox_" + urunSepetID;
            var urunPictureBox = panelSepetProducts.Controls.Find(urunAdi, true).FirstOrDefault();
            panelSepetProducts.Controls.Remove(urunPictureBox);

        }
        
        public int[] sepettekiUrunler = new int[21];
        public static int[] veritabaniUrunSirasi = new int[21];
        private void ShoppingCart_Load(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            dbConnection = new SQLiteConnection("Data Source=TrenyoluDB.sqlite;Version=3;");
            SQLiteCommand urunSepeti = new SQLiteCommand("SELECT * FROM UrunListesi WHERE urunID = @IDSorgu", dbConnection);

            urunSepet = new Urunler[21];
            int k = 0;
            sepetUrunSayisi = 0;
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
                        k++;
                        sepetUrunSayisi++;
                    }

                    else
                        break;
                }
                daSepetUrun.Close();

                dbConnection.Close();
            }

            for (int i = 0; i < sepetUrunSayisi; i++)
            {
                dbConnection.Open();

                urunSepeti.Parameters.AddWithValue("@IDSorgu", MainPage.urunSepetID[i]);
                SQLiteDataReader drUrun = urunSepeti.ExecuteReader();

                while (drUrun.Read())
                {
                    if (drUrun["urunID"] != DBNull.Value)
                    {
                        productName_ = drUrun["urunAdi"].ToString();
                        productPrice_ = Convert.ToDouble(drUrun["urunFiyati"].ToString());
                        productImage_ = drUrun["urunResmi"].ToString();
                        sepetTutari += productPrice_;
                    }

                    else
                        break;
                }
                drUrun.Close();
                dbConnection.Close();

                urunSepet[i] = new Urunler();
                urunSepet[i].urunAd = productName_;
                urunSepet[i].urunFiyat = productPrice_;
                urunSepet[i].urunResim = productImage_;
                urunSepet[i].urunID = MainPage.urunSepetID[i];
            }

            if (sepetUrunSayisi != 0)
            {
                button_SiparisiOnayla.Visible = true;
                label_sepetBos.Visible = false;
                pictureBox_sepetBuyuk.Visible = false;
                pictureBox_sepetKucuk.Visible = true;
                label_sepetTutari.Text = sepetTutari + "₺";

                for (int i = 0; i < sepetUrunSayisi; i++)
                {
                    SepeturunleriListeleme(i, veritabaniUrunSirasi[i]);
                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.Show();
            this.Hide();
        }

        string urunSepetSirasi;
        private void SepettenCikar_Click(object sender, EventArgs e)
        {
            Button sepettenCikar = (sender as Button);
            urunSepetSirasi = Convert.ToString(sepettenCikar.Tag);
            int urunSilSepetID = Convert.ToInt32(sepettenCikar.Name);
            sepetTutari -= Convert.ToDouble(sepettenCikar.AccessibleName);
            label_sepetTutari.Text = sepetTutari + "₺";
            dbConnection.Open();
            SQLiteCommand sepetUrunKomut = new SQLiteCommand("UPDATE kullaniciSepeti SET " + urunSepetSirasi + " = @urunIDSepet WHERE kullaniciIDSepet = @kullaniciSepetID", dbConnection);
            sepetUrunKomut.Parameters.AddWithValue("@kullaniciSepetID", Members.memberID);
            sepetUrunKomut.Parameters.AddWithValue("@urunIDSepet", null);
            sepetUrunKomut.ExecuteNonQuery();
            dbConnection.Close();
            sepetUrunSayisi--;
            UrunleriSil(urunSilSepetID);

            if (sepetUrunSayisi == 0)
            {
                label_sepetTutari.Text = "0₺";
                button_SiparisiOnayla.Visible = false;
                label_sepetBos.Visible = true;
                pictureBox_sepetBuyuk.Visible = true;
                pictureBox_sepetKucuk.Visible = false;
                button_SiparisiOnayla.Cursor = Cursors.Default;
                dbConnection.Open();
                SQLiteCommand kullaniciSepetiniSil = new SQLiteCommand("DELETE FROM kullaniciSepeti WHERE kullaniciIDSepet = @kullaniciSepetID", dbConnection);
                kullaniciSepetiniSil.Parameters.AddWithValue("@kullaniciSepetID", Members.memberID);
                kullaniciSepetiniSil.ExecuteNonQuery();
                dbConnection.Close();
            }
        }

        //Sepet ürün resmine basınca detay gösterme
        private void UrunResmi_Click(object sender, EventArgs e)
        {
            PictureBox pictureBoxUrunClick = (sender as PictureBox);
            ProductPage productPage = new ProductPage();
            productPage.urunIDgelenBilgi = Convert.ToInt32(pictureBoxUrunClick.Name);
            productPage.Show();
            this.Hide();
        }

        private void button_SiparisiOnayla_Click(object sender, EventArgs e)
        {
            if (Members.memberAdress == "")
            {
                MessageBox.Show("Lütfen adres bilgilerinizi profilim sayfasından güncelleyeniz!");
            }

            else
            {
                IDCheck();
                dbConnection.Open();
                SQLiteCommand siparisOnayiKomut = new SQLiteCommand("INSERT INTO siparisler (siparisID, musteriID, siparisTarih, siparisAdres, siparisTutari, siparisKullaniciAd) " +
                    "values (@SiparisIDSepet, @kullaniciIDSepet, @SiparisTarih, @siparisAdres, @SiparisTutari, @KullaniciAd)", dbConnection);
                siparisOnayiKomut.Parameters.AddWithValue("@SiparisIDSepet", SiparisID);
                siparisOnayiKomut.Parameters.AddWithValue("@kullaniciIDSepet", Members.memberID);
                siparisOnayiKomut.Parameters.AddWithValue("@SiparisTarih", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                siparisOnayiKomut.Parameters.AddWithValue("@siparisAdres", Members.memberAdress);
                siparisOnayiKomut.Parameters.AddWithValue("@SiparisTutari", sepetTutari);
                siparisOnayiKomut.Parameters.AddWithValue("@KullaniciAd", Members.memberName + " " + Members.memberSurname);
                siparisOnayiKomut.ExecuteNonQuery();
                dbConnection.Close();


                for (int i = 0; i < sepetUrunSayisi; i++)
                {
                    SQLiteCommand urunleriEkle = new SQLiteCommand("UPDATE siparisler SET urun_" + i + " = @urunIDSiparis WHERE siparisID = @SiparisIDSepet", dbConnection);

                    dbConnection.Open();

                    urunleriEkle.Parameters.AddWithValue("@urunIDSiparis", MainPage.urunSepetID[i]);
                    urunleriEkle.Parameters.AddWithValue("@SiparisIDSepet", SiparisID);
                    urunleriEkle.ExecuteNonQuery();
                    dbConnection.Close();

                    UrunleriSil(MainPage.urunSepetID[i]);
                    button_SiparisiOnayla.Enabled = false;
                    label_sepetTutari.Text = "0₺";
                    label_sepetBos.Visible = true;
                    pictureBox_sepetBuyuk.Visible = true;
                    pictureBox_sepetKucuk.Visible = false;

                }

                dbConnection.Open();
                SQLiteCommand kullaniciSepetiniSil = new SQLiteCommand("DELETE FROM kullaniciSepeti WHERE kullaniciIDSepet = @kullaniciSepetID", dbConnection);
                kullaniciSepetiniSil.Parameters.AddWithValue("@kullaniciSepetID", Members.memberID);
                kullaniciSepetiniSil.ExecuteNonQuery();
                dbConnection.Close();

                for (int i = 0; i < sepetUrunSayisi; i++)
                {
                    dbConnection.Open();
                    SQLiteCommand stokBelirle = new SQLiteCommand("UPDATE UrunListesi SET urunStok = (urunStok - 1) WHERE urunID = @urunIDSepet", dbConnection);
                    stokBelirle.Parameters.AddWithValue("@urunIDSepet", MainPage.urunSepetID[i]);
                    stokBelirle.ExecuteNonQuery();
                    dbConnection.Close();
                }

                MessageBox.Show("Siparişiniz onaylanmıştır!\nProfilim sekmesinden kontrol edebilirsiniz");
                ProfilePage profilePage = new ProfilePage();
                profilePage.Show();
                this.Hide();
            }

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ProfilePage profilePage = new ProfilePage();
            profilePage.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPage searchPage = new SearchPage();
            searchPage.Show();
            this.Hide();
        }
    }
}
