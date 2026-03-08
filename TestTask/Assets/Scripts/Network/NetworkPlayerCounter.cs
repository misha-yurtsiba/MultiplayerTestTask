using System;
using Fusion;
using UnityEngine;

public class NetworkPlayerCounter : NetworkBehaviour, INetworkPlayerCounter
{
    [Networked, OnChangedRender(nameof(OnTextChanged))] public int _playerCount { get; set; }
    
    public event Action<int> OnValueChanged;

    public override void Spawned()
    {
        OnTextChanged();
    }

    private void OnTextChanged()
    {
        OnValueChanged?.Invoke(_playerCount);
    }

    public void SetPlayerCount(int newPlayerCount)
    {
        _playerCount = newPlayerCount;
    }
}

public interface INetworkPlayerCounter
{
    event Action<int> OnValueChanged;

    void SetPlayerCount(int newPlayerCount);
}
