using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopCategoryButton : MonoBehaviour
{
    public event Action Clicked;

    [SerializeField] private Button _button;

    [SerializeField] private Image _image;
    [SerializeField] private Color _selectColor;
    [SerializeField] private Color _deselectColor;

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
        throw new NotImplementedException();
    }
}
