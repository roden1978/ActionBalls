using System;
using StaticData;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class BallData
    {
        public int Id;
        public BallType BallType;
        public float Hp;
        public Sprite Icon;
    }
}