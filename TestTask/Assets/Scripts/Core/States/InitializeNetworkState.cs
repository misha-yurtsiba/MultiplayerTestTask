using Cysharp.Threading.Tasks;
using UnityEngine;

public class InitializeNetworkState : IPayload<CreateLobbyData>
{
    private readonly ISessionController _sessionController;
    private readonly IPlayerNetworkSpawner _playerNetworkSpawner;
    private readonly GameplayUiController _gameplayUiController;

    public InitializeNetworkState(
        ISessionController sessionController,
        IPlayerNetworkSpawner playerNetworkSpawner,
        GameplayUiController gameplayUiController)
    {
        _sessionController = sessionController;
        _playerNetworkSpawner = playerNetworkSpawner;
        _gameplayUiController = gameplayUiController;
    }

    public async void Enter(CreateLobbyData data)
    {
        await StartHostOrClient(data);
    }

    private async UniTask StartHostOrClient(CreateLobbyData data)
    {
        NetworkStartResult result = await _sessionController.StartHostOrClient(data);

        if (result == NetworkStartResult.Success)
        {
            _gameplayUiController.SetLobbyViewActive(false);
        }
    }
    
    public void Exit()
    {
        
    }
}