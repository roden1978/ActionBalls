using Services.SaveLoad.PlayerProgress;
using Services.StaticData;
using StaticData;
using UI;
using UnityEngine;
using Zenject;

public class MainMenuInstaller : MonoInstaller
{
    private PrefabsStorage _prefabsStorage;
    private ISaveLoadStorage _saveLoadStorage;
    private IStaticDataService _staticDataService;
    private LevelStaticData _levelStaticData;
    private IPersistentProgress _persistenceProgress;

    private Transform _guiHolderTransform;
    private Transform _hudTransform;
    private IWalletService _wallet;

    [Inject]
    public void Construct(PrefabsStorage prefabsStorage, ISaveLoadStorage saveLoadStorage,
        IStaticDataService staticDataService, IPersistentProgress persistentProgress, IWalletService wallet)
    {
        _prefabsStorage = prefabsStorage;
        _saveLoadStorage = saveLoadStorage;
        _staticDataService = staticDataService;
        _persistenceProgress = persistentProgress;
        _wallet = wallet;

        //_levelStaticData = _staticDataService.GetLevelStaticData(AssetPaths.RoomSceneName.ToString());
        //_saveLoadStorage.ClearAll();
    }


    public override void InstallBindings()
    {
        RegisterWallet();
        BindGuiHolder();
        BindDialogManager();
        BindInventory();
        BindMainMenu();
    }
    
    private void RegisterWallet()
    {
        _saveLoadStorage.RegisterInSaveLoadRepositories(_wallet);
    }

    private void BindGuiHolder()
    {
        Debug.Log($"Instantiate GuiHolder start");
        GameObject prefab = _prefabsStorage.Get(typeof(GuiHolder));
        GameObject guiHolder = Container.InstantiatePrefab(prefab);
        _guiHolderTransform = guiHolder.transform;

        Container.Bind<GuiHolder>().FromComponentOn(guiHolder).AsSingle();
    }
    
    private void BindDialogManager()
    {
        Container.Bind<DialogManager>().AsSingle();
    }

    private void BindMainMenu()
    {
        Debug.Log($"Instantiate Main menu ");
        GameObject prefab = _prefabsStorage.Get(typeof(MenuDialog));
        GameObject mainMenu = Container.InstantiatePrefab(prefab, _guiHolderTransform);
        _hudTransform = mainMenu.transform;
        Container.Bind<MenuDialog>().FromComponentOn(mainMenu).AsSingle();
    }
    
    private void BindInventory()
    {
        Container.BindInterfacesAndSelfTo<Inventory>().AsSingle();
    }

    private void BindHud()
    {
        Debug.Log($"Instantiate Hud start ");
        GameObject prefab = _prefabsStorage.Get(typeof(Hud));
        GameObject hud = Container.InstantiatePrefab(prefab, _guiHolderTransform);
        _hudTransform = hud.transform;
        Container.Bind<Hud>().FromComponentOn(hud).AsSingle();
        _saveLoadStorage.RegisterInSaveLoadRepositories(hud);
    }
}