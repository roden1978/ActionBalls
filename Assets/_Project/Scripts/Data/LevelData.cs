using System.Collections.Generic;
using GameObjectsScripts;

namespace Data
{
    public class LevelData
    {
        public int Id;
        public int Difficult; // from 5 to 10 cells in row
        public int TargetScores;
        public bool Completed;

        public List<Row> Rows;
    }
}