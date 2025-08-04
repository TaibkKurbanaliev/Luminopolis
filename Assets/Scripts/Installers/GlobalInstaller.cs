using UnityEngine;
using Zenject;
using Zenject.Asteroids;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var input = new InputSystem_Actions();
        input.Enable();

        Container.BindInterfacesAndSelfTo<InputSystem_Actions>().FromInstance(input).AsSingle();
    }
}
