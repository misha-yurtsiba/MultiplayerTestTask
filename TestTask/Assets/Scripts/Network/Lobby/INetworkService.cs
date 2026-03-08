using Cysharp.Threading.Tasks;

public interface INetworkService
{
    UniTask<NetworkStartResult> StartHostOrClient(string sessionName);
}