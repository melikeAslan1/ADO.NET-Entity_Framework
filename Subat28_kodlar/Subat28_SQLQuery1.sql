--select * from sys.databases

--sql server yeni bir database oluþtururken master a göre oluþturur. yani master þablon gibi.

--herhangi bir veri tabanýna ulaþmak için Connection String i mutlaka bilmen gerekir.

--ilk soru þu connection string nerde oluþur nasýl oluþur bunlarý belirlemem lazým.

--SELECT * FROM TB_ALAN A, TB_OGRETMEN O




CREATE DATABASE KitapDB
GO
use KitapDB

CREATE TABLE Yazarlar (YazarID int IDENTITY PRIMARY KEY, YazarAdi varchar (20), YazarSoyad varchar(20))
CREATE TABLE Kategoriler (KategoriID int IDENTITY PRIMARY KEY, KategoriAdi varchar(25))
GO
CREATE TABLE kitaplar (KitapID int IDENTITY PRIMARY KEY, KitapAdi varchar(100), KategoriID int REFERENCES Kategoriler(KategoriID),
                       YazarID int REFERENCES Yazarlar(YazarID),
					   EklenmeTarihi smalldatetime DEFAULT getdate(),
					   OkunmaSayisi int)


INSERT INTO Yazarlar VALUES ('Mehmet Akif', 'Ersoy')
INSERT INTO Yazarlar VALUES ('George', 'Orwell')

INSERT INTO Kategoriler Values ('Siir'), ('Roman'),('Deneme')

INSERT INTO Kitaplar VALUES ('Safahat', 1,1, GETNAME(),0),('1984',2,2, GETNAME(),0)

SELECT * FROM Kitaplar




