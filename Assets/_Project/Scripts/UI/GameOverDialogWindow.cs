using UnityEngine;
using UnityEngine.EventSystems;

public abstract class GameOverDialogWindow : MonoBehaviour
{
    [SerializeField] private PointerListener _continue;

    private void OnEnable()
    {
        _continue.Click += OnClick;
    }

    private void OnDisable()
    {
        _continue.Click -= OnClick;;
    }

    protected abstract void OnClick(PointerEventData data);
}