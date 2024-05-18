using System;
using Common;

namespace GameObjectsScripts
{
    public class Row : IRow
    {
        public int Index { get; private set; }
        public event Action<int> IndexChanged;
        public int Capacity => _rowData.Capacity;
        private readonly RowData _rowData;
        private readonly IRepository<Cell> _repository;
        public Row(int id, RowData rowData)
        {
            Index = id;
            _rowData = rowData;
            _repository = new Repository<Cell>(_rowData.Capacity);
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

    }
}