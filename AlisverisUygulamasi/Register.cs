using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Data.SQLite;
using System.IO;

namespace AlisverisUygulamasi
{
    public partial class Register : Form
    {
        SQLiteConnection dbConnection;
        SQLiteCommand cmd;
        public Register()
        {
            InitializeComponent();
        }
        Login loginPage = new Login();

        private void Register_Load(object sender, EventArgs e)
        {
            dtp_userBirthdate.MaxDate = DateTime.Today;
            dtp_userBirthdate.Value = DateTime.Today;

            if (!File.Exists("TrenyoluDB.sqlite"))
            {
                SQLiteConnection.CreateFile("TrenyoluDB.sqlite");

                string sql = @"CREATE TABLE kullaniciBilgileri(
                               ID INTEGER PRIMARY KEY AUTOINCREMENT ,
                               kullaniciMail	   TEXT      NOT NULL,
                               kullaniciSifre      TEXT      NOT NULL,
                               kullaniciCinsiyet   INT       NOT NULL,
                               kullaniciTelefon    TEXT      NOT NULL,
                               kullaniciAd         TEXT      NOT NULL,
                               kullaniciSoyad      TEXT      NOT NULL,
                               kullaniciAdres      TEXT      NULL,
                               kullaniciID         INT       NOT NULL
                            );";
                dbConnection = new SQLiteConnection("Data Source=TrenyoluDB.sqlite;Version=3;");
                dbConnection.Open();
                cmd = new SQLiteCommand(sql, dbConnection);
                cmd.ExecuteNonQuery();
                dbConnection.Close();
            }

            else
            {
                dbConnection = new SQLiteConnection("Data Source=TrenyoluDB.sqlite;Version=3;");
            }
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
            isNameEmpty.Text = "";
            isSurnameEmpty.Text = "";
            isMailEmpty.Text = "";
            isPasswordEmpty.Text = "";
            isGenderEmpty.Text = "";
            isBirthdateEmpty.Text = "";
            isPhoneEmpty.Text = "";
            txtBox_userName.Text = "";
            txtBox_userSurname.Text = "";
            txtBox_userMail.Text = "";
            txtBox_userPassword.Text = "";
            txtBox_userPhone.Text = "";
            radioButton_isMale.Checked = false;
            radioButton_isFemale.Checked = false;
            radioButton_isNotGiven.Checked = false;
            dtp_userBirthdate.Value = DateTime.Today;
        }
        bool isMailDuplicated;
        bool isPhoneDuplicated;
        Random random = new Random();
        int RandomID;

        void IDCheck()
        {

            RandomID = random.Next(100000, 1000000);

            bool duplicatedID = true;
            while (duplicatedID == true)
            {
                dbConnection.Open();
                SQLiteCommand isIdDuplicate = new SQLiteCommand("SELECT * FROM kullaniciBilgileri WHERE kullaniciID = @IDSorgu", dbConnection);
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
        void mailCheck()
        {
            dbConnection.Open();
            SQLiteCommand isIdDuplicate = new SQLiteCommand("SELECT * FROM kullaniciBilgileri WHERE kullaniciMail = @mailSorgu", dbConnection);
            isIdDuplicate.Parameters.AddWithValue("@mailSorgu", txtBox_userMail.Text);
            SQLiteDataReader drMail = isIdDuplicate.ExecuteReader();

            if (drMail.Read())
            {
                isMailEmpty.Text = "Bu mail adresi önceden alınmış!";
                isMailDuplicated = true;

            }

            else
            {
                isMailDuplicated = false;
            }
            dbConnection.Close();
        }

        void phoneCheck()
        {
            dbConnection.Open();
            SQLiteCommand isIdDuplicate = new SQLiteCommand("SELECT * FROM kullaniciBilgileri WHERE kullaniciTelefon = @phoneSorgu", dbConnection);
            isIdDuplicate.Parameters.AddWithValue("@phoneSorgu", txtBox_userPhone.Text);
            SQLiteDataReader drPhone = isIdDuplicate.ExecuteReader();

            if (drPhone.Read())
            {
                isPhoneDuplicated = true;
            }

            else
            {
                isPhoneDuplicated = false;
            }

            dbConnection.Close();
        }

        private void button_signUp_Click(object sender, EventArgs e)
        {

            //Değişken tanımlamaları
            Regex EmailCheck = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"); //E-Posta kontrolü için regular expression
            Regex NameCheck = new Regex(@"^[a-zA-ZıöçğüşİÖÇĞÜŞ\s]+$"); //İsimde özel karakter kullanılmaması için regular expression
            int GenderType = 0; //Cinsiyet Seçimi

            //Yaş Doğrulaması
            TimeSpan userAgeTSpan = DateTime.Now - dtp_userBirthdate.Value;
            int userAge = (int)userAgeTSpan.TotalDays / 365;

            for (int k = 0; k < 2; k++)
            {
                mailCheck();
                phoneCheck();
                if (txtBox_userName.Text == "" || txtBox_userSurname.Text == "" || txtBox_userMail.Text == "" || txtBox_userPassword.Text == ""
                    || txtBox_userPhone.Text == "" || userAge < 18 || !EmailCheck.IsMatch(txtBox_userMail.Text) || !txtBox_userPhone.MaskFull
                    || !txtBox_userPhone.MaskFull || !NameCheck.IsMatch(txtBox_userName.Text) || !NameCheck.IsMatch(txtBox_userName.Text) || GenderType == 0
                    || isPhoneDuplicated == true || isMailDuplicated == true)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (i == 0)
                        {
                            if (txtBox_userName.Text != "")
                            {
                                if (!NameCheck.IsMatch(txtBox_userName.Text))
                                {
                                    isNameEmpty.Text = "Lütfen rakam ve özel karakterler kullanmayınız!";
                                }

                                else
                                {
                                    isNameEmpty.Text = "";
                                }
                            }

                            else
                            {
                                isNameEmpty.Text = "Lütfen adınızı giriniz!";
                            }

                        }

                        else if (i == 1)
                        {
                            if (txtBox_userSurname.Text != "")
                            {
                                if (!NameCheck.IsMatch(txtBox_userName.Text))
                                {
                                    isSurnameEmpty.Text = "Lütfen rakam ve özel karakterler kullanmayınız!";
                                }

                                else
                                {
                                    isSurnameEmpty.Text = "";
                                }
                            }

                            else
                            {
                                isSurnameEmpty.Text = "Lütfen soyadınızı giriniz!";
                            }

                        }
                        //Mail adresi doğru girilmiş mi kontrol ediliyor
                        else if (i == 2)
                        {
                            if (txtBox_userMail.Text != "")
                            {
                                if (!EmailCheck.IsMatch(txtBox_userMail.Text))
                                {
                                    isMailEmpty.Text = "Lütfen geçerli bir mail adresi giriniz!";
                                }
                                else
                                {

                                    if (isMailDuplicated == true)
                                    {
                                        isMailEmpty.Text = "Bu mail adresi önceden alınmış!";
                                    }

                                    else
                                    {
                                        isMailEmpty.Text = "";
                                    }
                                }
                            }

                            else
                            {
                                isMailEmpty.Text = "Lütfen e-posta adresinizi giriniz!";
                            }


                        }

                        else if (i == 3)
                        {
                            if (txtBox_userPassword.Text != "")
                            {
                                isPasswordEmpty.Text = "";
                            }

                            else
                            {
                                isPasswordEmpty.Text = "Lütfen şifrenizi giriniz!";
                            }

                        }

                        else if (i == 4)
                        {
                            if (txtBox_userPhone.MaskFull)
                            {
                                if (isPhoneDuplicated == true)
                                {
                                    isPhoneEmpty.Text = "Bu telefon numarası önceden alınmış!";

                                }

                                else
                                {
                                    isPhoneEmpty.Text = "";
                                }
                            }

                            else
                            {
                                isPhoneEmpty.Text = "Lütfen telefon numaranızı giriniz!";
                            }

                        }

                        else if (i == 5)
                        {

                            // 1 seçiliyse Erkek   
                            // 2 seçiliyse Kadın   
                            // 3 seçiliyse Belirtmek istemiyorum   


                            if (radioButton_isMale.Checked == true || radioButton_isFemale.Checked == true || radioButton_isNotGiven.Checked == true)
                            {
                                isGenderEmpty.Text = "";

                                if (radioButton_isMale.Checked == true)
                                {
                                    GenderType = 1;
                                }

                                else if (radioButton_isFemale.Checked == true)
                                {
                                    GenderType = 2;
                                }

                                else
                                {
                                    GenderType = 3;
                                }
                            }

                            else
                            {
                                isGenderEmpty.Text = "Lütfen bir seçim yapınız!";
                            }

                        }

                        else if (i == 6)
                        {
                            if (userAge >= 18)
                            {
                                isBirthdateEmpty.Text = "";
                            }

                            else
                            {
                                isBirthdateEmpty.Text = "Uygulamayı kullanabilmek için en az 18 yaşında olmalısınız!";
                            }
                        }
                    }
                }

                else
                {
                    //ID için mükerrer kayıt sorgulama 
                    IDCheck();
                    string encryptedPassword = MD5Sifrele(txtBox_userPassword.Text);

                    dbConnection.Open();

                    SQLiteCommand addUser = new SQLiteCommand("INSERT INTO kullaniciBilgileri (kullaniciMail, kullaniciSifre, kullaniciCinsiyet, kullaniciTelefon, " +
                    "kullaniciAd, kullaniciSoyad, kullaniciDogumTarihi, kullaniciID) " +
                    "values (@mail, @password, @cinsiyet, @telefon, @ad, @soyad, @dogumTarihi, @ID)", dbConnection);
                    addUser.Parameters.AddWithValue("@ad", txtBox_userName.Text);
                    addUser.Parameters.AddWithValue("@soyad", txtBox_userSurname.Text);

                    addUser.Parameters.AddWithValue("@mail", txtBox_userMail.Text);

                    addUser.Parameters.AddWithValue("@password", encryptedPassword);
                    addUser.Parameters.AddWithValue("@cinsiyet", GenderType); //Boolean cinsiyet
                    addUser.Parameters.AddWithValue("@telefon", txtBox_userPhone.Text);
                    addUser.Parameters.AddWithValue("@dogumTarihi", dtp_userBirthdate.Text);
                    addUser.Parameters.AddWithValue("@ID", RandomID); //RANDOM ID
                    addUser.ExecuteNonQuery();
                    dbConnection.Close();
                    clearIsEmptyAndtxtBoxes();
                    MessageBox.Show("Üye kaydınız başarılı bir şekilde tamamlandı! \n Lütfen bir sonraki sayfada e-postanız ve şifreniz ile giriş yapınız!");
                    this.Hide();
                    loginPage.Show();

                }
            }

        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginPage.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
