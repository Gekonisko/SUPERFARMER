using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GameService>().AsSingle();
        Container.BindInterfacesAndSelfTo<BankService>().AsSingle();
        Container.BindInterfacesAndSelfTo<DiceRollerService>().AsSingle();
        Container.BindInterfacesAndSelfTo<FarmService>().AsSingle();
        Container.BindInterfacesAndSelfTo<ExchangeService>().AsSingle();
    }
}
