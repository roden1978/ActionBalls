using Common;
using StaticData;

namespace GameObjectsScripts
{
    public class Cell : IItem
    {
        private readonly CellData _cellData;
        public int Id { get;}
        public bool IsEmpty => _cellData.BallType == BallType.None;
        public Cell(int id, CellData cellData)
        {
            Id = id;
            _cellData = cellData;
        }
    }
}