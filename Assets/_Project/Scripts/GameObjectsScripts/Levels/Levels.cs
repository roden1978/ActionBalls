using System.Linq;
using Infrastructure.AssetManagement;
using StaticData;
using UnityEngine;
using Zenject;

namespace GameObjectsScripts.Levels
{
    public class Levels : IInitializable
    {
        public LevelData CurrentLevelData { get; private set; }
        private readonly IAssetProvider _assetProvider;

        public Levels(IAssetProvider assetProvider)
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
            CurrentLevelData = Map(asset);
            _assetProvider.ReleaseAssetsByLabel(key);
            Debug.Log($"Name: {asset.name}");
        }

        private LevelData Map(LevelStaticData data)
        {
            return new LevelData
            {
                Capacity = data.Capacity,
                RowsData = data.Rows.Select(x => x.Balls.Select(z => z.BallType)),
                TargetScores = data.TargetScores,
                Circular = data.Circular
            };
        }
    }
}