using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<ShopCategoryButton> _categoryButtons;
    [SerializeField] private ShopView _shopView;

    private void OnEnable()
    {
        foreach (var button in _categoryButtons)
        {
            button.Clicked += OnCategoryClicked;
        }
    }

    private void OnDisable()
    {
        foreach (var button in _categoryButtons)
        {
            button.Clicked -= OnCategoryClicked;
        }
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
