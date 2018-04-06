using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class veritabani
    {
        string hashsifre="";
        SqlConnection baglanti = new SqlConnection("Data source=DESKTOP-OQ5OTE1\\SQLEXPRESS;Initial Catalog=Kullanici_girisi;Integrated Security=true");
        public void veri_kaydet(string kullanici_adi, string e_posta, string sifre)
        {

            hashsifre = hashleme(sifre); // öncelikle hashleme
            hashsifre = tuzlama(hashsifre);// sonra tuzlama yaptım
            baglanti.Open();
            SqlCommand yeniveri = new SqlCommand("insert into bilgiler (kullanici_adi,e_posta,sifre) values ( '" + kullanici_adi + "','" + e_posta + "','" + hashsifre + "')", baglanti);
            yeniveri.ExecuteNonQuery();//  veri tabanına değrlri yazdım
            MessageBox.Show("Kayıt BAŞARILIIIIIIIII..........");
            Form1 form1 = new Form1();
            form1.Show();
            Form2 form2 = new Form2();
            form2.Close();
        }








        public string hashleme(string sifre)
        {
            char[] karakter;
            byte[] veri;
            int a = 0;
        
            byte[] veriler = new byte[24];
            byte[] A = new byte[4];
            byte[] B = new byte[4];
            byte[] C = new byte[4];
            byte[] D = new byte[4];
            byte[] E = new byte[4];
            byte[] G = new byte[4];


            karakter = sifre.ToCharArray();
            veri = System.Text.Encoding.UTF8.GetBytes(karakter);
            for (int i = 0; i < 24; i++)
            {
                if (i < veri.Length)
                    veriler[i] = veri[i];
                else veriler[i] = 1;
            }
            for (int j = 0; j < 6; j++)
                for (int i = 0; i < 4; i++)
                {

                    if (j == 0)
                    {
                        A[i] = veriler[a];
                    }
                    else if (j == 1)
                    {

                        B[i] = veriler[a];
                    }
                    else if (j == 2)
                    {
                        C[i] = veriler[a];
                    }
                    else if (j == 3)
                    {
                        D[i] = veriler[a];
                    }
                    else if (j == 4)
                    {
                        E[i] = veriler[a];
                    }
                    else if (j == 5)
                    {
                        G[i] = veriler[a];
                    }
                    a++;

                }
            a = 0;
            for (int k = 0; k < 16; k++)
            {
                A = Xorfonksiyon(A);
                B = Xorfonksiyon(B);
                C = Xorfonksiyon(C);
                D = Xorfonksiyon(D);
                E = Xorfonksiyon(E);
                G = Xorfonksiyon(G);
                A = Shifleme(A);
                C = Shifleme(C);
                G = Shifleme(G);
                A = FFonksiyon(A, B, C);
            }
            byte[] sonsifre = new byte[24];
            for (int j = 0; j < 6; j++)
                for (int i = 0; i < 4; i++)
                {

                    if (j == 0)
                    {
                        sonsifre[a] = A[i];
                    }
                    else if (j == 1)
                    {

                        sonsifre[a] = B[i];
                    }
                    else if (j == 2)
                    {
                        sonsifre[a] = C[i];
                    }
                    else if (j == 3)
                    {
                        sonsifre[a] = D[i];

                    }
                    else if (j == 4)
                    {
                        sonsifre[a] = E[i];

                    }
                    else if (j == 5)
                    {
                        sonsifre[a] = G[i];

                    }
                    a++;

                }



            for (int j = 0; j < 24; j++)
            {
                hashsifre = hashsifre + sonsifre[j].ToString();
            }
            return hashsifre;
           
           

        }
        public string tuzlama(string hashsifre)
        {
            String salt = "20180602199429236789";
            hashsifre = salt+hashsifre;
            return hashsifre;
        }


        byte[] Xorfonksiyon(byte[] parametre)
        {
            byte[] F = { 06, 02, 19, 94 };
            for (int i = 0; i < 4; i++)
            {
                parametre[i] = (byte)(parametre[i] ^ F[i]);
            }
            return parametre;
        }
        byte[] Shifleme(byte[] parametre)
        {
            byte[] F = { 10, 10, 10, 10 };
            for (int i = 0; i < 4; i++)
            {
                parametre[i] = (byte)(parametre[i] << F[i]);
            }
            return parametre;
        }
        byte[] FFonksiyon(byte[] parametre, byte[] parametre2, byte[] parametre3)
        {
            for (int i = 0; i < 4; i++)
            {
                parametre[i] = (byte)(parametre[i] << parametre2[i] ^ parametre3[i]);
            }

            return parametre;
        }
       
      
    }
}
