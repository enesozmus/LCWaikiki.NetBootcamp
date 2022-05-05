Use[master]
GO
CREATE DATABASE demoDB

CREATE TABLE Humans(
Id int identity(1,1),
Name varchar(15)
)

declare @number int
	set @number = 1
while @number<= 100000
BEGIN
INSERT INTO Humans
	SELECT 'Name' + ' ' + CAST(@number AS varchar(15))
	SET @number = @number+1
END


SELECT * FROM Humans

-- Humans Tablosu'nun toplam boyutunu verir.
sp_spaceused 'Humans'
/*2824 KB KB */


SET STATISTICS IO ON
	SELECT * FROM Humans WHERE Id = 98000
	-- logical reads: 350
	-- 1 page == 8kb
	-- logical reads 350 → 350*8 = 2800 kb'lık bir okuma
	
	-- Veritabınında saklanan verilerin sayısı arttıkça performansta düşüklüğe neden olur. Dağınık bir yapıda olan verilerde istenilen veriyi aramak için tablo taraması işlemi yapılır.
	-- Artan veri miktarı bu işlemin harcadığı süreyi artıtırır.
	-- Index Kullanımı: İşlenen verinin daha az veri okunarak sorgu sonucunun daha kısa zamanda getirilmesini sağlar.
	-- Eğer bir tabloda anahtar değer(primary key) varsa bu bir kümelenmiş indeks yapısıdır. Kümelenmiş indeks ya artan ya da azalan sırada olmalıdır.

CREATE CLUSTERED INDEX idx_Id
ON Humans(Id)


SET STATISTICS IO ON
	SELECT * FROM Humans WHERE Id = 98000
	-- logical reads: 2
	-- 1 page == 8kb
	-- logical reads 350 → 2*8 = 24 kb'lık bir okuma => kazanım inanılmaz!
