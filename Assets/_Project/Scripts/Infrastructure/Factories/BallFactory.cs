using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Data;
using GameObjectsScripts;
using Infrastructure.AssetManagement;
using StaticData;
using UnityEngine;
using Zenject;

namespace Infrastructure.Factories
{
    public class BallFactory
    {
        private readonly DiContainer _diContainer;
        private readonly Dictionary<string, BallStaticData> _cache;
        private readonly IAssetProvider _assetProvider;

        public BallFactory(DiContainer diContainer, IAssetProvider assetProvider)
        {
            _diContainer = diContainer;
            _assetProvider = assetProvider;
            _cache = new Dictionary<string, BallStaticData>();
        }

        public async UniTask<Ball> CreateBall(string ballType)
        {
            BallStaticData ballStaticData;
            if (_cache.TryGetValue(ballType, out BallStaticData value))
                ballStaticData = value;
            else
            {
                ballStaticData = await LoadBallStaticData(ballType);
                
                Debug.Log(_cache.TryAdd(ballType, ballStaticData)
                    ? $"Static data of ball type {ballType} successfully added"
                    : $"Static data of ball type {ballType} is exist");
            }

            return new Ball(new BallData
            {
                BallType = ballStaticData.BallType,
                Hp = ballStaticData.BallState.Hp,
                MaxHp = ballStaticData.BallState.MaxHp
            });
        }

        private async UniTask<BallStaticData> LoadBallStaticData(string ballType)
        {
            string key = $"{AssetPaths.BallsStaticDataPath}/{ballType}.asset";
            BallStaticData asset = await _assetProvider.LoadAsync<BallStaticData>(key);
            _assetProvider.ReleaseAssetsByLabel(key);
            return asset;
        }
    }
}