using Fusion;
using UnityEngine;

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