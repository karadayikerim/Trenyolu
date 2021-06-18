using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace AlisverisUygulamasi
{
    public partial class AdminPage : Form
    {
        SQLiteConnection dbConnection = new SQLiteConnection("Data Source=TrenyoluDB.sqlite;Version=3;");
        SQLiteDataAdapter da;
        DataSet ds;
        public AdminPage()
        {
            InitializeComponent();
        }

        public bool backFromEditProduct, backFromProductsPanel, backFromMembersPanel, backFromOrdersPanel;

        void uyeListele()
        {
            da = new SQLiteDataAdapter("Select *From kullaniciBilgileri", dbConnection);
            ds = new DataSet();
            dbConnection.Open();
            da.Fill(ds, "kullaniciBilgileri");

            datagridview_uyeleriListele.DataSource = ds.Tables["kullaniciBilgileri"];

            datagridview_uyeleriListele.Columns[1].HeaderText = "Müşteri Mail";
            datagridview_uyeleriListele.Columns[2].HeaderText = "Şifre";
            datagridview_uyeleriListele.Columns[3].HeaderText = "Müşteri Cinsiyet";
            datagridview_uyeleriListele.Columns[4].HeaderText = "Müşteri Telefon";
            datagridview_uyeleriListele.Columns[5].HeaderText = "Müşteri Dogum Tarihi";
            datagridview_uyeleriListele.Columns[6].HeaderText = "Müşteri Adı";
            datagridview_uyeleriListele.Columns[7].HeaderText = "Müşteri Soyadı";
            datagridview_uyeleriListele.Columns[8].HeaderText = "Müşteri Adresi";
            datagridview_uyeleriListele.Columns[9].HeaderText = "Müşteri ID";

            dbConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.Show();
            this.Hide();
        }

        private void button_SiparisleriListele_Click(object sender, EventArgs e)
        {
            da = new SQLiteDataAdapter("SELECT ID, siparisID, siparisTarih, siparisDetay, kargoyaVerildi, teslimEdildi, siparisTutari, siparisAdres FROM siparisler ORDER BY ID DESC", dbConnection);
            ds = new DataSet();
            dbConnection.Open();
            da.Fill(ds, "siparisler");
            siparisDataGridView.DataSource = ds.Tables["siparisler"];
            siparisDataGridView.Visible = true;
            dataGridView1.Visible = false;
            datagridview_uyeleriListele.Visible = false;

            siparisDataGridView.Columns[0].Visible = false;
            siparisDataGridView.Columns[1].HeaderText = "Sipariş ID";
            siparisDataGridView.Columns[2].HeaderText = "Sipariş Tarih";
            siparisDataGridView.Columns[3].HeaderText = "Sipariş Notu";
            siparisDataGridView.Columns[4].HeaderText = "Kargo Durumu";
            siparisDataGridView.Columns[5].HeaderText = "Teslim edildi";
            siparisDataGridView.Columns[6].HeaderText = "Sipariş Tutarı";
            siparisDataGridView.Columns[7].HeaderText = "Sipariş Adres";
            dbConnection.Close();
        }

        void urunListele()
        {
            da = new SQLiteDataAdapter("Select *From UrunListesi", dbConnection);
            ds = new DataSet();
            dbConnection.Open();
            da.Fill(ds, "UrunListesi");
            dataGridView1.DataSource = ds.Tables["UrunListesi"];
            dataGridView1.Columns[1].HeaderText = "Ürün";
            dataGridView1.Columns[2].HeaderText = "Ürün Fiyatı";
            dataGridView1.Columns[3].HeaderText = "Ürün Açıklaması";
            dataGridView1.Columns[4].HeaderText = "Ürün Kategorisi";
            dataGridView1.Columns[5].HeaderText = "Ürün Resmi(Üzerine tıklayarak görüntüleyebilirsiniz)";
            dataGridView1.Columns[6].HeaderText = "Ürün Stok Durumu";
            dataGridView1.Columns[7].HeaderText = "Ürün Numarası";

            dbConnection.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdminPage_Load(object sender, EventArgs e)
        {
            string sqlToplamCiro = @"SELECT SUM(siparisTutari) FROM siparisler WHERE siparisTutari";
            string sqlToplamUrunSayisi = @"SELECT COUNT(*) FROM UrunListesi";
            string sqlToplamUyeSayisi = @"SELECT COUNT(*) FROM kullaniciBilgileri";
            string sqlToplamSiparisSayisi = @"SELECT COUNT(*) FROM siparisler";
            string sqlSonSiparis = @"SELECT * FROM siparisler ORDER BY ID DESC LIMIT 1";


            SQLiteCommand siparisTutariToplam = new SQLiteCommand(sqlToplamCiro, dbConnection);
            SQLiteCommand ToplamUrunSayisi = new SQLiteCommand(sqlToplamUrunSayisi, dbConnection);
            SQLiteCommand ToplamUyeSayisi = new SQLiteCommand(sqlToplamUyeSayisi, dbConnection);
            SQLiteCommand ToplamSiparisSayisi = new SQLiteCommand(sqlToplamSiparisSayisi, dbConnection);
            SQLiteCommand sonSipariskomut = new SQLiteCommand(sqlSonSiparis, dbConnection);


            dbConnection.Open();
            double siparislerToplami = Convert.ToDouble(siparisTutariToplam.ExecuteScalar());
            int uyeSayisi = Convert.ToInt32(ToplamUyeSayisi.ExecuteScalar());
            int urunSayisi = Convert.ToInt32(ToplamUrunSayisi.ExecuteScalar());
            int siparisSayisi = Convert.ToInt32(ToplamSiparisSayisi.ExecuteScalar());

            SQLiteDataReader drSonSiparis = sonSipariskomut.ExecuteReader();

            while (drSonSiparis.Read())
            {
                label_sonSiparisAd.Text = drSonSiparis["siparisKullaniciAd"].ToString();
                textBox_sonSiparisAdres.Text = drSonSiparis["siparisAdres"].ToString();
            }

            dbConnection.Close();

            label_toplamCiro.Text = siparislerToplami + "₺";
            label_siparisSayisi.Text = siparisSayisi.ToString();
            label_urunSayisi.Text = urunSayisi.ToString();
            label_uyeSayisi.Text = uyeSayisi.ToString();
        }

        private void button_UyeListele_Click(object sender, EventArgs e)
        {
            uyeListele();
            siparisDataGridView.Visible = false;
            dataGridView1.Visible = false;
            datagridview_uyeleriListele.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LoginAdmin loginAdmin = new LoginAdmin();
            loginAdmin.Show();
            this.Hide();
        }

        private void button_UrunleriListele_Click(object sender, EventArgs e)
        {
            urunListele();
            datagridview_uyeleriListele.Visible = false;
            siparisDataGridView.Visible = false;
            dataGridView1.Visible = true;
        }
        private void siparisDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int deger = Convert.ToInt32(siparisDataGridView.CurrentRow.Cells["siparisID"].Value);
            AdminSiparisDetay adminSiparisDetay = new AdminSiparisDetay();
            adminSiparisDetay.siparisID = deger;

            adminSiparisDetay.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int deger = Convert.ToInt32(dataGridView1.CurrentRow.Cells["urunID"].Value);
            EditProduct editProduct = new EditProduct();
            editProduct.urunID = deger;

            editProduct.Show();
            this.Hide();

        }
    }
}
