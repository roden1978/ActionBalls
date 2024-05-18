using System;
using Common;

namespace GameObjectsScripts
{
    public interface IBall : IDamageable
    {
        public event Action<float> HpChange;
        public float Hp { get; }
    }
}