using Zenject;

public class PresenterInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindLobbyPresenter();
        
        BindPlayerCounterPresenter();
    }

    private void BindLobbyPresenter()
    {
        Container
            .BindInterfacesAndSelfTo<LobbyPresenter>()
            .AsSingle();
    }
    
    private void BindPlayerCounterPresenter()
    {
        Container
            .BindInterfacesAndSelfTo<PlayerCounterPresenter>()
            .AsSingle();
    }
}