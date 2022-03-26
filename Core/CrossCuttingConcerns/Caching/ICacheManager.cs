using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    //microsoft harici cache yapmak istersem de bu arayüzü kullanabilirim
    public interface ICacheManager
    {
        //birden fazla yani liste gelecekse
        T Get<T>(string key);
        //tek veri gelecekse
        object Get(string key);
        //object yerine her obje gelebilir
        //duration ne kadar duracak süresi verilebilir (dk)
        void Add(string key, object value, int duration);
        //cache den mi vtden mi burada cache de var mı diyo kontrol yapılır
        bool IsAdd(string key);
        //cache den kaldır
        void Remove(string key);
        //isminde .. olanları - sil içinde varsa sil
        void RemoveByPattern(string pattern);
    }
}