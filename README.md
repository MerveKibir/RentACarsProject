# :oncoming_automobile: RentACarsProject :oncoming_automobile:
## Veritabanı Tabloları
Projede kullanılan tüm tablolar aşağıdaki fotoğrafta gözüktüğü gibidir.

![image](https://user-images.githubusercontent.com/68849047/158877772-a67f8ae2-e75c-4626-a1ce-8d108d9682d3.png)

# :herb: KATMANLAR
Proje katmanli mimari kulanılarak hazırlanmıştır. Temel 5 katmanımız bulunmaktadır. Bu katmanlar Entities, DataAccess, Business, Core ve WebApi katmanlarıdır.
Çoğu katmanda yer alan iki ana klasör bulunmaktadır. Bunlar Abstract ve Concrete klasörleridir.
- Abstract: Soyut nesnelerinin tutulduğu klasördür.
- Concrete: Soyut nesnelerden türeyen somut nesnelerin tutulduğu klasördür.

1. Entities Katmanı
Veritabanındaki tabloların karşılığı bu katmanda tutuluyor. Her bir tablo için bir entity oluşturmamız gerekiyor. Ayrıca Dto(Data Transfer Object) ile çaşitli entityleri kapsayan kendi nesnelerimizi oluşturabiliyoruz.

![image](https://user-images.githubusercontent.com/68849047/158879962-4a631259-6f72-4872-b27b-18d079b5453d.png)

2. DataAccess Katmanı
Veritabanı CRUD (Ekleme, Okuma, Güncelleme ve Silme) işlemlerini EntityFramework kullanarak bu katmanda hallediyoruz. Bu katman Core ve Entity katmanını referans alır. Diğer katmanlardan referans almaz.

![image](https://user-images.githubusercontent.com/68849047/158880018-1dfa8758-b72c-4743-9ef1-cdd2104ee5be.png)

3. Business Katmanı
Bu katman, uygulama katmanı(Web Api) ile DataAccess katmanı arasındaki veri işleme olayını gerçekleştirir. Bir nevi ikisi arasında köprü görevi görür. Bu katmanın önemli kısmı ise tüm doğrulama ve veri kontolünü gerçekleştirmesidir.
Bu katmanda Abstact, Concrete, Constant klasörleri bulunmaktadır. Proje devamında  Adapters, DependencyResolvers, ValidationRules klasörleri de eklenecektir.
  - Constants: Bu klasörde business katmanında kullandığımız değişmeyen değerleri tutuyoruz. Örneğin; Messages sınıfı.
  
![image](https://user-images.githubusercontent.com/68849047/158880179-49341802-1d30-44ef-8bc4-44d4b009ee2c.png)

4. Core Katmanı
Bu katman, projeden bağımsız olarak projenin ana çekirdek kısımlarını oluşturuyor. Bu katman asla diğer katmanları referans almaz. Bu katmanı istediğimiz herhangi bir projede hiç değişiklik yapmadan aynen kullanabiliriz.
Bu katmanda; DataAccess, Entities, Utilities klasörleri yer almaktadır ve proje geliştirildikçe eklenecek klasörler de bulunmaktadır.
  - DataAccess: Bu katmanda DataAccess katmanında yer alan Temel interface yapıları ve EntityFramework için genel Base sınıf bulunmaktadır.
  - Entities: Birbirinden bağımsız tüm projelerde yer alacak genel interface ve ana sınıflar bulunmaktadır.
  - Utilities: Core katmanının belkide en önemli kısmı bu diyebiliriz. Tüm alt araçların yer aldığı bu klasörde; Helper sınıflar, Results klasörleri bulunmaktadır. Bu klasörleri kısaca açıklar isek;
      - Helpers: Tüm projelerde yer alacabilecek yardımcı sınıfların yer aldığı klasördür.
      - Results: Bu klasörde uygulama boyunca verilerin yönetebilmeyi kolaylaştıran sınıflar yer almaktadır.Verinin bilgisi, mesaj bilgisi veya dönen verinin success bilgisini içerir.

![image](https://user-images.githubusercontent.com/68849047/158880123-8a4e1c68-fb10-4fae-a2d7-df6bc9cfd61f.png)

> MERVE KİBİR
