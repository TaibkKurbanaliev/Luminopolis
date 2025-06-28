using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ShopFactory
{
    [SerializeField] private ShopItemView _buildingViewPrefab;

    public ShopItemView Get(Building building, Transform parent)
    {
        ShopItemView instance = GameObject.Instantiate(_buildingViewPrefab, parent);
        instance.Initialize(building);
        return instance;
    }
}
