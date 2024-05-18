using System;
using StaticData;

namespace GameObjectsScripts
{
    public class Cell : ICell
    {
        public event Action<int> IndexChanged; 
        public int Index { get; private set; }
        public bool isEmpty => _cellData.BallType == BallType.None;
        
        private readonly CellData _cellData;
        public Cell(int id, CellData cellData)
        {
            Index = id;
            _cellData = cellData;
        }

        public void UpdateIndex(int newIndex)
        {
            Index = newIndex;
            IndexChanged?.Invoke(newIndex);
        }

        public IReadOnlyBall ReadOnlyBall { get; }
    }
}