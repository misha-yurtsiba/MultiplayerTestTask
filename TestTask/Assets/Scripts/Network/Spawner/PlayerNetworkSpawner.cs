using System.Linq;
using Fusion;
using UnityEngine;
using Zenject;

public class PlayerNetworkSpawner : NetworkBehaviour, IPlayerNetworkSpawner, IPlayerJoined, IPlayerLeft 
{
    private AssetProvider _assetProvider;
    private PlayerRegistry _playerRegistry;
    private IPlayerFactory _playerFactory;
    private INetworkPlayerCounter _networkPlayerCounter;

    [Inject]
    private void Construct(AssetProvider assetProvider, INetworkPlayerCounter networkPlayerCounter)
    {
        _assetProvider = assetProvider;
        _networkPlayerCounter = networkPlayerCounter;
    }

    public override void Spawned()
    {
        _playerRegistry = new PlayerRegistry();
        _playerFactory = new PlayerFactory(Runner, _assetProvider);
        _networkPlayerCounter.SetPlayerCount(Runner.ActivePlayers.Count());
    }

    public void PlayerJoined(PlayerRef player)
    {
        if (!HasStateAuthority) return;
        
        Debug.Log("PlayerJoined" + $"{player.PlayerId}");

        Vector3 spawnPos = new Vector3(Random.Range(-5f, 5f), 1, Random.Range(-5f, 5f));
        NetworkObject playerObj = _playerFactory.Create(player, spawnPos);
        _playerRegistry.Add(player, playerObj);
        _networkPlayerCounter.SetPlayerCount(Runner.ActivePlayers.Count());

    }
    

    public void PlayerLeft(PlayerRef player)
    {
        if (!HasStateAuthority) return;

        if (_playerRegistry.TryGet(player, out var obj))
        {
            Runner.Despawn(obj);
            _playerRegistry.Remove(player);
        }
        
        _networkPlayerCounter.SetPlayerCount(Runner.ActivePlayers.Count());
    }
}