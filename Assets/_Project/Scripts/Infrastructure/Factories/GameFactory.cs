using Services.SaveLoad.PlayerProgress;
using Services.StaticData;
using StaticData;
using UnityEngine;
using Zenject;

public class GameFactory : IInitializable
{
    private readonly PrefabsStorage _prefabsStorage;
    private readonly ISaveLoadStorage _saveLoadStorage;
    private IStaticDataService _staticDataService;
    private LevelStaticData _levelStaticData;
    private IPersistentProgress _persistenceProgress;

    private readonly IWalletService _wallet;
    private readonly DiContainer _container;

    public GameFactory(DiContainer container, PrefabsStorage prefabsStorage, ISaveLoadStorage saveLoadStorage,
        IStaticDataService staticDataService, IPersistentProgress persistentProgress, IWalletService wallet)
    {
        _container = container;
        _prefabsStorage = prefabsStorage;
        _saveLoadStorage = saveLoadStorage;
        _staticDataService = staticDataService;
        _persistenceProgress = persistentProgress;
        _wallet = wallet;

        //_levelStaticData = _staticDataService.GetLevelStaticData(AssetPaths.RoomSceneName.ToString());
    }
    public void Initialize()
    {
        _saveLoadStorage.ClearAll();
        
        RegisterWallet();
        var guiHolder = CreateGuiHolder();
        var hudTransform = CreateHud(guiHolder);
        CreateGameOverDialog(guiHolder);
        CreateLevelProgress(hudTransform);
    }
    
    private void RegisterWallet()
    {
        _saveLoadStorage.RegisterInSaveLoadRepositories(_wallet);
    }

    private Transform CreateGuiHolder()
    {
        Debug.Log($"Instantiate GuiHolder start");
        GameObject prefab = _prefabsStorage.Get(typeof(GuiHolder));
        GameObject guiHolder = _container.InstantiatePrefab(prefab);
        _container.Bind<GuiHolder>().FromComponentOn(guiHolder).AsSingle();
        return guiHolder.transform;
    }
    private void CreateGameOverDialog(Transform parent)
    {
        GameObject prefab = _prefabsStorage.Get(typeof(GameOverDialog));
        GameObject gameOverDialog = _container.InstantiatePrefab(prefab, parent);
        _container.BindInterfacesAndSelfTo<GameOverDialog>().FromComponentOn(gameOverDialog).AsSingle();
    }

    private Transform CreateHud(Transform parent)
    {
        Debug.Log($"Instantiate Hud start ");
        GameObject prefab = _prefabsStorage.Get(typeof(Hud));
        GameObject hud = _container.InstantiatePrefab(prefab, parent);
        _container.Bind<Hud>().FromComponentOn(hud).AsSingle();
        _saveLoadStorage.RegisterInSaveLoadRepositories(hud);
        return hud.transform;
    }

    private void CreateLevelProgress(Transform hudTransform)
    {
        GameObject prefab = _prefabsStorage.Get(typeof(LevelProgressView));
        Transform parent = hudTransform.gameObject.GetComponent<Hud>().ProgressViewParent;
        GameObject progressView = _container.InstantiatePrefab(prefab, parent);
        _container.Bind<LevelProgressView>().FromComponentOn(progressView).AsSingle();
        _container.BindInterfacesAndSelfTo<LevelProgressController>().AsSingle();
    }

    private void CreateBucket()
    {
        
    }
}