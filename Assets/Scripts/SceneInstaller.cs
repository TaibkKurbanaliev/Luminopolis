using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private PlacementSystem _placementSystem;
    public override void InstallBindings()
    {
        _placementSystem.Initialize();
        var input = new InputSystem_Actions();
        input.Enable();
        Container.Bind<InputSystem_Actions>().FromInstance(input).AsSingle();
    }
}
