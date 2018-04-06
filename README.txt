Veri tabanýný nasýl kullandýðým programýn içinde genel hatlarýyla yazýlý ;
Kendi bilgisayarýnýza attack yapýp kendi bilgisayar adýnýzý yazdýðýnýzda çalýþacaktýr.
Genel hatlarýyla algoritma ; SHA - 1  in çalýþma prensibine benzerdir.
Girilen þifreyi öncelikle byte verilere daha sonra da 24 tane byte olacak þekilde geniþletme ile 
24*8=192 bitlik bir çýktý elde etttim daha sonra kendi ürettiðim bir F bloðu ile 6 eþit parçaya böldüðüm
verilerimi XOR iþlemi yaptým.
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
Yukarýda yaptýðým iþlemleri 16 kez tekrar ettirdim.
En sonunda kendi ürettiðim bir deðer ile tuzlama yaptým.
