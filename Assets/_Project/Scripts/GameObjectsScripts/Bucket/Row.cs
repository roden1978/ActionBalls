using System;
using System.Linq;
using Common;

namespace GameObjectsScripts
{
    public class Row : IRow
    {
        public Position Position { get; set; }
        public int Index { get; private set; }
        public int Capacity { get; }
        public event Action<int> IndexChanged;
        private readonly IRepository<Cell> _repository;
        public Row(int id, int capacity)
        {
            Index = id;
            Capacity = capacity;
            _repository = new Repository<Cell>(capacity);
        }

        public void AddCell(Cell cell)
        {
            _repository.Add(cell);
        }

        public Cell GetCell(int index)
        {
            return _repository.Get(index);
        }

        public void UpdateIndex(int newIndex)
        {
            Index = newIndex;
            IndexChanged?.Invoke(newIndex);
        }

        public override string ToString()
        {
            return String.Join(", ", _repository.GetAll().Select(x=> x.ReadOnlyBall));
        }
    }

    public struct Position
    {
        public int X;
        public int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}