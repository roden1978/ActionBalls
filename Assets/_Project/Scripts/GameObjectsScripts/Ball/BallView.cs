using UnityEngine;

namespace GameObjectsScripts
{
    public class BallView : MonoBehaviour
    {
        public void UpdateHpView(float value)
        {
            Debug.Log($"Ball Hp changed {value}");
        }
    }
}