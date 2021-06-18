using System;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Data.SQLite;

namespace AlisverisUygulamasi
{

    public partial class Login : Form
    {
        public static string memberMailTxtBox;
        SQLiteConnection dbConnection = new SQLiteConnection("Data Source=TrenyoluDB.sqlite;Version=3;");

        public Login()
        {
            InitializeComponent();
        }

        public static string MD5Sifrele(string sifrelenecekMetin)
        {

            // MD5CryptoServiceProvider sınıfının bir örneğini oluşturduk.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            //Parametre olarak gelen veriyi byte dizisine dönüştürdük.
            byte[] dizi = Encoding.UTF8.GetBytes(sifrelenecekMetin);
            //dizinin hash'ini hesaplattık.
            dizi = md5.ComputeHash(dizi);
            //Hashlenmiş verileri depolamak için StringBuilder nesnesi oluşturduk.
            StringBuilder sb = new StringBuilder();
            //Her byte'i dizi içerisinden alarak string türüne dönüştürdük.

            foreach (byte ba in dizi)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }

            //hexadecimal(onaltılık) stringi geri döndürdük.
            return sb.ToString();
        }

    // Uyarı labellarını temizler
    public void clearIsEmptyAndtxtBoxes()
        {
            isMailEmpty.Text = "";
            isPasswordEmpty.Text = "";
            txtBox_userMail.Text = "";
            txtBox_userPassword.Text = "";

        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            //Değişken tanımlamaları
            Regex EmailCheck = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"); //E-Posta kontrolü için regular expression
            string encryptedPassword = MD5Sifrele(txtBox_userPassword.Text);
            MainPage mainPage = new MainPage();
            dbConnection.Open();
            SQLiteCommand checkUser = new SQLiteCommand("SELECT *FROM kullaniciBilgileri WHERE kullaniciMail = @mailSorgu AND kullaniciSifre = @sifreSorgu", dbConnection); //Mail ve Şifre kontrolü
            checkUser.Parameters.AddWithValue("@mailSorgu", txtBox_userMail.Text);
            checkUser.Parameters.AddWithValue("@sifreSorgu", encryptedPassword);
            SQLiteDataReader drCheckUser = checkUser.ExecuteReader(); //Sorgu çalıştır
            
            if (drCheckUser.Read())
            {
                MessageBox.Show("Giriş Başarılı");
                Members.memberMail = txtBox_userMail.Text;
                drCheckUser.Close();
                dbConnection.Close();
                mainPage.Show();
                this.Hide();

            }

            else
            {
                MessageBox.Show("Lütfen email ya da şifrenizi kontrol ediniz!");
                dbConnection.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register registerForm = new Register();
            registerForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoginAdmin loginAdmin = new LoginAdmin();
            loginAdmin.Show();
            this.Hide();
        }
    }
}
