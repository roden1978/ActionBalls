using System;
using System.Collections.Generic;

[Serializable]
public class PlayerProgress
{
    public PlayerState PlayerState;
    public InventoryItemsData InventoryItemsData;
    public WalletsData WalletsData;

    public PlayerProgress()
    {
        PlayerState = new PlayerState();
        InventoryItemsData = new InventoryItemsData(new List<InventoryItemData>());
        WalletsData = new WalletsData(new Dictionary<int, long>());
    }
}