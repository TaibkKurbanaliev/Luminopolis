using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Windows;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [Header("General Options")]
    [SerializeField] private InputManager _inputManager;

    private GUIManager _guiManager;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<InputManager>().FromInstance(_inputManager).AsSingle().NonLazy();
    }
}
