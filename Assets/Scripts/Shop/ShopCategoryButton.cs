using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCategoryButton : MonoBehaviour
{
    public event Action<ShopCategoryButton> Clicked;

    [SerializeField] private BuildingsSO buildings;
    [SerializeField] private Button _button;

    [SerializeField] private Image _image;
    [SerializeField] private Color _selectColor;
    [SerializeField] private Color _deselectColor;

    public IEnumerable<Building> Buildings => buildings.Buildings;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    public void Select()
    {
        _image.color = _selectColor;
    }

    public void DeSelect()
    {
        _image.color = _deselectColor;
    }

    private void OnClick()
    {
        Clicked?.Invoke(this);
    }
}
