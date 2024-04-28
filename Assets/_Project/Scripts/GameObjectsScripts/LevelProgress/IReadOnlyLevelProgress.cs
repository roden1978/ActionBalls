using System;

public interface IReadOnlyLevelProgress
{
    public event Action<float> UpdateLevelProgress;
    public float Progress { get; }
}