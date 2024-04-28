using UnityEngine;
using UnityEngine.EventSystems;

public class WinWindow : GameOverDialogWindow
{
    protected override void OnClick(PointerEventData data)
    {
#if UNITY_EDITOR
        Debug.Log("Open win window");
#endif
    }
}