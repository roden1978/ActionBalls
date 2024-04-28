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
        _levelProgress.UpdateLevelProgress += OnUpdateLevelProgress;
    }

    private void OnUpdateLevelProgress(float value)
    {
        _levelProgressView.UpdateProgress(value);
    }

    public void Dispose()
    {
        _levelProgress.UpdateLevelProgress -= OnUpdateLevelProgress;
    }
}