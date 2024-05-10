using System;
using Common;

namespace GameObjectsScripts
{
    [Serializable]
    public class Row : IItem
    {
        public int Id { get; private set; }
        public int Capacity => _rowData.Capacity;
        private readonly RowData _rowData;
        private readonly IRepository<Cell> _repository;
        public Row(int id, RowData rowData)
        {
            Id = id;
            _rowData = rowData;
            _repository = new Repository<Cell>(Capacity);
        }

        public void AddCell(Cell cell)
        {
            _repository.Add(cell);
        }

        public Cell GetCell(int id)
        {
            return _repository.Get(id);
        }

        public void UpdateId(int newId)
        {
            Id = newId;
        }
    }
}