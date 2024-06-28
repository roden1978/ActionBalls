using GameObjectsScripts;
using Services.SaveLoad.PlayerProgress;
using Services.StaticData;
using StaticData;
using UnityEngine;
using Zenject;

public class MainMenuFactory : IInitializable
{
    private readonly PrefabsStorage _prefabsStorage;
    private readonly ISaveLoadStorage _saveLoadStorage;
    private LevelStaticData _levelStaticData;

    private Transform _guiHolderTransform;
    private readonly IWalletService _wallet;
    private readonly DiContainer _container;
    private readonly IPersistentProgress _persistentProgress;
    private readonly IStaticDataService _staticDataService;
    private readonly LevelsController _levelController;

    public MainMenuFactory(DiContainer container, PrefabsStorage prefabsStorage, ISaveLoadStorage saveLoadStorage,
        IWalletService wallet, IPersistentProgress persistentProgress, LevelsController levelsController)
    {
        _container = container;
        _prefabsStorage = prefabsStorage;
        _saveLoadStorage = saveLoadStorage;
        _wallet = wallet;
        _persistentProgress = persistentProgress;
        _levelController = levelsController;
    }

    public void Initialize()
    {
        Debug.Log("Main menu factory init");
        RegisterWallet();
        var parent = CreateGuiHolder();
        CreateMainMenu(parent);
        PrepareLevel();
    }

    private void RegisterWallet()
    {
        _saveLoadStorage.RegisterInSaveLoadRepositories(_wallet);
    }

    private Transform CreateGuiHolder()
    {
        GameObject prefab = _prefabsStorage.Get(typeof(GuiHolder));
        GameObject guiHolder = _container.InstantiatePrefab(prefab);
        _container.Bind<GuiHolder>().FromComponentOn(guiHolder).AsSingle();
        return guiHolder.transform;
    }


    private void CreateMainMenu(Transform parent)
    {
        GameObject prefab = _prefabsStorage.Get(typeof(MenuDialog));
        GameObject mainMenu = _container.InstantiatePrefab(prefab, parent);
        _container.Bind<MenuDialog>().FromComponentOn(mainMenu).AsSingle();
    }

    private void PrepareLevel()
    {
        _levelController.SetCurrentLevel(_persistentProgress.PlayerProgress.PlayerState.CurrentLevelName == string.Empty
            ? _levelController.GetLevelByIndex(1).LevelKey
            : _persistentProgress.PlayerProgress.PlayerState.CurrentLevelName);
    }
}