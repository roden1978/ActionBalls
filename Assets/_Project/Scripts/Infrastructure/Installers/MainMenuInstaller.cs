using UI;
using Zenject;
public class MainMenuInstaller : MonoInstaller
{
   public override void InstallBindings()
    {
        BindDialogManager();
        BindInventory();
        BindMainMenuFactory();
    }

    private void BindDialogManager()
    {
        Container.Bind<DialogManager>().AsSingle();
    }

    private void BindInventory()
    {
        Container.BindInterfacesAndSelfTo<Inventory>().AsSingle();
    }

    private void BindMainMenuFactory()
    {
        Container.BindInterfacesAndSelfTo<MainMenuFactory>().AsSingle();
    }
    
}