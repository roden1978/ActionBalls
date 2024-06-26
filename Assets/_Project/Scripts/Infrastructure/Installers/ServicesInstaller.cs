using GameObjectsScripts;
using Infrastructure;
using Infrastructure.AssetManagement;
using Infrastructure.Factories;
using Infrastructure.Services;
using Services.Pool;
using Services.SaveLoad.PlayerProgress;
using Services.StaticData;
using Zenject;

public class ServicesInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindAssetProvider();
        BindAssetStorage();
        BindStaticDataService();
        BindPersistentProgress();
        BindSaveLoadStorage();
        BindSaveLoadService();
        BindSceneLoader();
        //BindPoolService();
        BindEventBus();
        BindWallet();
        BindDeviceInfo();
        BindAssetLoader();
        BindLevels();
        BindBallFactory();
    }

    private void BindAssetProvider()
    {
        Container.BindInterfacesAndSelfTo<AssetProvider>().AsSingle();
    }

    private void BindAssetStorage()
    {
        Container.BindInterfacesAndSelfTo<PrefabsStorage>().AsSingle();
    }

    private void BindStaticDataService()
    {
        Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();
    }

    private void BindPersistentProgress()
    {
        Container.BindInterfacesAndSelfTo<PersistentProgress>().AsSingle();
    }

    private void BindSaveLoadStorage()
    {
        Container.BindInterfacesAndSelfTo<SaveLoadStorage>().AsSingle();
    }

    private void BindSaveLoadService()
    {
        Container.BindInterfacesAndSelfTo<SaveLoadService>().AsSingle();
    }

    private void BindSceneLoader()
    {
        Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
    }

    private void BindPoolService()
    {
        Container.BindInterfacesAndSelfTo<PoolService>().AsSingle();
    }

    private void BindEventBus()
    {
        Container.BindInterfacesAndSelfTo<EventBus>().AsSingle();
    }

    private void BindWallet()
    {
        Container.BindInterfacesAndSelfTo<WalletService>().AsSingle();
    }

    private void BindDeviceInfo()
    {
        Container.BindInterfacesAndSelfTo<DeviceInfo>().AsSingle();
    }
    
    private void BindAssetLoader()
    {
        Container.BindInterfacesAndSelfTo<ProgressLoader>().AsSingle();
    }

    private void BindLevels()
    {
        Container.Bind<LevelsController>().AsSingle();
    }

    private void BindBallFactory()
    {
        Container.Bind<BallFactory>().AsSingle();
    }

    private void BindAds()
    {
        
    }

    private void BindAnalytics()
    {
        
    }
}