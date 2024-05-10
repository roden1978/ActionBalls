using System;

namespace GameObjectsScripts
{
    public class CueBall : IReadOnlyCueBall
    {
        public event Action<float> HpChanged;
        private CueBallData _cueBallData;

        public float HP
        {
            get => _cueBallData.HP;

            private set
            {
                _cueBallData.HP = value; 
                HpChanged?.Invoke(value);
            }
        }
        public CueBall(CueBallData cueBallData)
        {
            _cueBallData = cueBallData;
        }

    }
}