using System;
using Common;

namespace GameObjectsScripts
{
    public interface IRow : IItem
    {
        int Capacity { get; }
        event Action<int> IndexChanged;
        Cell GetCell(int index);
        void AddCell(Cell cell);
        void UpdateIndex(int newIndex);
        
    }
}