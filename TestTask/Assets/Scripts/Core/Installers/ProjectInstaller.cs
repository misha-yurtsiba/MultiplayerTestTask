using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindAssetProvider();
        
        BindSceneLoadService();
    }

    private void BindSceneLoadService()
    {
        Container
            .BindInterfacesAndSelfTo<SceneLoadService>()
            .AsSingle();
    }

    private void BindAssetProvider()
    {
        Container
            .BindInterfacesAndSelfTo<AssetProvider>()
            .AsSingle();
    }
}
