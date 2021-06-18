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
using System.IO;

namespace AlisverisUygulamasi
{
    public partial class LoginAdmin : Form
    {
        SQLiteConnection dbConnection;
        SQLiteCommand komutKullaniciBilgileri;
        SQLiteCommand komutSiparisler;
        SQLiteCommand komutKullaniciSepeti;
        SQLiteCommand komutUrunBilgileri;

        public LoginAdmin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            adminPage.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void LoginAdmin_Load(object sender, EventArgs e)
        {

            if (!File.Exists("TrenyoluDB.sqlite"))
            {
                SQLiteConnection.CreateFile("TrenyoluDB.sqlite");

                string sqlKullaniciBilgileri = @"CREATE TABLE kullaniciBilgileri(
                               ID INTEGER PRIMARY KEY AUTOINCREMENT ,
                               kullaniciMail	   TEXT      NOT NULL,
                               kullaniciSifre      TEXT      NOT NULL,
                               kullaniciCinsiyet   INT       NOT NULL,
                               kullaniciTelefon    TEXT      NOT NULL,
                               kullaniciDogumTarihi TEXT      NOT NULL,
                               kullaniciAd         TEXT      NOT NULL,
                               kullaniciSoyad      TEXT      NOT NULL,
                               kullaniciAdres      TEXT      NULL,
                               kullaniciID         INT       NOT NULL
                            );";

                string sqlUrunListesi = @"CREATE TABLE UrunListesi(
                               ID INTEGER PRIMARY KEY AUTOINCREMENT ,
                               urunAdi      	   TEXT      NOT NULL,
                               urunFiyati          REAL      NOT NULL,
                               urunAciklamasi      TEXT      NOT NULL,
                               urunKategorisi      TEXT      NOT NULL,
                               urunResmi           TEXT      NOT NULL,
                               urunStok            INT       NOT NULL,
                               urunID              INT       NOT NULL
                            );";

                string sqlSiparisler = @"CREATE TABLE siparisler(

                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
	                            urun_0   INTEGER,
                                urun_1    INTEGER,
	                            urun_2    INTEGER,
	                            urun_3    INTEGER,
	                            urun_4    INTEGER,
	                            urun_5    INTEGER,
	                            urun_6    INTEGER,
	                            urun_7    INTEGER,
	                            urun_8    INTEGER,
	                            urun_9    INTEGER,
	                            urun_10   INTEGER,
	                            urun_11   INTEGER,
	                            urun_12   INTEGER,
	                            urun_13   INTEGER,
	                            urun_14   INTEGER,
	                            urun_15   INTEGER,
	                            urun_16   INTEGER,
	                            urun_17   INTEGER,
	                            urun_18   INTEGER,
	                            urun_19   INTEGER,
	                            urun_20   INTEGER,
	                            musteriID INTEGER,
	                            siparisID INTEGER,
	                            siparisTutari REAL,
	                            siparisTarih  TEXT,
	                            siparisAdres  TEXT,
	                            siparisDetay  TEXT,
	                            kargoyaVerildi    TEXT,
	                            teslimEdildi  TEXT,
	                            siparisKullaniciAd  TEXT
                            );";

                string sqlkullaniciSepeti = @"CREATE TABLE kullaniciSepeti(

                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
	                            urun_0    INTEGER,
	                            urun_1    INTEGER,
	                            urun_2    INTEGER,
	                            urun_3    INTEGER,
	                            urun_4    INTEGER,
	                            urun_5    INTEGER,
	                            urun_6    INTEGER,
	                            urun_7    INTEGER,
	                            urun_8    INTEGER,
	                            urun_9    INTEGER,
	                            urun_10   INTEGER,
	                            urun_11   INTEGER,
	                            urun_12   INTEGER,
	                            urun_13   INTEGER,
	                            urun_14   INTEGER,
	                            urun_15   INTEGER,
	                            urun_16   INTEGER,
	                            urun_17   INTEGER,
	                            urun_18   INTEGER,
	                            urun_19   INTEGER,
	                            urun_20   INTEGER,
	                            siparisIDSepet    INTEGER,
	                            kullaniciIDSepet  INTEGER
                            );";

                dbConnection = new SQLiteConnection("Data Source=TrenyoluDB.sqlite;Version=3;");

                dbConnection.Open();

                komutSiparisler = new SQLiteCommand(sqlSiparisler, dbConnection);
                komutKullaniciSepeti = new SQLiteCommand(sqlkullaniciSepeti, dbConnection);
                komutKullaniciBilgileri = new SQLiteCommand(sqlKullaniciBilgileri, dbConnection);
                komutUrunBilgileri = new SQLiteCommand(sqlUrunListesi, dbConnection);


                komutSiparisler.ExecuteNonQuery();
                komutKullaniciSepeti.ExecuteNonQuery();
                komutKullaniciBilgileri.ExecuteNonQuery();
                komutUrunBilgileri.ExecuteNonQuery();

                
                dbConnection.Close();
            }

            System.IO.Directory.CreateDirectory("images");

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
