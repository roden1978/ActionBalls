using System;

namespace GameObjectsScripts
{
    public interface IReadOnlyCueBall
    {
        public event Action<float> HpChanged;  
        public float HP { get; }
    }
}