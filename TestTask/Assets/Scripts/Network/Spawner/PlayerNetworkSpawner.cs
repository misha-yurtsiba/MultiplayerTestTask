using Fusion;
using UnityEngine;
using Zenject;

public class PlayerNetworkSpawner : NetworkBehaviour, IPlayerNetworkSpawner, IPlayerJoined, IPlayerLeft
{
    private AssetProvider _assetProvider;
    private PlayerRegistry _playerRegistry;
    private IPlayerFactory _playerFactory;

    [Networked, OnChangedRender(nameof(OnPlayerCountChanged))]
    public int _playerCount { get; set; }

    [Inject]
    private void Construct(AssetProvider assetProvider)
    {
        _assetProvider = assetProvider;
    }
    public void Initialize()
    {
        
    }

    public override void Spawned()
    {
        _playerRegistry = new PlayerRegistry();
        _playerFactory = new PlayerFactory(Runner, _assetProvider);
    }

    public void PlayerJoined(PlayerRef player)
    {
        if (!HasStateAuthority) return;
        
        Debug.Log("PlayerJoined" + $"{player.PlayerId}");

        Vector3 spawnPos = new Vector3(Random.Range(-5f, 5f), 1, Random.Range(-5f, 5f));
        NetworkObject playerObj = _playerFactory.Create(player, spawnPos);
        _playerRegistry.Add(player, playerObj);
        _playerCount = _playerRegistry.Count;
    }

    public void PlayerLeft(PlayerRef player)
    {
        if (!HasStateAuthority) return;

        if (_playerRegistry.TryGet(player, out var obj))
        {
            Runner.Despawn(obj);
            _playerRegistry.Remove(player);
        }

        _playerCount = _playerRegistry.Count;
    }

    private void OnPlayerCountChanged()
    {
        
    }
}