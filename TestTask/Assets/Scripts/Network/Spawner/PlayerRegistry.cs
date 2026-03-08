using System.Collections.Generic;
using Fusion;

public class PlayerRegistry
{
    private readonly Dictionary<PlayerRef, NetworkObject> _players = new();

    public int Count => _players.Count;

    public void Add(PlayerRef player, NetworkObject obj)
    {
        _players[player] = obj;
    }

    public bool TryGet(PlayerRef player, out NetworkObject obj)
    {
        return _players.TryGetValue(player, out obj);
    }

    public void Remove(PlayerRef player)
    {
        _players.Remove(player);
    }
}