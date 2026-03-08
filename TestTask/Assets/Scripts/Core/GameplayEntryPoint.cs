using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayEntryPoint : MonoBehaviour
{
    private StateMachine _stateMachine;
    private StatesFactory _statesFactory;

    [Inject]
    private void Construct(StateMachine stateMachine, StatesFactory statesFactory)
    {
        _stateMachine = stateMachine;
        _statesFactory = statesFactory;
    }
    
    private void Start()
    {
        InitializeStateMachine();
    }

    private void InitializeStateMachine()
    {
        _stateMachine.AddState<InitializeGameState>(_statesFactory.Create<InitializeGameState>());
        _stateMachine.AddState<PlayerLobbyState>(_statesFactory.Create<PlayerLobbyState>());
        _stateMachine.AddState<InitializeNetworkState>(_statesFactory.Create<InitializeNetworkState>());
        _stateMachine.AddState<GameplayState>(_statesFactory.Create<GameplayState>());
        
        _stateMachine.Enter<InitializeGameState>();
    }
}
