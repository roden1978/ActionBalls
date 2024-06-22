using System.Collections.Generic;
using StaticData;

namespace Services.StaticData
{
    public interface IStaticDataService
    {
        EnvironmentObjectStaticData GetEnvironmentObjectStaticData(GameObjectsTypeId typeId);
        void LoadEnvironmentObjectStaticData();
        LevelStaticData GetLevelStaticData(string levelKey);
        void LoadLevelStaticData();
        void LoadSoLevelsSet();
        IEnumerable<string> LevelList { get; }
    }
}