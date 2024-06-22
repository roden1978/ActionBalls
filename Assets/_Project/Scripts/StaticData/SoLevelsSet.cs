using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "New LevelsSet", menuName = "StaticData/LevelsSet")]
    public class SoLevelsSet : ScriptableObject
    {
        [CustomReadOnly]
        public string Path;
        public List<string> LevelsSet;
    }
}