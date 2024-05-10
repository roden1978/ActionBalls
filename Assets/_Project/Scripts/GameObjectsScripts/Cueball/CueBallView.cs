using PlayerScripts;
using UnityEngine;

namespace GameObjectsScripts
{
    public class CueBallView : MonoBehaviour, IPositionAdapter
    {
        public Vector3 Position { get; set; }
    }
}