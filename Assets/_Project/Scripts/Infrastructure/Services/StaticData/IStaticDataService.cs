using Cysharp.Threading.Tasks;
using StaticData;

namespace Services.StaticData
{
    public interface IStaticDataService
    {
        UniTask<SoLevelsSet> LoadSoLevelsSet();
    }
}