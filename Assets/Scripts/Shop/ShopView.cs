using System.Collections.Generic;
using UnityEngine;

public class ShopView : MonoBehaviour
{
    [SerializeField] private Transform _itemsParent;

    private List<ShopItemView> _shopItems = new();
    private ShopFactory _shopFactory;

    public void Awake()
    {
        _shopFactory = new ShopFactory();
    }

    public void Show(IEnumerable<Building> items)
    {
        Clear();

        foreach (var item in items)
        {
            ShopItemView spawnedItem = _shopFactory.Get(item, _itemsParent);
            _shopItems.Add(spawnedItem);
        }
    }

    private void Clear()
    {
        foreach (var item in _shopItems)
        {
            Destroy(item);
        }

        _shopItems.Clear();
    }
}
