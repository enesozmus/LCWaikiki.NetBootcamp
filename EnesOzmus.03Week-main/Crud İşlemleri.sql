USE [EnesOzmus.03Week]
GO
/** Temel CRUD İşlemleri **/
--SELECT: 					Veri tabanından verileri getirir.
		-- Ürünler tablosunu getir
		SELECT * FROM Products;
		-- Ürünler tablosundan ad ve fiyat sütünlarını getir.
		SELECT Name, Price FROM Products;
		-- Kategoriler tablosunun eklenme tarihlerini getir.
		SELECT CreatedDate FROM Categories;


--WHERE:					Yalnızca belirli bir koşulu karşılayan kayıtları getirir.
		-- Ürünler tablosundan Id'si 1 olan ürünü getir.
		SELECT * FROM Products WHERE Id = 1;
		-- Ürün Detayları tablosundan markası LCW olan ürünleri getir.
		SELECT * FROM ProductDetails WHERE Brand = 'LCW';


--INSERT INTO:				Bir tabloya yeni kayıtlar ekler.
	-- Kategoriler tablosuna yeni bir kategori ekler.
	INSERT [dbo].[Categories] ([CategoryName], [Description], [CreatedDate], [LastModifiedDate]) VALUES (N'Yelekler', N'Kış Sezonu', CAST(N'2022-04-26T00:00:00.0000000' AS DateTime2), NULL)


--UPDATE:					Bir tablodaki mevcut kayıtları düzenler.
--						WHERE yan tümcesini hangi kayıtların güncellenmesi gerektiğini berlirtir.
--						DİKKAT!: WHERE yan tümcesini atlarsanız, tablodaki tüm kayıtlar güncellenecektir!
	-- Ürünler tablosundaki Id'si 1 olan ürünü günceller.
	UPDATE Products SET Name = 'Deneme' WHERE Id = 1;
	-- Kategoriler tablosundaki adı Kazak olan kategoriyi günceller.
	UPDATE Categories SET CategoryName = 'test' WHERE CategoryName = 'Kazak';

--DELETE:					Bir tablodaki mevcut kayıtları siler.
--						WHERE yan tümcesini hangi kayıtların silinmesi gerektiğini berlirtir.
--						DİKKAT!: WHERE yan tümcesini atlarsanız, tablodaki tüm kayıtlar silinecektir!
	-- Ürünler tablosundaki Id'si 1 olan ürünü siler.(kısıtlandı)
	DELETE FROM Products WHERE Id = 1;
