using System;
using System.Collections.Generic;
using Common;
using Services.StaticData;
using StaticData;
using UnityEngine;
using Zenject;

namespace GameObjectsScripts
{
    public class LevelsController : IInitializable
    {
        public LevelData CurrentLevelData { get; private set; }
        private readonly Repository<LevelData> _levels = new();
        private readonly IStaticDataService _staticDataService;

        public LevelsController(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void Initialize()
        {
            LoadLevels();
        }

        public LevelData GetLevelByIndex(int index)
        {
            return _levels.Get(index);
        }

        public void SetCurrentLevel(string levelKey)
        {
            CurrentLevelData = _levels.Get(Int32.Parse(levelKey.Split("|")[1]));
        }

        public void SetCurrentLevelById(int id)
        {
            CurrentLevelData = _levels.Get(id);
        }

        private async void LoadLevels()
        {
            SoLevelsSet asset = await _staticDataService.LoadSoLevelsSet();
            Map(asset.LevelsSet);

            Debug.Log($"Name: {asset.name}");
        }

        private void Map(IEnumerable<LevelData> data)
        {
            foreach (var level in data)
            {
                LevelData levelData = new (level.LevelKey, level.Capacity, level.RowsData, level.TargetScores,
                    level.Circular, level.UniqueTypes);
                levelData.AddIndex(int.Parse(level.LevelKey.Split("|")[1]));
                _levels.Add(levelData);
            }
        }
        
    }
}