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
    public partial class AdminSiparisDetay : Form
    {
        SQLiteConnection dbConnection;

        public int siparisID;
        int[] siparisListesi;
        int k;
        AdminPage adminPage = new AdminPage();

        public AdminSiparisDetay()
        {
            InitializeComponent();
        }

        private void AdminSiparisDetay_Load(object sender, EventArgs e)
        {
            siparisListesi = new int[21];
            dbConnection = new SQLiteConnection("Data Source=TrenyoluDB.sqlite;Version=3;");
            label_siparisID.Text = siparisID.ToString();
            k = 0;
            for (int i = 0; i <= 20; i++)
            {
                dbConnection.Open();
                SQLiteCommand siparisSorguKomut = new SQLiteCommand("SELECT urun_" + i + " FROM siparisler WHERE siparisID = @siparisID", dbConnection);
                siparisSorguKomut.Parameters.AddWithValue("@siparisID", siparisID);
                SQLiteDataReader drSiparisSorgu = siparisSorguKomut.ExecuteReader();

                while (drSiparisSorgu.Read())
                {
                    if (drSiparisSorgu["urun_" + i] != DBNull.Value)
                    {
                        siparisListesi[k] = Convert.ToInt32(drSiparisSorgu["urun_" + i]);
                        k++;
                    }

                    else
                        break;
                }
                drSiparisSorgu.Close();
                dbConnection.Close();
            }

            for (int a = 0; a <= k; a++)
            {
                dbConnection.Open();
                SQLiteCommand urunSorguKomut = new SQLiteCommand("SELECT urunAdi FROM UrunListesi WHERE urunID = @urunID", dbConnection);
                urunSorguKomut.Parameters.AddWithValue("@urunID", siparisListesi[a]);
                SQLiteDataReader drUrunSorgu = urunSorguKomut.ExecuteReader();

                while (drUrunSorgu.Read())
                {
                    listBox_urunler.Items.Add(drUrunSorgu["urunAdi"]);                    
                }
                drUrunSorgu.Close();
                dbConnection.Close();

            }

            dbConnection.Open();
            SQLiteCommand siparisSorguDetayKomut = new SQLiteCommand("SELECT siparisDetay, kargoyaVerildi, teslimEdildi FROM siparisler WHERE siparisID = @siparisID", dbConnection);
            siparisSorguDetayKomut.Parameters.AddWithValue("@siparisID", siparisID);
            SQLiteDataReader drSiparisDetaySorgu = siparisSorguDetayKomut.ExecuteReader();

            while (drSiparisDetaySorgu.Read())
            {
                txtBox_kargotakipNo.Text = drSiparisDetaySorgu["kargoyaVerildi"].ToString();
                txtBox_siparisNotu.Text = drSiparisDetaySorgu["siparisDetay"].ToString();
                comboBox_siparisDurumu.Text = drSiparisDetaySorgu["teslimEdildi"].ToString();
            }
            drSiparisDetaySorgu.Close();
            dbConnection.Close();
        }

        private void button_Guncelle_Click(object sender, EventArgs e)
        {
            dbConnection.Open();
            SQLiteCommand siparisGuncelle = new SQLiteCommand("UPDATE siparisler SET kargoyaVerildi = @kargoDurumu, siparisDetay = @siparisDetay, teslimEdildi = @teslimDurumu WHERE siparisID = @siparisID", dbConnection);
            siparisGuncelle.Parameters.AddWithValue("@siparisDetay", txtBox_siparisNotu.Text);
            siparisGuncelle.Parameters.AddWithValue("@kargoDurumu", txtBox_kargotakipNo.Text);
            siparisGuncelle.Parameters.AddWithValue("@teslimDurumu", comboBox_siparisDurumu.Text);
            siparisGuncelle.Parameters.AddWithValue("@siparisID", siparisID);
            siparisGuncelle.ExecuteNonQuery();
            dbConnection.Close();

            MessageBox.Show("Sipariş güncelleme işlemi başarıyla tamamlandı! \n" +
                "Önceki sayfasına yönlendiriliyorsunuz...");
            adminPage.Show();
            this.Hide();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            adminPage.Show();
            this.Hide();
        }
    }
}
