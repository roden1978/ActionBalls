using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "New RowStaticData", menuName = "StaticData/RowStaticData")]
    public class RowStaticData : ScriptableObject
    {
        [Range(5, 10)]
        public int Capacity;
        public List<BallStaticData> Balls;
    }
}