using Fusion;
using UnityEngine;
using Zenject;

public class PlayerNetworkSpawner : NetworkBehaviour, IPlayerNetworkSpawner, IPlayerJoined, IPlayerLeft
{
    private AssetProvider _assetProvider;
    private IPlayerFactory _playerFactory;

    [Networked, OnChangedRender(nameof(OnPlayerCountChanged))]
    private int _playerCount { get; set; }

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
        Debug.Log("Spawned" + $"{Runner == null}");
        _playerFactory = new PlayerFactory(Runner, _assetProvider);
    }

    public void PlayerJoined(PlayerRef player)
    {
        if (!HasStateAuthority) return;
        
        Debug.Log("PlayerJoined" + $"{player.PlayerId}");

        Vector3 spawnPos = new Vector3(Random.Range(-5f, 5f), 1, Random.Range(-5f, 5f));

        NetworkObject playerObj = _playerFactory.Create(player, spawnPos);
    }

    public void PlayerLeft(PlayerRef player)
    {
        
    }

    private void OnPlayerCountChanged()
    {
        
    }
}

public interface IPlayerNetworkSpawner
{
    void Initialize();
}

public interface IPlayerFactory
{
    NetworkObject Create(PlayerRef player, Vector3 position);
}

public class PlayerFactory : IPlayerFactory
{
    private readonly NetworkRunner _runner;
    private readonly GameObject _playerPrefab;

    public PlayerFactory(NetworkRunner runner, AssetProvider assetProvider)
    {
        _runner = runner;

        _playerPrefab = assetProvider.LoadAsset(AssetsPath.PlayerModelPath);
    }

    public NetworkObject Create(PlayerRef player, Vector3 position)
    {
        var obj = _runner.Spawn(_playerPrefab, position, Quaternion.identity, player);
        _runner.SetPlayerObject(player, obj);
        return obj;
    }
}


