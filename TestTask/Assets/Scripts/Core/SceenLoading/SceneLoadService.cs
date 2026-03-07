using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneLoadService : ISceneLoadService, IInitializable
{
    private LoadingCurtain _loadingCurtain;
    private AssetProvider _assetProvider;
    private AsyncOperation _loadingAsyncOperation;

    [Inject]
    private void Construct(AssetProvider assetProvider)
    {
        _assetProvider = assetProvider;   
    }
    
    public void Initialize()
    {
        _loadingCurtain = _assetProvider.InstantiateAsset<LoadingCurtain>(AssetsPath.LoadingCurtainPAth);
        Object.DontDestroyOnLoad(_loadingCurtain);
    }
    
    public async void LoadScene(Scenes scene)
    {
        await _loadingCurtain.Show();
        
        _loadingAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());
        
        while (_loadingAsyncOperation.isDone)
        {
            await UniTask.Yield();
        }
        
        await _loadingCurtain.Hide();
    }
}