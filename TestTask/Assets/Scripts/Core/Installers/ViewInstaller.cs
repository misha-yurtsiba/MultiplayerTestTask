using UnityEngine;
using Zenject;

public class ViewInstaller : MonoInstaller
{
    [SerializeField] private CreateLobbyView _createLobbyView;
    public override void InstallBindings()
    {
        BindCreateLobbyView();
    }

    private void BindCreateLobbyView()
    {
        Container
            .BindInterfacesAndSelfTo<CreateLobbyView>()
            .FromInstance(_createLobbyView)
            .AsSingle();
    }
}