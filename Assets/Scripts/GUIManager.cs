using System;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : IDisposable
{
    private InputManager _inputManager;
    private Shop _shop;

    public GUIManager(InputManager inputManager, GameObject shop)
    {
        _inputManager = inputManager;
        _inputManager.ShopOpened += OpenShop;
        _inputManager.Exit += CloseShop;
        _shop = shop.GetComponent<Shop>();
        _shop.Closed += CloseShop;
    }

    private void CloseShop()
    {
        _shop.gameObject.SetActive(false);
        _inputManager.SetPlayerMap(true);
    }

    public void OpenShop()
    {
        _shop.gameObject.SetActive(true);
        _inputManager.SetPlayerMap(false);
    }

    public void Dispose()
    {
        _inputManager.ShopOpened -= OpenShop;
        _inputManager.Exit -= CloseShop;
    }
}
