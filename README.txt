Veri taban�n� nas�l kulland���m program�n i�inde genel hatlar�yla yaz�l� ;
Kendi bilgisayar�n�za attack yap�p kendi bilgisayar ad�n�z� yazd���n�zda �al��acakt�r.
Genel hatlar�yla algoritma ; SHA - 1  in �al��ma prensibine benzerdir.
Girilen �ifreyi �ncelikle byte verilere daha sonra da 24 tane byte olacak �ekilde geni�letme ile 
24*8=192 bitlik bir ��kt� elde etttim daha sonra kendi �retti�im bir F blo�u ile 6 e�it par�aya b�ld���m
verilerimi XOR i�lemi yapt�m.
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
Yukar�da yapt���m i�lemleri 16 kez tekrar ettirdim.
En sonunda kendi �retti�im bir de�er ile tuzlama yapt�m.
