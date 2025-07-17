using System;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public event Action Closed;

    [SerializeField] private List<ShopCategoryButton> _categoryButtons;
    [SerializeField] private ShopView _shopView;

    private void OnEnable()
    {
        ShopItemView.Buyed += OnItemBuyed;

        foreach (var button in _categoryButtons)
        {
            button.Clicked += OnCategoryClicked;
        }
    }


    private void OnDisable()
    {
        ShopItemView.Buyed -= OnItemBuyed;

        foreach (var button in _categoryButtons)
        {
            button.Clicked -= OnCategoryClicked;
        }
    }

    private void OnItemBuyed(Building building)
    {
        Closed?.Invoke();
    }

    private void OnCategoryClicked(ShopCategoryButton button)
    {
        button.Select();

        foreach (var categoryButton in _categoryButtons)
        {
            if (categoryButton != button)
            {
                categoryButton.DeSelect();
            }
        }

        _shopView.Show(button.Buildings);
    }
}
