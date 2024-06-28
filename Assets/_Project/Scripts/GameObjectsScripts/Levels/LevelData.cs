using System;
using System.Collections.Generic;
using Common;

namespace GameObjectsScripts
{
    [Serializable]
    public class LevelData : IItem
    {
        public int Index { get; private set; }
        public string LevelKey;
        public int Capacity;
        public List<string> RowsData;
        public int TargetScores;
        public bool Circular;
        public string UniqueTypes;

        public LevelData(string levelKey, int capacity, List<string> rowsData, int targetScores, bool circular, string uniqueTypes)
        {
            LevelKey = levelKey;
            Capacity = capacity;
            RowsData = rowsData;
            TargetScores = targetScores;
            Circular = circular;
            UniqueTypes = uniqueTypes;
        }

        public void AddIndex(int index)
        {
            Index = index;
        }
    }
}