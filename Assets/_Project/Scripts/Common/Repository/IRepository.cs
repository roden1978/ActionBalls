using System.Collections.Generic;

namespace Common
{
    public interface IReadonlyRepository<out T>
    {
        T Get(int id);
        IEnumerable<T> GetAll();
    }

    public interface IWriteOnlyRepository<in T>
    {
        void Add(T item);
        void AddToId(int id, T item);
        void Remove(T item);
        void RemoveById(int id);
    }
    
    public interface IRepository<T> : IReadonlyRepository<T>, IWriteOnlyRepository<T> where T : IItem
    {
        
    }
}