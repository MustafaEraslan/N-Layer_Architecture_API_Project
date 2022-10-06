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

Mutlaka kodlamadan önce WEB ve API ayağa kalkıyor mu bir çalıştırıp görmek lazım.

2022 preview versiyon indir:


kafka nedir 
rubbetmq, seper işlemleri yapan servisim var microsevice, ödeme ekranına geldiğinde sepetten ödeme servisine nasıl geçti
sepet servisi q'ya geçiyor. rubbetmq diyor ki önce sepet sonradan ödemeyi çalıştırcam diyor.
saga pattern microservice'te çok kullanılır.
Q sistemleri kullanmak lazım

![image](https://user-images.githubusercontent.com/44713722/188330938-8f3934cd-7c53-4a35-bc89-5e5ee3f8cac3.png)

## neden entitiy oluşturuyoruz?

Eğer proje içerisinde bir class'ın veri tabanı tarafında bir karşılığı varsa bunlara entityclass diyoruz. Herhangi bri yerde bir tablo karşılığı yoksa bu normal class'tır.

Abstract class ile new sözcüğü kullanarak yeni nesne oluşturamayız. Soyut yapılardır.

Genelde abstract class proje için ortak nesneleri tanımladığımız yerlerdir.

Interface ile yapabildiklerimizi abstract sınıf ile de yapabiliriz.

![image](https://user-images.githubusercontent.com/44713722/188331711-13d4a8fb-aa92-4efa-afa8-b33abc95c88b.png)

birebir ilişki kuruyoruz.

entity'lerde isimlendirmeyi düzgün yaptığımızda EF tarafından PK otomatik bir şekilde algılanılıyor. Eğer isimlendirme _ gibi karakterler kullanılcaksa bu sefer [foreignkey] kullanmak zorundayız.

## net6 nullable:

kodlama esnasında yeşil olan alanları gösterebilir. 

![image](https://user-images.githubusercontent.com/44713722/188697760-8ecf088a-7290-4029-b577-203418ab74b7.png)

Alt bölümdeki alan seçilerek nullable özelliği kapatılabilir.
![image](https://user-images.githubusercontent.com/44713722/188702958-a798ca4c-7e85-44c9-9427-70111a0b97f2.png)

Veya ctro ile constructure yazabiliriz. Burada alt bölümdeki gibi eğer null ise throw ile exception dön diyebiliyoruz.

        public Product(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));

        }
        
Yada şu şekilde dissable olarak nullable kapatabiliriz.        

![image](https://user-images.githubusercontent.com/44713722/188703547-22d618d5-b4fb-4788-98ea-59c4b53d0a0e.png)

## IGenericRepository

![image](https://user-images.githubusercontent.com/44713722/188704453-0133f8a2-1e01-4d26-bf65-98057e847c58.png)

Repository disaign pattern kodumuz ile veritabanı arasına bir katman yerleştirir. Bu katman ile veritabanına yapılcak klasik CRUD işlemlerini her bir entity için yapabilmemizi sağlar. Generic yani muhtemel created, update vs işlemlerini yapabiliyor olacak.

## IService
## IUnitOfWork Dissaign pattern nedir?

IUnitOfWork Dissaign pattern, veri tabanına yapılacak olan işlemleri toplu bir şekilde tek bir transaction üzerinden yönetmemize imkan verir.

![image](https://user-images.githubusercontent.com/44713722/188863844-1f7deb1c-59d0-4461-a2d4-fb6f6432ef55.png)

Bir repository üzerinde yapılan işlemler EF tarafından memoryde tutulur. Savechanges çağırdığımız zaman gidip db context nesnesi ile db tarafına yazılır. 
Unit of Work ise farklı 2 repository olduğu durumu düşünelim. Eğer bir reporsitory'de savechanges başarıkı bir şkeilde çalıştı. Eğer diğerinde başarılı değilse 2 repositorydeki değişiklikleri rollback yapar. 

## AppDbContext

DbContextOptions veritabanı yolunu startup dosyasından verebilmek için yazıyoruz.

## Entity Configuretions

Her bir class library bir assemby'dir. Bu sebeple tüm configuration'ları okuyabiliriz. alt bölümdeki kod ile.

modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

## Seed Data 

giriş değerleri verebiliriz. 2 tane yöntemi vardır.

1. migration atılırken dataarın iletilmesi
2. migration atıldıktan sonra uygulama ayağa kaldırıldığında dataların alınması.

AsNoTracking ile EF Core dataları memoriye almasın traking yapmasın ki performanslı olmasın.

remove da asyc yok çünkü db den silmez. remove dediğimizde aslında sadece o entity'in satete'ini delete olarak işaretliyoruz.

## Migration

migration bizim code'larımızdaki entitylerimiz ile sql serverdaki tablolarımızın eş olmasını sağlayan bir tool'dur. Bu tool sayaseinde migration komutları girerek
bizler code tarafındaki entity güncel halini tabloları yansıtabiliyoruz.

![image](https://user-images.githubusercontent.com/44713722/189524188-f968bb97-d716-46be-baa3-01cc2e60c84d.png)

tıkladığımızda kayıtlı db'leri görebiliyoruzz. Bunların her biri instance. + bölümünde localde bulunan db'leri görüp ekleyebiliyoruz.

connection string alınır. API de appjson bölümüne eklenir. 

connection string program cs de tanımlanır.
 


Alınan hatalar:
An error occurred while accessing the Microsoft.Extensions.Hosting services. Continuing without the application service provider. Error: Cannot instantiate implementation type 'NLayer.Core.UnitOfWorks.IUnitOfWorks' for service type 'NLayer.Core.UnitOfWorks.IUnitOfWorks'.

## Git & Github hakkında...

bir takımla çalıştığımızda commit atıyorsak proje sahibine bir talep gönderiyor. Pull request denir.
Benim yaptığım değişiklikler projenin bir parçası olsun mu? Sorusuna yanıt bulabiliyoruz.

versiyonları yeni bir branch üzerinden yapabiliriz.

git --version
git help detayları getirir.






  
