using UnityEngine;
using UnityEngine.EventSystems;

public class LoseWindow : GameOverDialogWindow
{
    protected override void OnClick(PointerEventData data)
    {
#if UNITY_EDITOR
        Debug.Log("Open lose window");
#endif
    }
}