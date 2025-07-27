CodeFirstRelation Projesi
Bu proje, Entity Framework Core kullanarak Code First yaklaşımı ile User (Kullanıcı) ve Post (Gönderi) tabloları arasındaki bire-çok (one-to-many) ilişkiyi modellemektedir.

📌 Proje Yapısı
Entities

BaseEntity: Ortak alanları (örneğin Id) barındırır.

UserEntity: Kullanıcı bilgilerini (UserName, Email) ve ilişkili gönderileri (Posts) tutar.

PostEntity: Gönderi bilgilerini (Title, Content) ve gönderiyi oluşturan kullanıcının UserId alanını tutar.

Context

PatikaSecondDbContext: Veritabanı bağlantısı ve entity'ler arasındaki ilişkiler burada tanımlanmıştır.

🔗 İlişki Yapısı
Bir User birden fazla Post oluşturabilir.

Her Post yalnızca bir User'a aittir.

OnModelCreating metodu içinde ilişki şu şekilde tanımlanmıştır:

csharp
Kopyala
Düzenle
modelBuilder.Entity<PostEntity>()
    .HasOne(p => p.User)       // Her Post bir User'a aittir.
    .WithMany(u => u.Posts)    // Bir User birden fazla Post'a sahip olabilir.
    .HasForeignKey(p => p.UserId); // İlişki UserId üzerinden kurulur.
