using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Windows;
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

        _guiManager = new GUIManager(_inputManager, _shop);
        Container.BindInterfacesAndSelfTo<InputManager>().FromInstance(_inputManager).AsSingle().NonLazy();
    }
}
