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
    public partial class ProfilePage : Form
    {
        SQLiteConnection dbConnection = new SQLiteConnection("Data Source=TrenyoluDB.sqlite;Version=3;");
        SQLiteDataAdapter da;
        DataSet ds;
        public ProfilePage()
        {
            InitializeComponent();
        }

        //Çıkış yap butonu için login göstergeci

        private void ProfilePage_Load(object sender, EventArgs e)
        {
            //Siparişler datagridview doldurma
            da = new SQLiteDataAdapter("Select ID, siparisID, siparisTarih, siparisDetay, kargoyaVerildi, teslimEdildi From siparisler WHERE musteriID = " + Members.memberID + " ORDER BY ID DESC", dbConnection);
            ds = new DataSet();
            dbConnection.Open();
            da.Fill(ds, "siparisler");
            dataGridView1.DataSource = ds.Tables["siparisler"];
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Sipariş ID";
            dataGridView1.Columns[2].HeaderText = "Sipariş Tarih";
            dataGridView1.Columns[3].HeaderText = "Sipariş Notu";
            dataGridView1.Columns[4].HeaderText = "Kargo Durumu";
            dataGridView1.Columns[5].HeaderText = "Teslim edildi";

            //Profil bilgilerini belirleme
            if (Members.memberGender == 1)
            {
                label_musteriCinsiyet.Text = "Erkek";
            }

            else if (Members.memberGender == 2)
            {
                label_musteriCinsiyet.Text = "Kadın";
            }

            else
            {
                label_musteriCinsiyet.Text = "Belirtilmemiş";
            }

            txtBox_profilAd.Text = Members.memberName;
            txtBox_profilSoyad.Text = Members.memberSurname;
            txtBox_profilEmail.Text = Members.memberMail;
            txtBox_profilAdres.Text = Members.memberAdress;
            txtBox_profilDogumTarihi.Text = Members.memberBirthdate;
            label_musteriID.Text = Members.memberID.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.Show();
            this.Hide();

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button_profilBilgileriGuncelle_Click(object sender, EventArgs e)
        {
            SQLiteCommand profilGuncelleKomut = new SQLiteCommand("UPDATE kullaniciBilgileri SET kullaniciAd = @kullaniciAd, kullaniciSoyad = @kullaniciSoyad, " +
                "kullaniciAdres = @kullaniciAdres WHERE kullaniciID = @kullaniciID", dbConnection);

            profilGuncelleKomut.Parameters.AddWithValue("@kullaniciAd", txtBox_profilAd.Text);
            profilGuncelleKomut.Parameters.AddWithValue("@kullaniciSoyad", txtBox_profilSoyad.Text);
            profilGuncelleKomut.Parameters.AddWithValue("@kullaniciAdres", txtBox_profilAdres.Text);
            profilGuncelleKomut.Parameters.AddWithValue("@kullaniciID", Members.memberID);

            if (txtBox_profilSifre.Text != "")
            {
                profilGuncelleKomut.Parameters.AddWithValue("@kullaniciSifre", Register.MD5Sifrele(txtBox_profilSifre.Text));
            }
            profilGuncelleKomut.ExecuteNonQuery();
            Members.memberAdress = txtBox_profilAdres.Text;
            MessageBox.Show("Bilgileriniz başarıyla güncellenmiştir.");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult cikisYapDialog = new DialogResult();

            cikisYapDialog = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Çıkış Yap", MessageBoxButtons.YesNo);

            if (cikisYapDialog == DialogResult.Yes)
            {
                LoginAdmin loginAdmin = new LoginAdmin();
                loginAdmin.Show();
                this.Hide();
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchPage searchPage = new SearchPage();
            searchPage.Show();
            this.Hide();
        }
    }
}
