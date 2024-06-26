using UnityEngine;
using Zenject;

public class LevelProgressController : IInitializable
{
    private readonly LevelProgressView _levelProgressView;
    private readonly IReadOnlyLevelProgress _levelProgress;

    public LevelProgressController(LevelProgressView levelProgressView, IReadOnlyLevelProgress levelProgress)
    {
        _levelProgressView = levelProgressView;
        _levelProgress = levelProgress;
    }

    public void Initialize()
    {
        Debug.Log($"Initialize Level progress controller");
        _levelProgress.UpdateLevelProgress += OnUpdateLevelProgress;
        _levelProgressView.DestroyLevelProgressView += Dispose;
    }

    private void OnUpdateLevelProgress(float value)
    {
        _levelProgressView.UpdateProgress(value);
    }

    private void Dispose()
    {
        _levelProgress.UpdateLevelProgress -= OnUpdateLevelProgress;
        _levelProgressView.DestroyLevelProgressView -= Dispose;
    }
}