using System;
using PlayerScripts;
using UnityEngine;

namespace GameObjectsScripts
{
    public class CueBallView : MonoBehaviour, IPositionAdapter
    {
        public event Action DestroyCueBall;
        public Vector3 Position { get; set; }

        public void UpdateHpView(float value)
        {
            Debug.Log($"Update Hp view {value}");
        }

        private void OnDestroy()
        {
            DestroyCueBall?.Invoke();
        }
    }
}