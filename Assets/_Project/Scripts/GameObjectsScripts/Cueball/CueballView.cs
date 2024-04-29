using PlayerScripts;
using UnityEngine;

namespace GameObjectsScripts
{
    public class CueballView : MonoBehaviour, IPositionAdapter
    {
        public Vector3 Position { get; set; }
    }
}