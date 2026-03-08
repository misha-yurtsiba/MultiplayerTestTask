using System;
using Fusion;
using Unity.VisualScripting;
using UnityEngine;

public class Player : NetworkBehaviour
{
    private CameraMover _cameraMover;
    private NetworkPlayerMover _networkPlayerMover;
    
    public static event Action<Player> OnLocalPlayerSpawned; 

    public static Player Local;
    
    public override void Spawned()
    {
        if (!HasInputAuthority) return;
        
        if (Local == null)
        {
            Local = this;
        }
            
        _cameraMover = Camera.main.GetComponent<CameraMover>();
        _cameraMover.SetTarget(transform);
        OnLocalPlayerSpawned?.Invoke(this);
    }
}