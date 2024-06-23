using System.Collections.Generic;

namespace Services.StaticData
{
    public interface IStaticDataService
    {
        IEnumerable<string> LevelList { get; }
    }
}