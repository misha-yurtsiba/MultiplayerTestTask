using System;
using UnityEngine;

public class LobbyPresenter : IDisposable
{
    private readonly StateMachine _stateMachine;
    private readonly GameplayUiController _gameplayUiController;
    private readonly ISessionController _sessionController;
    private readonly ILobbyView _view;

    public LobbyPresenter(ISessionController sessionController,GameplayUiController gameplayUiController, StateMachine stateMachine, ILobbyView view)
    {
        _sessionController = sessionController;
        _gameplayUiController = gameplayUiController;
        _stateMachine = stateMachine;
        _view = view;

        _view.OnCreateLobbyButtonPressed += OnStartGame;
    }

    public void Dispose()
    {
        _view.OnCreateLobbyButtonPressed -= OnStartGame;
    }
    public async void OnStartGame(CreateLobbyData data)
    {
        _view.SetButtonInteractable(false);
        
        _stateMachine.Enter<InitializeNetworkState, CreateLobbyData>(data);
    }
}
