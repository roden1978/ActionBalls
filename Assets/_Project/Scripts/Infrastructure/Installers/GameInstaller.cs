using GameObjectsScripts;
using UI;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInventory();
        BindDialogManager();
        BindPlayer();
        BindLevelProgress();
        BindBucket();
        BindGameFactory();
        //BindGameOverDialog();
        //BindLevelProgress();

        //BindTimersPrincipal();
        //BindInputNameDialog();
        //BindEgg();
        /*BindMealDrawer();
        BindMealInventoryDialog();
        BindClothsDrawer();
        BindClothsInventoryDialog();
        BindToysDrawer();
        BindToysInventoryDialog();
        BindShop();
        BindPoop();
        BindTray();
        BindTrayView();
        BindCarpet();
        BindMenuDialog();*/
    }

    private void BindInventory()
    {
        Container.BindInterfacesAndSelfTo<Inventory>().AsSingle();
    }

    private void BindDialogManager()
    {
        Container.Bind<DialogManager>().AsSingle();
    }

    private void BindLevelProgress()
    {
        Container.BindInterfacesAndSelfTo<LevelProgress>().AsSingle();
    }

    private void BindBucket()
    {
        Container.BindInterfacesAndSelfTo<Bucket>().AsSingle();
    }

    private void BindGameFactory()
    {
        Container.BindInterfacesAndSelfTo<GameFactory>().AsSingle();
    }

    /*private void BindPoop()
    {
        EnvironmentObjectSpawnData poopData =
            _levelStaticData.GetEnvironmentObjectSpawnDataByTypeId(GameObjectsTypeId.Poop);
        GameObject prefab = _prefabsStorage.Get(typeof(Poop));
        IPositionAdapter positionAdapter = prefab.GetComponentInChildren<IPositionAdapter>(true);
        positionAdapter.Position = poopData.Position;
        GameObject poop = Container.InstantiatePrefab(prefab);
        poop.gameObject.SetActive(false);
        poop.gameObject.name = nameof(Poop);
        Container.BindInterfacesAndSelfTo<Poop>().FromComponentOn(poop).AsSingle();
    }*/

    /*private void BindShop()
    {
        GameObject shopDialog = _prefabsStorage.Get(typeof(ShopDialog));
        Container.InstantiatePrefab(shopDialog, _guiHolderTransform);
    }*/

    /*private void BindInputNameDialog()
    {
        GameObject prefab = _prefabsStorage.Get(typeof(InputNameDialog));

        if (false == _persistenceProgress.PlayerProgress.PlayerState.FirstStartGame)
        {
            _prefabsStorage.Unregister(prefab);
            return;
        }

        GameObject inventoryNameDialog = Container.InstantiatePrefab(prefab, _guiHolderTransform);
        Container.Bind<InputNameDialog>().FromComponentOn(inventoryNameDialog).AsSingle();
        _saveLoadStorage.RegisterInSaveLoadRepositories(inventoryNameDialog);
    }*/


    /*private void BindMealInventoryDialog()
    {
        GameObject prefab = _prefabsStorage.Get(typeof(MealInventoryDialog));
        GameObject mealInventoryDialog = Container.InstantiatePrefab(prefab, _guiHolderTransform);
        Container.BindInterfacesAndSelfTo<MealInventoryDialog>().FromComponentOn(mealInventoryDialog).AsSingle();
    }

    private void BindClothsInventoryDialog()
    {
        GameObject prefab = _prefabsStorage.Get(typeof(ClothsInventoryDialog));
        GameObject clothsInventoryDialog = Container.InstantiatePrefab(prefab, _guiHolderTransform);
        Container.BindInterfacesAndSelfTo<ClothsInventoryDialog>().FromComponentOn(clothsInventoryDialog).AsSingle();
    }
    private void BindToysInventoryDialog()
    {
        GameObject prefab = _prefabsStorage.Get(typeof(ToysInventoryDialog));
        GameObject toysInventoryDialog = Container.InstantiatePrefab(prefab, _guiHolderTransform);
        Container.BindInterfacesAndSelfTo<ToysInventoryDialog>().FromComponentOn(toysInventoryDialog).AsSingle();
    }*/

    /*private void BindMenuDialog()
    {
        GameObject prefab = _prefabsStorage.Get(typeof(MenuDialog));
        GameObject menuDialog = Container.InstantiatePrefab(prefab, _guiHolderTransform);
        Container.BindInterfacesAndSelfTo<MenuDialog>().FromComponentOn(menuDialog).AsSingle();
    }*/
    
    /*private void BindTimersPrincipal()
    {
        Debug.Log($"Instantiate TimersPrincipal start ");
        GameObject prefab = _prefabsStorage.Get(typeof(TimersPrincipal));
        GameObject timersPrincipal = Container.InstantiatePrefab(prefab, _hudTransform);
        Container.BindInterfacesAndSelfTo<TimersPrincipal>().FromComponentOn(timersPrincipal).AsSingle();
        _saveLoadStorage.RegisterInSaveLoadRepositories(timersPrincipal);
    }

    private void BindMealDrawer()
    {
        EnvironmentObjectSpawnData plateData =
            _levelStaticData.GetEnvironmentObjectSpawnDataByTypeId(GameObjectsTypeId.MealDrawer);
        GameObject prefab = _prefabsStorage.Get(typeof(MealDrawer));
        IPositionAdapter positionAdapter = prefab.GetComponentInChildren<IPositionAdapter>(true);
        positionAdapter.Position = plateData.Position;
        GameObject mealDrawer = Container.InstantiatePrefab(prefab);
        mealDrawer.gameObject.name = nameof(MealDrawer);
        Container.BindInterfacesAndSelfTo<MealDrawer>().FromComponentOn(mealDrawer).AsSingle();
        _saveLoadStorage.RegisterInSaveLoadRepositories(mealDrawer);
    }

    private void BindClothsDrawer()
    {
        EnvironmentObjectSpawnData clothsDrawerData =
            _levelStaticData.GetEnvironmentObjectSpawnDataByTypeId(GameObjectsTypeId.ClothsDrawer);
        GameObject prefab = _prefabsStorage.Get(typeof(ClothsDrawer));
        IPositionAdapter positionAdapter = prefab.GetComponentInChildren<IPositionAdapter>(true);
        positionAdapter.Position = clothsDrawerData.Position;
        GameObject clothsDrawer = Container.InstantiatePrefab(prefab);
        clothsDrawer.gameObject.name = nameof(ClothsDrawer);
        Container.BindInterfacesAndSelfTo<ClothsDrawer>().FromComponentOn(clothsDrawer).AsSingle();
        _saveLoadStorage.RegisterInSaveLoadRepositories(clothsDrawer);
    }
    
    private void BindToysDrawer()
    {
        EnvironmentObjectSpawnData toysDrawerData =
            _levelStaticData.GetEnvironmentObjectSpawnDataByTypeId(GameObjectsTypeId.ToysDrawer);
        GameObject prefab = _prefabsStorage.Get(typeof(ToysDrawer));
        IPositionAdapter positionAdapter = prefab.GetComponentInChildren<IPositionAdapter>(true);
        positionAdapter.Position = toysDrawerData.Position;
        GameObject toysDrawer = Container.InstantiatePrefab(prefab);
        toysDrawer.gameObject.name = nameof(ToysDrawer);
        Container.BindInterfacesAndSelfTo<ToysDrawer>().FromComponentOn(toysDrawer).AsSingle();
        _saveLoadStorage.RegisterInSaveLoadRepositories(toysDrawer);
    }

    private void BindEgg()
    {
        GameObject eggPrefab = _prefabsStorage.Get(typeof(Egg));

        if (false == _persistenceProgress.PlayerProgress.PlayerState.FirstStartGame)
        {
            _prefabsStorage.Unregister(eggPrefab);
            return;
        }

        EnvironmentObjectSpawnData eggSpawnData =
            _levelStaticData.GetEnvironmentObjectSpawnDataByTypeId(GameObjectsTypeId.Egg);
        GameObject egg = Container.InstantiatePrefab(eggPrefab, eggSpawnData.Position, Quaternion.identity, null);
        _saveLoadStorage.RegisterInSaveLoadRepositories(egg);
    }*/

    private void BindPlayer()
    {
        /*GameObject prefab = _prefabsStorage.Get(typeof(Player));
        EnvironmentObjectSpawnData playerSpawnData =
            _levelStaticData.GetEnvironmentObjectSpawnDataByTypeId(GameObjectsTypeId.Player);
        Vector3 position = playerSpawnData.Position;
        Quaternion rotation = playerSpawnData.Rotation;
        
        GameObject player = Container.InstantiatePrefab(prefab, position, rotation, null);
        player.name = nameof(Player);
        Container.BindInterfacesAndSelfTo<Player>().FromComponentOn(player).AsSingle();
        _saveLoadStorage.RegisterInSaveLoadRepositories(player);*/
    }

    /*private void BindTray()
    {
        Container.BindInterfacesAndSelfTo<Tray>().AsSingle();
        Tray tray = Container.Resolve<Tray>();
        _saveLoadStorage.RegisterInSaveLoadRepositories(tray);
    }

    private void BindTrayView()
    {
        EnvironmentObjectSpawnData trayData =
            _levelStaticData.GetEnvironmentObjectSpawnDataByTypeId(GameObjectsTypeId.TrayView);
        GameObject prefab = _prefabsStorage.Get(typeof(TrayView));
        GameObject tray = Container.InstantiatePrefab(prefab, trayData.Position, Quaternion.identity, null);
        Container.BindInterfacesAndSelfTo<TrayView>().FromComponentOn(tray).AsSingle();
    }

    private void BindCarpet()
    {
        EnvironmentObjectSpawnData carpetData =
            _levelStaticData.GetEnvironmentObjectSpawnDataByTypeId(GameObjectsTypeId.Carpet);
        GameObject prefab = _prefabsStorage.Get(typeof(Carpet));
        IPositionAdapter positionAdapter = prefab.GetComponentInChildren<IPositionAdapter>(true);
        positionAdapter.Position = carpetData.Position;
        GameObject carpet = Container.InstantiatePrefab(prefab);
        carpet.gameObject.name = nameof(Carpet);
        Container.BindInterfacesAndSelfTo<Carpet>().FromComponentOn(carpet).AsSingle();
        //_saveLoadStorage.RegisterInSaveLoadRepositories(carpet);
    }*/
}