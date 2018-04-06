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
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data source=DESKTOP-OQ5OTE1\\SQLEXPRESS;Initial Catalog=Kullanici_girisi;Integrated Security=true");
        // veri tabanııyla olan bağlantımı burada yaptım
        string hashsifre;
        veritabani veritabanisınıfı = new veritabani();
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(); // kayıt ola basılırsa eğer kayıt ekranı açmak için varolan ekranı kapatıp kayıtol ekranını açtım.
            form2.Show();
            Form1 form1 = new Form1();
            form1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

         
            hashsifre = "";
            // verilerimin veritabanıyla eşleşip eşlemediğine bakmak için bağlantımı açtım
            baglanti.Open();
            hashsifre =veritabanisınıfı.hashleme(textBox2.Text); // yazılan şifreyi veri tabanında hashleyerek tuttuğum için önce girilen şifreyi hash  fonksiyonunda çalıştırdım.
            hashsifre = veritabanisınıfı.tuzlama(hashsifre);// tuzlama işlemi yaptığım içn tuzlama da yapıp kontrol ettim.


            SqlCommand komut = new SqlCommand("select * from bilgiler where e_posta='" + textBox1.Text + "'and sifre='" + hashsifre + "'", baglanti);
            //tablomdaki e-posta ve şifre girilen şifre ve e-posta ile uyuşup uyuşmuyormu ona baktım
            SqlDataReader dr = komut.ExecuteReader();// değerlerimi tabloyu okuyarak yaptım.
            if (dr.Read())
            {
                // eğer okunan değer true döndürürse yeni bir form ekranı açtım
                Form3 form3 = new Form3();
                form3.Show();
            }
            else
            {
                //false döndürürse buraya atayıp yeni griş yapması gerektiğini söyledim.
                MessageBox.Show(".......E-posta veya Şifre Yanlış......");
            }
            baglanti.Close();
        }
        public static bool IsValidEmail(string email)
        {
            // girilen e-postanın gerçekten bir e-posta olup olmadığını kontrol etmek için böyle bir fonksiyon oluşturdum.
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.MaxLength = 16; // 8-16 karakter arasında şifre alacağım için textbox a girilen karakter değerini 16 ile sınırlandırdım.
            textBox2.PasswordChar = '*';

        }
       

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            //checkBox işaretli ise
            if (checkBox1.Checked)
            {
                //karakteri göster.
                textBox2.PasswordChar = '\0';

            }
            //değilse karakterlerin yerine * koy.
            else
            {
                textBox2.PasswordChar = '*';
               

            }
        }
        
   
    }
}
