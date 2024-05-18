using System;

namespace GameObjectsScripts
{
    public interface IReadOnlyCueBall
    {
        public event Action<float> HpChanged;
        public event Action<float> DamageChanged;
        public float Hp { get; }
        public float Damage { get; }
    }
}