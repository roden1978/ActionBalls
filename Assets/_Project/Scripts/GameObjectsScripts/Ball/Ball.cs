using System;
using Data;

namespace GameObjectsScripts
{
    public class ReadOnlyBall : IReadOnlyBall
    {
        public event Action<float> HpChange;
        public float Hp => _ballData.Hp;
        
        private readonly BallData _ballData;
        public ReadOnlyBall(BallData ballData)
        {
            _ballData = ballData;
        }

        private void DecreaseHp(float value)
        {
            _ballData.Hp -= value;
            _ballData.Hp = _ballData.Hp <= 0 ? 0 : _ballData.Hp;
            HpChange?.Invoke(_ballData.Hp);
        }

        public void IncreaseHp(float value)
        {
            float newValue = _ballData.MaxHp - (_ballData.Hp + value) > _ballData.MaxHp
                    ? _ballData.MaxHp - _ballData.Hp
                    : value;
            
            _ballData.Hp += newValue;
            HpChange?.Invoke(_ballData.Hp);
        }

        public void TakeDamage(float value)
        {
            DecreaseHp(value);
        }

    }
}