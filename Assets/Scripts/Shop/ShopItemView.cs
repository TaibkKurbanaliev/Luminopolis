using UnityEngine;
using UnityEngine.UI;

public class ShopItemView : MonoBehaviour
{
    [SerializeField] private Image _contentImage;
    [SerializeField] private IntValueView _priceView;

    private Building _building;
    
    public bool IsLock {  get; private set; }
    public int Price => _building.BuildingData.Cost;

    public void Initialize(Building building)
    {
        _building = building;

        _contentImage.sprite = _building.BuildingData.Image;
    }
}
