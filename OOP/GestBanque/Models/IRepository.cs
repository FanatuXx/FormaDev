using System.Runtime.Serialization;

namespace Models;

public interface IRepository<TValue, TKey>
    where TValue : new()
    where TKey: notnull
{
    TValue Create(TValue value);
    TValue? Read(TKey key);
    List<TValue> ReadAll();
    TValue? Update(TKey key, TValue value);
    void Delete(TKey key);
}

public class CompteRepository : IRepository<Courant, int>
{
    public Courant Create(Courant value)
    {
        throw new NotImplementedException();
    }

    public Courant? Read(int key)
    {
        throw new NotImplementedException();
    }

    public List<Courant> ReadAll()
    {
        throw new NotImplementedException();
    }

    public Courant? Update(int key, Courant value)
    {
        throw new NotImplementedException();
    }

    public void Delete(int key)
    {
        throw new NotImplementedException();
    }
}