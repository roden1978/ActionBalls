using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "New BallStaticData", menuName = "StaticData/BallStaticData")]
    public class BallStaticData : ScriptableObject
    {
        public BallType BallType;
        public Sprite Icon;
    }
}