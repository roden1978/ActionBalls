using System;
using Zenject;

public class LevelProgress : IInitializable, IReadOnlyLevelProgress
{
    public event Action<float> UpdateLevelProgress;
    public float Progress => _progress;
    private float _progress;
    private float _target;
   
    public void Initialize()
    {
        //Initialize target
    }
    public void UpdateProgress(float value)
    {
        _progress += value;
        UpdateLevelProgress?.Invoke(_progress / _target);
    }
}