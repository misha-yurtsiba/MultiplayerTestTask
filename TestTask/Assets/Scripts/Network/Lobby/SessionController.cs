using System;
using Cysharp.Threading.Tasks;
using Fusion;
using Zenject;

public class SessionController : IInitializable, ISessionController
{
    private readonly AssetProvider _assetProvider;
    
    private INetworkService _networkService;
    private NetworkRunner _networkRunner;

    public event Action<NetworkStartResult> OnStartGame;
    
    public SessionController(AssetProvider assetProvider)
    {
        _assetProvider = assetProvider;
    }
    
    public void Initialize()
    {
        _networkRunner = _assetProvider.InstantiateAsset<NetworkRunner>(AssetsPath.NetworkRunnerPath);
        
        _networkService = new NetworkService(_networkRunner);
    }

    public async UniTask<NetworkStartResult> StartHostOrClient(CreateLobbyData data)
    {
        NetworkStartResult result = await _networkService.StartHostOrClient(data.LobbyName);

        if (result == NetworkStartResult.Success)
        {
            OnStartGame?.Invoke(result);
        }
        return result;
    }
}