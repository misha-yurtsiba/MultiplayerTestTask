using Zenject;

public class PresenterInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindLobbyPresenter();
    }

    private void BindLobbyPresenter()
    {
        Container
            .BindInterfacesAndSelfTo<LobbyPresenter>()
            .AsSingle();
    }
}