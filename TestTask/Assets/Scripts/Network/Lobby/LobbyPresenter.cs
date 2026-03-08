using System;
using UnityEngine;

public class LobbyPresenter : IDisposable
{
    private readonly StateMachine _stateMachine;
    private readonly ILobbyView _view;

    public LobbyPresenter(StateMachine stateMachine, ILobbyView view)
    {
        _stateMachine = stateMachine;
        _view = view;

        _view.OnCreateLobbyButtonPressed += OnStartGame;
    }

    public void Dispose()
    {
        _view.OnCreateLobbyButtonPressed -= OnStartGame;
    }
    public void OnStartGame(CreateLobbyData data)
    {
        _view.SetButtonInteractable(false);
        
        _stateMachine.Enter<InitializeNetworkState, CreateLobbyData>(data);
    }
}
