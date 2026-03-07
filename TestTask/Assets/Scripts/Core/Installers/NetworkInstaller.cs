using UnityEngine;
using Zenject;

public class NetworkInstaller : MonoInstaller
{
    [SerializeField] private PlayerNetworkSpawner _playerNetworkSpawner;
    
    public override void InstallBindings()
    {
        BindSessionController();

        BindPlayerNetworkSpawner();
    }

    private void BindPlayerNetworkSpawner()
    {
        Container
            .BindInterfacesAndSelfTo<PlayerNetworkSpawner>()
            .FromInstance(_playerNetworkSpawner)
            .AsSingle();
    }

    private void BindSessionController()
    {
        Container
            .BindInterfacesAndSelfTo<SessionController>()
            .AsSingle();
    }
}