using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var input = new InputSystem_Actions();
        input.Enable();
        Container.Bind<InputSystem_Actions>().FromInstance(input).AsSingle();
    }
}
