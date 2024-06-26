using System.Collections.Generic;
using System.Linq;
using Data;
using Infrastructure.AssetManagement;
using StaticData;
using UnityEngine;
using Zenject;

namespace GameObjectsScripts
{
    public class LevelsController : IInitializable
    {
        public LevelData CurrentLevelData { get; private set; }
        private List<LevelData> _levels;
        private readonly IAssetProvider _assetProvider;

        public LevelsController(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void Initialize()
        {
            
        }

        public async void LoadLevel(string levelKey)
        {
            string key = $"{AssetPaths.LevelsPath}/{levelKey}.asset";
            LevelStaticData asset = await _assetProvider.LoadAsync<LevelStaticData>(key);
            //CurrentLevelData = Map(asset);
            _assetProvider.ReleaseAssetsByLabel(key);
            Debug.Log($"Name: {asset.name}");
        }

        /*private LevelData Map(LevelStaticData data)
        {
            return new LevelData
            {
                Capacity = data.Capacity,
                RowsData = data.Rows.Select(x => x.Balls.Select(z => z == null ? BallType.None : z.BallType)),
                TargetScores = data.TargetScores,
                Circular = data.Circular
            };
        }*/
    }
}