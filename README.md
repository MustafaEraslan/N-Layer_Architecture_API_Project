# N-Layer_Architecture_API_Project

##2. Http Method Tipi Seçimi:

GET: server tararfında istek
POST: API lerde yeni nesne oluşturmak istiyorsak kullanımalı/pos üzerinden de güncelleme yapılabilir.
PUT: eğer bir nesene üzerinde güncelleme yapacaksak
DELETE: bir nesneyi silmek için kulllanılan http method tipi.
crud işlemleri deniyor.
#best practices,

clienta açacağımız endpoint genel isimler ile olmalı. Best practices ile ilgilidir. Genellikle çoğul isim kullanılıyor. End pointleri bizim methodumuz ile eşleştireceğiz.

Best practices için kategori ismi olacak, ardında ID değerleri ilerleyecek. get post put değişiyor olacak.

#Doğru http cevap durum kodları:

100 information responses
200 successful responses
300 reirect messages (başka bir end pointe yönlendirme durumu)
400 client error responses
500 server error responses

en çok bilinen kodlar
200 ok
201 created
204 Nocontent
400 badRequest
401 unauthorized eğer güvenli bir endpoint çalışıyorsak yani token alması gereken bir yapımız mevcutsa bu rescponcensu dönebiliriz. Tamemen token yanlış isteği yapanı bilmiyorum
403 Forbid Endpointe istek yaptı fakat yetkisi bulunmuyorsa bu kodu döneriz. İsteği kimin yaptığını biliyorum ama yetkisi bulunmuyorsa bu durum kodunu döneriz.
404 NotFound
500 internal server error

#doğru endpoint url yapısı

/categories/2/products > doğrudur.
2. kategorideki ürünleri getir

/categories/2/products/5 yanlış
2. kategorideki 5. ürünü getir. Burada bir adım daha götürmemek lazım.
bunun yerine

products/5 yapmak lazım

# request içerisinde 

##7. Asp.net Core uygulamanın startup.cs Dosyasını mümkün olduğunca sade bırak

public void ConfigureServices(IServiceCollection services)
public void ConfigureServices(IApplicationBuilder app, IWebhostEnviroment env)

##8. Uygulamanızı mümkün oldukça küçük parçalara böl

MySite.Web => web uygulaması
MySite.API => api uygulaması

MySite.Core => class library
MySite.Data => class library
MySite.Service =>class library
MySite.Logging =>class library

##9. Controller sınıflarınız mümkün oldukça temiz tutun. Business kodu bulundurmayın.

##10. Action methodlarınızı mümkün oldukça temiz tutun. Business kodu bulundurmayın.

##11. Hataları global olarak ele alın. Action methodlar içerisinde try catch blokları

MySite.Core 

##n layer proje katmanı:

en az 3 katman best practis açısından önemlidir:
core>repository>service şeklindedir.   apı yada web(mvc)  şeklinde kullanılır.

![image](https://user-images.githubusercontent.com/44713722/188304160-f0820bb8-4e8c-4fe1-8e32-ede10afa98c6.png)
Burada web olarak gösterilen örneğin MVC düşüebiliriz.

## core katmanı:

temel katmandır. Proje genelini 
ne bussinis ne de class tanımlı olacak.  Projenin genelini oluşturan sınıflar olmalı.
modeller(entity) olacak
DTOs olacak
repositort interfaces
service Interfaces
UnitOfWork Interfaces (bir dizayn pattern'dir.)


## reporsitorty katmanı:(data acces layer denirdi önceden)

core katmanını referans akcak.
Migration dosyaları olacak. Veri tabanı ile sign olacak dosyalardır.
seeds dosyaları olacak. Veri tabanına default data atacaksak bunu kullanırız. Veri tabanına default veri atmak istiyorsak kullanırız.
Biz burada implement yapıyoruz. Core katmanınında ref alarak.

## Service katmanı:

Mapping işlemi yapılıyor.
Service Impl 
Validation code'lar buarrada
Exceptions burada 
reporsitory katmanını referans alacak.

Ek olarak caching katamnı da tabii eklenilebiliyor.

![image](https://user-images.githubusercontent.com/44713722/188304615-bed92595-a40f-41f9-8a67-92085ff294c5.png)

API yada web uygulamaaız db tarafında dataların cachlenmesini sağlayacak. Biz eğer bir data almak istiyorsak burada cach'te eğer data bulunuyorsa direkt gidip cach ortamından data dönülecek.
Eğer yoksa repository'den datayı dönecek.

12. Tekrar eden kodlardan kaçınmak için filter kullan

validation filter kullandık. attribute olarak eklenir. Kod tekrarından kaçınmış oluruz.

13. Action methodlardan direk olarak model sınıflarınızı dönmeyin

action methodlardan direk olarak model sınıflarınızı dönmeyin. İlgili modellerin DTO(data transfer object) sınıflarını dönün. 
preperty? nedir? araştır.

2022 preview versiyon indir:


kafka nedir 
rubbetmq, seper işlemleri yapan servisim var microsevice, ödeme ekranına geldiğinde sepetten ödeme servisine nasıl geçti
sepet servisi q'ya geçiyor. rubbetmq diyor ki önce sepet sonradan ödemeyi çalıştırcam diyor.
saga pattern microservice'te çok kullanılır.
Q sistemleri kullanmak lazım
