using System;
namespace GameObjectsScripts
{
    public interface IReadOnlyBall
    {
        public event Action<float> HpChange;
        public float Hp { get; }
    }
}