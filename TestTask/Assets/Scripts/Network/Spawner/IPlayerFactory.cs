using Fusion;
using UnityEngine;

public interface IPlayerFactory
{
    NetworkObject Create(PlayerRef player, Vector3 position);
}