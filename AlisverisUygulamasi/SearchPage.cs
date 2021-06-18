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
    public partial class SearchPage : Form
    {
        SQLiteConnection dbConnection = new SQLiteConnection("Data Source=TrenyoluDB.sqlite;Version=3;");

        UrunSorgusu[] sorguUrun = new UrunSorgusu[100];

        class UrunSorgusu
        {
            public string urunAdi;
            public string urunKategorisi;
            public string urunResmi;
            public int urunStok;
            public int urunID;
            public string urunFiyat;
        }
        public SearchPage()
        {
            InitializeComponent();
        }
        void SearchUrunleriListeleme(int i)
        {
            //Ürünleri listeleme

            GroupBox groupboxListele = new GroupBox();
            groupboxListele.Location = new Point(10, i * 120 + 20);
            groupboxListele.Size = new Size(420, 110);
            groupboxListele.Name = "groupBox_" + sorguUrun[i].urunID;
            groupboxListele.Padding = new Padding(10);
            panel_searchBox.Controls.Add(groupboxListele);

            PictureBox pictureBoxUrunResmi = new PictureBox();
            pictureBoxUrunResmi.Size = new Size(100, 100);
            pictureBoxUrunResmi.Name = sorguUrun[i].urunID.ToString();
            pictureBoxUrunResmi.Image = new Bitmap(sorguUrun[i].urunResmi);
            pictureBoxUrunResmi.Dock = DockStyle.Left;
            pictureBoxUrunResmi.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxUrunResmi.Click += new System.EventHandler(UrunResmi_Click);
            pictureBoxUrunResmi.Cursor = Cursors.Hand;
            groupboxListele.Controls.Add(pictureBoxUrunResmi);


            //Ürün Adını yazdırma
            Label labelUrunAdi = new Label();
            string tmpName;
            labelUrunAdi.Dock = DockStyle.Left;
            labelUrunAdi.Size = new Size(100, 25);
            labelUrunAdi.Name = "label_" + sorguUrun[i].urunID.ToString();
            labelUrunAdi.Font = new Font("Segoe UI", 9, FontStyle.Regular);

            if ((sorguUrun[i].urunAdi).Length > 70)
            {
                tmpName = (sorguUrun[i].urunAdi.Remove(70));
                labelUrunAdi.Text = tmpName + "...";
            }

            else
            {
                labelUrunAdi.Text = sorguUrun[i].urunAdi;
            }
            labelUrunAdi.TextAlign = ContentAlignment.MiddleCenter;
            groupboxListele.Controls.Add(labelUrunAdi);

            //Sepete ekle butonu
            Button satinalListele = new Button();
            satinalListele.BackColor = Color.Orange;
            satinalListele.Dock = DockStyle.Right;
            satinalListele.Size = new Size(100, 40);
            satinalListele.Name = sorguUrun[i].urunAdi;
            satinalListele.Tag = sorguUrun[i].urunID.ToString();

            if (sorguUrun[i].urunStok == 0)
            {
                satinalListele.Enabled = false;
                satinalListele.Text = "Stokta Yok";
            }
            else
            {
                satinalListele.Text = "Sepete Ekle";
            }
            satinalListele.Margin = new Padding(5);
            satinalListele.Cursor = Cursors.Hand;

            satinalListele.Click += new System.EventHandler(this.ButtonSatinAl_Click);
            groupboxListele.Controls.Add(satinalListele);

            //Ürün fiyatını yazdırma
            Label labelUrunFiyati = new Label();
            labelUrunFiyati.Dock = DockStyle.Right;
            labelUrunFiyati.Size = new Size(75, 25);
            labelUrunFiyati.Name = "label_" + sorguUrun[i].urunID.ToString();

            labelUrunFiyati.Text = sorguUrun[i].urunFiyat + "₺";
            labelUrunFiyati.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            labelUrunFiyati.TextAlign = ContentAlignment.MiddleCenter;
            groupboxListele.Controls.Add(labelUrunFiyati);

        }

        void UrunleriSil(int i)
        {
            string urunAdi = "groupBox_" + sorguUrun[i].urunID;
            var urunGroupBox = panel_searchBox.Controls.Find(urunAdi, true).FirstOrDefault();
            panel_searchBox.Controls.Remove(urunGroupBox);
        }

        int urunSepetIDsearch;
        private void ButtonSatinAl_Click(object sender, EventArgs e)
        {
            Button button = (sender as Button);
            button.Text = "Sepete Eklendi";
            button.Enabled = false;
            urunSepetIDsearch = Convert.ToInt32(button.Tag);

            if (ShoppingCart.sepetUrunSayisi == 0)
            {
                dbConnection.Open();
                SQLiteCommand sepetUrunKomut2 = new SQLiteCommand("INSERT INTO kullaniciSepeti (urun_" + ShoppingCart.sepetUrunSayisi + ", kullaniciIDSepet) VALUES (@urunIDSepet, @kullaniciSepetID)", dbConnection);
                sepetUrunKomut2.Parameters.AddWithValue("@urunIDSepet", urunSepetIDsearch);
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
                        sepetUrunKomut.Parameters.AddWithValue("@urunIDSepet", urunSepetIDsearch);
                        sepetUrunKomut.ExecuteNonQuery();
                        dbConnection.Close();
                        ShoppingCart.veritabaniUrunSirasi[MainPage.k] = i;
                        MainPage.k++;
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

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ProfilePage profilePage = new ProfilePage();
            profilePage.Show();
            this.Hide();
        }

        int m;

        private void button_Search_Click(object sender, EventArgs e)
        {
            string sqlSearch = @"SELECT * FROM UrunListesi WHERE urunAdi LIKE '%" + txtBox_search.Text + "%' ";

            if (m > 0)
            {
                for (int i = 0; i < m; i++)
                {
                    UrunleriSil(i);
                }

            }

            m = 0;

            dbConnection.Open();
            SQLiteCommand searchKomut = new SQLiteCommand(sqlSearch, dbConnection);
            SQLiteDataReader drSearch = searchKomut.ExecuteReader();


            while (drSearch.Read())
            {
                sorguUrun[m] = new UrunSorgusu();
                sorguUrun[m].urunAdi = drSearch["urunAdi"].ToString();
                sorguUrun[m].urunID = Convert.ToInt32(drSearch["urunID"]);
                sorguUrun[m].urunKategorisi = drSearch["urunKategorisi"].ToString();
                sorguUrun[m].urunResmi = drSearch["urunResmi"].ToString();
                sorguUrun[m].urunFiyat = drSearch["urunFiyati"].ToString();
                sorguUrun[m].urunStok = Convert.ToInt32(drSearch["urunStok"]);
                m++;
            }
            dbConnection.Close();

            for (int i = 0; i < m; i++)
            {
                SearchUrunleriListeleme(i);
            }
        }
    }
}
