using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Infrastructure.AssetManagement;
using StaticData;

namespace Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IAssetProvider _assetProvider;
        
        public StaticDataService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public async UniTask<SoLevelsSet> LoadSoLevelsSet()
        {
            UniTask<SoLevelsSet> task = _assetProvider.LoadAsync<SoLevelsSet>(AssetPaths.SoLevelsSetPath);
            if (task.Status == UniTaskStatus.Pending)
                await UniTask.Yield();
            _assetProvider.ReleaseAssetsByLabel(AssetPaths.LevelsPath);
            return await task;
        }
        
    }
}