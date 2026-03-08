using UnityEngine;
using Zenject;

public class NetworkInstaller : MonoInstaller
{
    [SerializeField] private PlayerNetworkSpawner _playerNetworkSpawner;
    [SerializeField] private NetworkPlayerCounter _networkPlayerCounter;
    
    public override void InstallBindings()
    {
        BindSessionController();

        BindNetworkPlayerCounter();

        BindPlayerNetworkSpawner();
    }

    private void BindPlayerNetworkSpawner()
    {
        Container
            .BindInterfacesAndSelfTo<PlayerNetworkSpawner>()
            .FromInstance(_playerNetworkSpawner)
            .AsSingle();
    }

    private void BindNetworkPlayerCounter()
    {
        Container
            .BindInterfacesAndSelfTo<NetworkPlayerCounter>()
            .FromInstance(_networkPlayerCounter)
            .AsSingle();
    }

    private void BindSessionController()
    {
        Container
            .BindInterfacesAndSelfTo<SessionController>()
            .AsSingle();
    }
}