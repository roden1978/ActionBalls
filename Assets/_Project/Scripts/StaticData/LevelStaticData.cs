using System.Collections.Generic;
using TriInspector;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "New LevelData", menuName = "StaticData/LevelData")]
    public class LevelStaticData : ScriptableObject
    {
        public string LevelKey;
        public List<RowStaticData> Rows;
        [Range(5, 10)] public int Difficult = 5; // from 5 to 10 cells in row
        public int TargetScores = 100;


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