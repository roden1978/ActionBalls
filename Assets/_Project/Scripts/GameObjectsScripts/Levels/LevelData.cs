using System;
using System.Collections.Generic;
using StaticData;
using UnityEngine.Serialization;

namespace GameObjectsScripts
{
    [Serializable]
    public class LevelData
    {
        public int Capacity;
        public List<string> RowsData;
        public int TargetScores;
        public bool Circular;
        public string UniqueTypes;
    }
}