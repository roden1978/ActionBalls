using System;
using Common;
using Data;
using StaticData;

namespace GameObjectsScripts
{
    public class Ball : IReadOnlyBall, IDamageable
    {
        public event Action<float> HpChange;
        public float Hp
        {
            get => _ballData.Hp;
            private set
            {
                _ballData.Hp = value;
                HpChange?.Invoke(value);
            }
        }

        public string BallType => _ballData.BallType;

        private readonly BallData _ballData;
        public Ball(BallData ballData)
        {
            _ballData = ballData;
        }

        private void DecreaseHp(float value)
        {
            Hp -= value;
            Hp = Hp <= 0 ? 0 : Hp;
            HpChange?.Invoke(Hp);
        }

        public void IncreaseHp(float value)
        {
            float newValue = _ballData.MaxHp - (Hp + value) > _ballData.MaxHp
                    ? _ballData.MaxHp - Hp
                    : value;
            
            Hp += newValue;
            HpChange?.Invoke(Hp);
        }

        public void TakeDamage(float value)
        {
            DecreaseHp(value);
        }

    }
}