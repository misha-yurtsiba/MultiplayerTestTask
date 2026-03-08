using Fusion;
using UnityEngine;

public class NetworkInputHandler : NetworkBehaviour, IBeforeUpdate
{
    private PlayerInputData _playerInputData;
    private NetworkEvents _networkEvents;
    
    public override void Spawned()
    {
        if (HasInputAuthority == false)
            return;

        _networkEvents = Runner.GetComponent<NetworkEvents>();
        _networkEvents.OnInput.AddListener(OnInput);
    }

    public override void Despawned(NetworkRunner runner, bool hasState)
    {
        if (runner == null)
            return;

        if (_networkEvents != null)
        {
            _networkEvents.OnInput.RemoveListener(OnInput);
        }
    }
    
    private void OnInput(NetworkRunner runner, NetworkInput input)
    {
        _playerInputData.Direction.Normalize();
        input.Set(_playerInputData);
    }

    public void BeforeUpdate()
    {
        if (HasInputAuthority == false)
            return;
        
        _playerInputData.Direction = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
        );
    }
}