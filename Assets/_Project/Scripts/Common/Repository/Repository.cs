using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Repository<T> : IRepository<T> where T : IItem
    {
        private readonly List<T> _repository;

        public Repository()
        {
            _repository = new();
        }

        public Repository(int capacity)
        {
            _repository = new(capacity);
        }
        public T Get(int id)
        {
            return _repository.First(x => x.Index == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository;
        }

        public void Add(T item)
        {
            _repository.Add(item);
        }

        public void AddToId(int id, T item)
        {
            _repository[id] = item;
        }

        public void Remove(T item)
        {
            _repository.Remove(item);
        }

        public void RemoveById(int id)
        {
            _repository.RemoveAt(id);
        }
        
    }
}