using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private PlacementSystem _placementSystem;
    [SerializeField] private GameObject _shop;
    [SerializeField] private InputManager _inputManager;

    private GUIManager _guiManager;
    public override void InstallBindings()
    {
        _placementSystem.Initialize();

        var input = new InputSystem_Actions();
        input.Enable();

        Container.Bind<InputSystem_Actions>().FromInstance(input).AsSingle();

        _guiManager = new GUIManager(_inputManager, _shop);
    }
}
