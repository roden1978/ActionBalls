using Services.SaveLoad.PlayerProgress;
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

    public MainMenuFactory(DiContainer container, PrefabsStorage prefabsStorage, ISaveLoadStorage saveLoadStorage,
        IWalletService wallet)
    {
        _container = container;
        _prefabsStorage = prefabsStorage;
        _saveLoadStorage = saveLoadStorage;
        _wallet = wallet;
    }

    public void Initialize()
    {
        Debug.Log("Main menu factory init");
        RegisterWallet();
        var parent = CreateGuiHolder();
        CreateMainMenu(parent);
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
}