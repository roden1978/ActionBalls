using Infrastructure;
using Infrastructure.AssetManagement;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class GameOverDialog : Dialog
{
    [SerializeField] private PointerListener _mainMenu;
    private ISceneLoader _sceneLoader;

    [Inject]
    public void Construct(ISceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }
    private void OnEnable()
    {
        _mainMenu.Click += OnMainMenu;
    }

    private void OnDisable()
    {
        _mainMenu.Click -= OnMainMenu;
    }

   
    private void OnMainMenu(PointerEventData data)
    {
        Hide();
        _sceneLoader.LoadScene(AssetPaths.MainMenuSceneName);
    }

    public void OpenWindow(WindowsType window)
    {
        Base.GetComponent<GameOverView>().OpenWindow(window);
    }
}