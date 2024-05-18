using System;
using StaticData;

namespace Data
{
    [Serializable]
    public class BallData
    {
        public BallStaticData BallStaticData;
        public float Hp;
        public float MaxHp;

        public BallData(BallStaticData ballStaticData)
        {
            BallStaticData = ballStaticData;
        }
    }
}