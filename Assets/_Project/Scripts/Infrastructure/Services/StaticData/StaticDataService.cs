using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Infrastructure.AssetManagement;
using StaticData;
using Zenject;

namespace Services.StaticData
{
    public class StaticDataService : IStaticDataService, IInitializable
    {
        public IEnumerable<string> LevelList { get; private set; }

        private readonly IAssetProvider _assetProvider;
        
        public StaticDataService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        private async UniTask<SoLevelsSet> LoadSoLevelsSet()
        {
            UniTask<SoLevelsSet> task = _assetProvider.LoadAsync<SoLevelsSet>(AssetPaths.SoLevelsSetPath);
            if (task.Status == UniTaskStatus.Pending)
                await UniTask.Yield();
            return await task;
        }

        public async void Initialize()
        {
            SoLevelsSet result = await LoadSoLevelsSet();
            //LevelList = result.LevelsSet;
        }
    }
}