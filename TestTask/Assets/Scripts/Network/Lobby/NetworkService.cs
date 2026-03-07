using Cysharp.Threading.Tasks;
using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class NetworkService : INetworkService
{
    private readonly NetworkRunner _networkRunnerPrefab;
    private NetworkRunner _networkRunnerInstance;
    
    public NetworkService(NetworkRunner networkRunner)
    {
        _networkRunnerPrefab = networkRunner;
    }
    
    public async UniTask<NetworkStartResult> StartHostOrClient(string sessionName)
    {
        _networkRunnerInstance = Object.Instantiate(_networkRunnerPrefab);
        _networkRunnerInstance.ProvideInput = true;
        
        SceneRef scene = SceneRef.FromIndex(SceneManager.GetActiveScene().buildIndex);
        NetworkSceneInfo sceneInfo = new NetworkSceneInfo();
        
        if (scene.IsValid) {
            sceneInfo.AddSceneRef(scene);
        }
        
        StartGameArgs startArguments = new StartGameArgs()
        {
            GameMode = GameMode.AutoHostOrClient,
            SessionName = sessionName,
            
            Scene = sceneInfo,
        };

        StartGameResult result = await _networkRunnerInstance.StartGame(startArguments);

        return result.Ok ? NetworkStartResult.Success : NetworkStartResult.Failed;
    }
}

public interface INetworkService
{
    UniTask<NetworkStartResult> StartHostOrClient(string sessionName);
}

public enum NetworkStartResult
{
    Success,
    Failed,
}
