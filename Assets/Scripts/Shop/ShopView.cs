using System.Collections.Generic;
using UnityEngine;

public class ShopView : MonoBehaviour
{
    [SerializeField] private Transform _itemsParent;
    [SerializeField] private ShopFactory _shopFactory;

    private List<ShopItemView> _shopItems = new();

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
            Destroy(item.gameObject);
        }

        _shopItems.Clear();
    }
}
