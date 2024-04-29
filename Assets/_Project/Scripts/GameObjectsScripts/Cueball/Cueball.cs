using System;

namespace GameObjectsScripts
{
    public class Cueball : IReadOnlyCueball
    {
        public event Action<float> HpChanged;
        private CueballData _cueballData;

        public float HP
        {
            get => _cueballData.HP;

            private set
            {
                _cueballData.HP = value; 
                HpChanged?.Invoke(value);
            }
        }
        public Cueball(CueballData cueballData)
        {
            _cueballData = cueballData;
        }

    }
}