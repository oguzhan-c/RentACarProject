namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        //kullanıcı hangisiyle çalışmak isterse onunla çalışır. ikiside aynı.
        //objet olanda tip dönüşümü yapılmalı sonra
        Tip Get<Tip>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);//duration : caching de durma süresi;
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
