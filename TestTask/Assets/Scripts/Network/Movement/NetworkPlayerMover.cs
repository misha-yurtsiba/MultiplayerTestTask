using Fusion;
using UnityEngine;

public class NetworkPlayerMover : NetworkBehaviour
{
    [SerializeField] private PlayerConfig _playerConfig;
    
    private PlayerMover _playerMover;
    private NetworkCharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<NetworkCharacterController>();
    }

    public override void Spawned()
    {
        _playerMover = new PlayerMover(_controller, transform, _playerConfig);
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out PlayerInputData input))
        {
            _playerMover.Move(input.Direction.normalized, Runner.DeltaTime);
        }
    }
}