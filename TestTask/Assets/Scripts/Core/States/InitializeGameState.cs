using UnityEngine;
using Zenject;

public class InitializeGameState : IState
{
    private readonly StateMachine _stateMachine;
    private readonly GameplayUiController _gameplayUiController;

    public InitializeGameState(StateMachine stateMachine, GameplayUiController gameplayUiController)
    {
        _stateMachine = stateMachine;
        _gameplayUiController = gameplayUiController;
    }

    public void Enter()
    {
        Debug.Log("Enter");
        _gameplayUiController.Initialize();
        
        _stateMachine.Enter<PlayerLobbyState>();
    }
    
    public void Exit()
    {
        
    }
}