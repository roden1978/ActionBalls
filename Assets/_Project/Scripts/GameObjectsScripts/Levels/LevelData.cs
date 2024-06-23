using System.Collections.Generic;
using StaticData;

namespace GameObjectsScripts.Levels
{
    public class LevelData
    {
        public int Capacity;
        public IEnumerable<IEnumerable<BallType>> RowsData;
        public int TargetScores;
        public bool Circular;
    }
}