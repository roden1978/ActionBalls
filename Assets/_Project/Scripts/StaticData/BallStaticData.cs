using Data;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "New BallStaticData", menuName = "StaticData/BallStaticData")]
    public class BallStaticData : ScriptableObject
    {
        [CustomReadOnly]
        public string BallType;
        public Sprite Icon;
        public BallState BallState;
    }
}