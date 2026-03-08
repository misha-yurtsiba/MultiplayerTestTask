using System;
using UnityEngine;

public class PlayerCounterPresenter : IDisposable
{
    private readonly INetworkPlayerCounter _networkPlayerCounter;
    private readonly PlayerCountView _playerCountView;

    public PlayerCounterPresenter(INetworkPlayerCounter networkPlayerCounter, PlayerCountView playerCountView)
    {
        _networkPlayerCounter = networkPlayerCounter;
        _playerCountView = playerCountView;

        _networkPlayerCounter.OnValueChanged += UpdateUI;
    }

    public void Dispose()
    {
        _networkPlayerCounter.OnValueChanged -= UpdateUI;
    }

    private void UpdateUI(int playerCount)
    {
        _playerCountView.SetPlayerCountText(playerCount);
    }
}
