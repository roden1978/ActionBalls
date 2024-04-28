using System;
using Zenject;

public class LevelProgress : ISavedProgress, IInitializable, IReadOnlyLevelProgress
{
    public event Action<float> UpdateLevelProgress;
    public float Progress => _progress;
    private float _progress;
    private float _target;
    public LevelProgress(float target)
    {
        _target = target;
    }
    public void Initialize()
    {
        
    }
    public void LoadProgress(PlayerProgress playerProgress)
    {
       
    }

    public void SaveProgress(PlayerProgress playerProgress)
    {
        
    }

    public void UpdateProgress(float value)
    {
        _progress += value;
        UpdateLevelProgress?.Invoke(_progress / _target);
    }
}