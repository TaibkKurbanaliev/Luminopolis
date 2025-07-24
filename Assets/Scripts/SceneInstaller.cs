using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [Header("General Options")]
    [SerializeField] private PlacementSystem _placementSystem;
    [SerializeField] private InputManager _inputManager;

    [Header("GUIManager Options")]
    [SerializeField] private GameObject _shop;

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
