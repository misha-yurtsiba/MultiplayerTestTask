using UnityEngine;
using Zenject;

public class InitializeGameState : IState
{
    private readonly StateMachine _stateMachine;
    private readonly GameplayUiController _gameplayUiController;
    private readonly IPlayerNetworkSpawner _playerNetworkSpawner;

    public InitializeGameState(StateMachine stateMachine, GameplayUiController gameplayUiController, IPlayerNetworkSpawner playerNetworkSpawner)
    {
        _stateMachine = stateMachine;
        _gameplayUiController = gameplayUiController;
        _playerNetworkSpawner = playerNetworkSpawner;
    }

    public void Enter()
    {
        Debug.Log("Enter");
        _playerNetworkSpawner.Initialize();
        _gameplayUiController.Initialize();
        
        _stateMachine.Enter<PlayerLobbyState>();
    }
    
    public void Exit()
    {
        
    }
}

public class PlayerLobbyState : IState
{
    public void Enter()
    {
        
    }
    public void Exit()
    {
        
    }
}