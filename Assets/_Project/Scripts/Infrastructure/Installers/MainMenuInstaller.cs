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
    private LevelStaticData _levelStaticData;

    private Transform _guiHolderTransform;
    private IWalletService _wallet;

    [Inject]
    public void Construct(PrefabsStorage prefabsStorage, ISaveLoadStorage saveLoadStorage,
        IStaticDataService staticDataService, IPersistentProgress persistentProgress, IWalletService wallet)
    {
        _prefabsStorage = prefabsStorage;
        _saveLoadStorage = saveLoadStorage;
        _wallet = wallet;
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
        //Debug.Log($"Instantiate GuiHolder start");
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
        //Debug.Log($"Instantiate Main menu ");
        GameObject prefab = _prefabsStorage.Get(typeof(MenuDialog));
        GameObject mainMenu = Container.InstantiatePrefab(prefab, _guiHolderTransform);
        Container.Bind<MenuDialog>().FromComponentOn(mainMenu).AsSingle();
    }
    
    private void BindInventory()
    {
        Container.BindInterfacesAndSelfTo<Inventory>().AsSingle();
    }
}