using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;


namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string mail, verimail;
        string kullanici_adi;
        string sifre, verisifre, hashsifre;
        veritabani veritabanisınıfı = new veritabani();
        SqlConnection baglanti = new SqlConnection("Data source=DESKTOP-OQ5OTE1\\SQLEXPRESS;Initial Catalog=Kullanici_girisi;Integrated Security=true");
        
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            label6.Text = "";
            try
            {

                mail = textBox1.Text;
                if (textBox1.Text == "")
                {
                    label5.Text = "Mail Adresinizi Giriniz";
                }
                else
                {
                    if (IsValidEmail(mail) == false)
                    {

                        label5.Text = "Girilen E - posta hatalı kontrol ediniz.";

                    }
                    else
                    {
                        if (E_postaKontrol(mail) == true)
                        {

                            label5.Text = "..... Girilen e_posta kayıtlı .....";
                        }
                        else
                        {
                            label5.Text = "";
                            verimail = mail;
                        }
                    }
                }
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Kullanıcı adınızı giriniz...");
                }
                else
                {
                    kullanici_adi = textBox2.Text;
                }
                sifre = textBox3.Text;
                if (sifre == textBox4.Text)
                {
                    if (textBox3.Text.Length < 8)
                    {
                        label6.Text = "şifre 8 - 16 karakter uzunluğunda olmalı";
                    }
                    else
                    {
                        verisifre = sifre;
                    }
                }
                else
                {

                    label6.Text = "Şifreler aynı değil";
                }

               
                veritabanisınıfı.veri_kaydet(kullanici_adi, verimail, verisifre);
            }
            catch(Exception)
            {
                MessageBox.Show("Verileri Kontrol ediniz.");
            }
            
      
         
        

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label5.Text = "";
            label6.Text = "";
            textBox3.MaxLength = 16;
            textBox4.MaxLength = 16;
            textBox3.PasswordChar = '*';
            textBox4.PasswordChar = '*';
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //checkBox işaretli ise
            if (checkBox1.Checked)
            {
                //karakteri göster.
                textBox3.PasswordChar = '\0';
                textBox4.PasswordChar = '\0';

            }
            //değilse karakterlerin yerine * koy.
            else
            {
                textBox3.PasswordChar = '*';
                textBox4.PasswordChar = '*';


            }
        }
        public bool E_postaKontrol(string e_posta)
        {
             baglanti.Open();
              SqlCommand komut = new SqlCommand("select * from bilgiler where e_posta='" + e_posta + "'", baglanti);
              SqlDataReader dr = komut.ExecuteReader();



              if (dr.Read())
              {
                  return true;

              }

              else
              {
                  return false;
              }
            baglanti.Close();

        
        }
        

    }
}
