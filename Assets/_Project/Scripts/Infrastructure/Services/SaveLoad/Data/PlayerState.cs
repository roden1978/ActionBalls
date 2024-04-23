using System;
using Data;
using PlayerScripts;

[Serializable]
public class PlayerState
{
    public string SceneName;
    public bool FirstStartGame;
    public Vector3Data Position;
    public QuaternionData Rotation;

    public PlayerState()
    {
        FirstStartGame = true;
        Position = new Vector3Data();
        Rotation = new QuaternionData();
    }
}

/*[Serializable]
public class PlayerDecor
{
    public ItemType Type;
    public Vector3Data StartPosition;

    public PlayerDecor(ItemType type, Vector3Data startPosition)
    {
        Type = type;
        StartPosition = startPosition;
    }
}*/