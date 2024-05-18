using System;
using Common;

namespace GameObjectsScripts
{
    public interface ICell : IItem
    {
        bool isEmpty { get; }
        event Action<int> IndexChanged;
        void UpdateIndex(int newIndex);
    }
}