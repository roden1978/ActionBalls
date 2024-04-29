using System;

namespace GameObjectsScripts
{
    public interface IReadOnlyCueball
    {
        public event Action<float> HpChanged;  
        public float HP { get; }
    }
}