using System;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : IDisposable
{
    private InputManager _inputManager;

    public GUIManager(InputManager inputManager)
    {
        _inputManager = inputManager;
    }

    private void CloseShop()
    {
        _inputManager.SetPlayerMap(true);
    }

    public void OpenShop()
    {
        _inputManager.SetPlayerMap(false);
    }

    public void Dispose()
    {
        _inputManager.ShopOpened -= OpenShop;
        _inputManager.Exit -= CloseShop;
    }
}
