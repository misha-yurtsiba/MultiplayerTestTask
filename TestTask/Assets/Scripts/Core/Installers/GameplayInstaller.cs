using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private GameplayUiController _gameplayUiController;
    
    public override void InstallBindings()
    {
        BindUIController();

        BindGameStateMachine();
    }

    private void BindUIController()
    {
        Container.BindInterfacesAndSelfTo<GameplayUiController>().FromInstance(_gameplayUiController).AsSingle();
    }

    private void BindGameStateMachine()
    {
        Container
            .BindInterfacesAndSelfTo<StatesFactory>()
            .AsSingle();
        
        Container
            .BindInterfacesAndSelfTo<StateMachine>()
            .AsSingle();
    }
}
