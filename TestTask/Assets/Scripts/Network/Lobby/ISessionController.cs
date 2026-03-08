using System;
using Cysharp.Threading.Tasks;

public interface ISessionController
{
    event Action<NetworkStartResult> OnStartGame;
    public UniTask<NetworkStartResult> StartHostOrClient(CreateLobbyData data);
}