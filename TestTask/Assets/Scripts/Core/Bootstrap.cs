using System;
using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private ISceneLoadService _sceneLoadService;

    [Inject]
    private void Construct(ISceneLoadService sceneLoadService)
    {
        _sceneLoadService = sceneLoadService;
    }
    
    private void Start()
    {
        Application.targetFrameRate = 60;
        
        _sceneLoadService.LoadScene(Scenes.Gameplay);
    }
}
