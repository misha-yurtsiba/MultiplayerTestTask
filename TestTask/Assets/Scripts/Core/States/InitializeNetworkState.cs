using Cysharp.Threading.Tasks;
using UnityEngine;

public class InitializeNetworkState : IPayload<CreateLobbyData>
{
    private readonly ISessionController _sessionController;
    private readonly GameplayUiController _gameplayUiController;
    private readonly StateMachine _stateMachine;

    public InitializeNetworkState(
        ISessionController sessionController,
        GameplayUiController gameplayUiController, 
        StateMachine stateMachine)
    {
        _sessionController = sessionController;
        _gameplayUiController = gameplayUiController;
        _stateMachine = stateMachine;
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
            _gameplayUiController.SetPlayerCountViewActive(true);
        }
        
        _stateMachine.Enter<GameplayState>();
    }
    
    public void Exit()
    {
        
    }
}