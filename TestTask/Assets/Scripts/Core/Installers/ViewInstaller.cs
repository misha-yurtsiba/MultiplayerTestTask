using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

public class ViewInstaller : MonoInstaller
{
    [SerializeField] private CreateLobbyView _createLobbyView;
    [SerializeField] private PlayerCountView _playerCountView;
    public override void InstallBindings()
    {
        BindCreateLobbyView();

        BindPlayerCountView();
    }

    private void BindCreateLobbyView()
    {
        Container
            .BindInterfacesAndSelfTo<CreateLobbyView>()
            .FromInstance(_createLobbyView)
            .AsSingle();
    }

    private void BindPlayerCountView()
    {
        Container
            .BindInterfacesAndSelfTo<PlayerCountView>()
            .FromInstance(_playerCountView)
            .AsSingle();
    }
}