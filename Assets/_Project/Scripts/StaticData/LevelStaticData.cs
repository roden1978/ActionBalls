﻿using System.Collections.Generic;
using TriInspector;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "New LevelData", menuName = "StaticData/LevelData")]
    public class LevelStaticData : ScriptableObject
    {
        private const int ScreenWidth = 1440;
        private const int ScreenHeight = 2560;
        private const int HudZoneHeight = 200;
        public string LevelKey;
        public List<RowStaticData> Rows;
        [Range(5, 10)] public int Capacity = 5; // from 5 to 10 cells in row
        public int TargetScores = 100;
        public bool Ramdomize = true;
        public bool Circular = true;
        
        


        /*public EnvironmentObjectSpawnData GetEnvironmentObjectSpawnDataByTypeId(GameObjectsTypeId typeId)
        {
            return EnvironmentObjectsSpawnData.Find(x => x.GameObjectsTypeId == typeId);
        }

        public StuffSpawnData GetStuffSpawnDataBySpecies(StuffSpecies species)
        {
            return StuffSpawnData.Find(x => x.StuffSpecies == species);
        }*/
    }
}