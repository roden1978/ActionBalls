using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameObjectsScripts
{
    public class BucketView : MonoBehaviour
    {
        public event Action Dispose;
        public void UpdateGrid(IEnumerable<Row> grid)
        {
            
        }

        private void OnDestroy()
        {
            Dispose?.Invoke();
        }
    }
}