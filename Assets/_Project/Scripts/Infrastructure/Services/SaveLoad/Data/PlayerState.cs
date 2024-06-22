using System;
using Data;
using PlayerScripts;

[Serializable]
public class PlayerState
{
    public string CurrentLevelName;
    public bool FirstStartGame;
    public Vector3Data Position;
    public QuaternionData Rotation;

    public PlayerState()
    {
        CurrentLevelName = string.Empty;
        FirstStartGame = true;
        Position = new Vector3Data();
        Rotation = new QuaternionData();
    }
}
