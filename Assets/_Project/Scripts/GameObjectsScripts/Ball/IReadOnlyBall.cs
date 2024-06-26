using System;
using StaticData;

namespace GameObjectsScripts
{
    public interface IReadOnlyBall
    {
        public event Action<float> HpChange;
        public float Hp { get; }
        public string BallType { get; }
    }
}