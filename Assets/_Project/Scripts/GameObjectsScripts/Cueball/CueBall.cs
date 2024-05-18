using System;
using Common;

namespace GameObjectsScripts
{
    public class CueBall : IReadOnlyCueBall, IDamageable
    {
        public event Action<float> HpChanged;
        public event Action<float> DamageChanged; 

        private readonly CueBallData _cueBallData;

        public float Hp
        {
            get => _cueBallData.Hp;

            private set
            {
                _cueBallData.Hp = value; 
                HpChanged?.Invoke(value);
            }
        }

        public float Damage
        {
            get => _cueBallData.Damage;
            private set
            {
                _cueBallData.Damage = value; 
                DamageChanged?.Invoke(value);
            }
        }
        public CueBall(CueBallData cueBallData)
        {
            _cueBallData = cueBallData;
        }

        public void TakeDamage(float value)
        {
            Hp -= value;
        }
    }
}