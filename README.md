## Merhaba, Araba Kiralama Projeme Hoşgeldin..

 ### Proje SOLID, Kurumsal Yazılım Mimari, AOP ve Yazılım Geliştirme Prensiplerine uygun geliştirildi.
 
* .Net Core 3.1 platformu ile geliştirildi.
* **Cross Cutting Concerns** "kesişen ilgililer" **interceptor *Autofac** kütüphanesi kullanılarak geliştirildi.
  * Performance   
  * Transaction
  * Validation
  * Caching

* Entity Framework ORM kullanılarak geliştirildi.
* **AOP** ile **Cross Cutting Concerns** "kesişen ilgililer" projede modülarite yapıda geliştirildi. 
* **Exception Middleware** ile Merkezi hata mekanizması geliştrildi.
* **Claim** Mekanizması ile rol bazlı yetkilendirmenin sınırları esnetildi.
* **JWT (JSON Web Token)** kimlik doğrulaması entegre edildi.
* **Fluent Validation** ile validasyon(doğrulama) işlemleri geliştirildi.
* **IoC(Inversion Of Control)** ile (loose coupling) olan nesneler oluşturuldu.
* **REST VE RESTFUL WEB SERVİS** ile sunucu-istemci iletişimi sağlandı.

### C# Backend Katmanlar

* **Core**: Toolların diğer projelerde kullanılmasını sağlayan genel bir katmandır. 
* **Entities**: Veritabanındaki tabloları nesneye dönüştürdüğümüz katman.
* **DataAccess**: Veritabanı işlemlerini yaptığımız katman.
* **Business**:İş kurallarımızı geliştirdiğimiz katman.
* **WebAPI**: Restful (Representational State Transfer) HTTP protokolü ile sunucu-istemci iletişimi sağladığımız katman. 


