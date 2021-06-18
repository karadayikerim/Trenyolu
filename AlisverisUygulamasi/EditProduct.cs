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
    public partial class EditProduct : Form
    {
        SQLiteConnection dbConnection = new SQLiteConnection("Data Source=TrenyoluDB.sqlite;Version=3;Integrated Security=True;MultipleActiveResultSets=true;");
        public int urunID;
        string urunAdi;
        string urunAciklamasi;
        string urunResmi;
        string urunResmiButton;
        string urunKategori;
        int urunStok;
        double urunFiyat;
        AdminPage adminPage = new AdminPage();

        public EditProduct()
        {
            InitializeComponent();
        }

        private void EditProduct_Load(object sender, EventArgs e)
        {
            SQLiteCommand komut = new SQLiteCommand("SELECT * FROM UrunListesi WHERE urunID = @urunIDSorgu", dbConnection);

            dbConnection.Open();
            komut.Parameters.AddWithValue("@urunIDSorgu", urunID);
            SQLiteDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                urunAdi = dr["urunAdi"].ToString();
                urunAciklamasi = dr["urunAciklamasi"].ToString();
                urunResmi = dr["urunResmi"].ToString();
                urunFiyat = Convert.ToDouble(dr["urunFiyati"].ToString());
                urunStok = Convert.ToInt32(dr["urunStok"].ToString());
                urunKategori = dr["urunKategorisi"].ToString();

                picBox_productImageEdit.Image = new Bitmap(dr["urunResmi"].ToString());
            }

            dbConnection.Close();

            txtBox_urunAdiEdit.Text = urunAdi;
            txtBox_urunFiyatEdit.Text = urunFiyat.ToString();
            txtBox_urunAciklamasi.Text = urunAciklamasi;
            txtBox_urunID.Text = urunID.ToString();
            txtBox_urunStokEdit.Text = urunStok.ToString();
            comboBox_urunKategoriEdit.Text = urunKategori;
            picBox_productImageEdit.Image = new Bitmap(urunResmi);


        }
        string fileExt;
        string destinationFile;
        private void button_editImage_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                fileExt = System.IO.Path.GetExtension(open.FileName);
                System.IO.Directory.CreateDirectory("images");
                destinationFile = "images\\" + urunID + fileExt;

                File.Copy(open.FileName, destinationFile);

                // display image in picture box  
                picBox_productImageEdit.Image = new Bitmap(destinationFile);
                // image file path  
                urunResmi = destinationFile;
            }
        }

        //, urunResmi = @urunResmiSorgu, urunFiyati = @urunFiyatiSorgu" +
        //  "urunKategorisi = @urunKategorisiSorgu, urunStok = @urunStokSorgu urunAdi = @urunAdiSorgu, urunAdi = @urunAdiSorgu, 


        private void button_saveProductEdit_Click(object sender, EventArgs e)
        {
            if (urunResmiButton == null)
            {
                urunResmiButton = urunResmi;
            }

            dbConnection.Open();
            SQLiteCommand editCommand = new SQLiteCommand("UPDATE UrunListesi SET urunAdi = @urunAdiSorgu, urunResmi = @urunResmiSorgu, urunFiyati = @urunFiyatiSorgu," +
                "urunFiyati = @urunFiyatiSorgu, urunStok = @urunStokSorgu, urunKategorisi = @urunKategorisiSorgu, urunAciklamasi = @urunAciklamaSorgu" +
                " WHERE urunID = @urunIDSorgu", dbConnection);
            editCommand.Parameters.AddWithValue("@urunAdiSorgu", txtBox_urunAdiEdit.Text);
            editCommand.Parameters.AddWithValue("@urunAciklamaSorgu", txtBox_urunAciklamasi.Text);
            editCommand.Parameters.AddWithValue("@urunResmiSorgu", urunResmiButton);
            editCommand.Parameters.AddWithValue("@urunFiyatiSorgu", Convert.ToDouble(txtBox_urunFiyatEdit.Text));
            editCommand.Parameters.AddWithValue("@urunKategorisiSorgu", comboBox_urunKategoriEdit.Text);
            editCommand.Parameters.AddWithValue("@urunStokSorgu", Convert.ToInt32(txtBox_urunStokEdit.Text));
            editCommand.Parameters.AddWithValue("@urunIDSorgu", urunID);

            editCommand.ExecuteNonQuery();
            dbConnection.Close();

            MessageBox.Show("Ürün bilgileri başarıyla güncellendi...");
        }

        private void button_getBack_Click(object sender, EventArgs e)
        {
            adminPage.backFromEditProduct = true;
            adminPage.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult urunSilDialog = new DialogResult();
            urunSilDialog = MessageBox.Show("Ürünü silmek istediğinize emin misiniz?", urunAdi, MessageBoxButtons.YesNo);

            if (urunSilDialog == DialogResult.Yes)
            {
                dbConnection.Open();
                SQLiteCommand kullaniciSepetiniSil = new SQLiteCommand("DELETE FROM UrunListesi WHERE urunID = @urunID", dbConnection);
                kullaniciSepetiniSil.Parameters.AddWithValue("@urunID", urunID);
                kullaniciSepetiniSil.ExecuteNonQuery();
                dbConnection.Close();

                adminPage.Show();
                this.Hide();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
