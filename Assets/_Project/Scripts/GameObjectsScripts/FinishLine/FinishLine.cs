using PlayerScripts;
using UnityEngine;

namespace GameObjectsScripts
{
    public class FinishLine : MonoBehaviour, IPositionAdapter
    {
        public Vector3 Position { get; set; }
    }
}