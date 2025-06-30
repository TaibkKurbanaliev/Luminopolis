using UnityEngine;
using UnityEngine.Categorization;

[CreateAssetMenu(fileName = "ShopFactory", menuName = "ShopFactory", order = 1)]
public class ShopFactory : ScriptableObject
{
    [SerializeField] private ShopItemView _buildingViewPrefab;

    public ShopItemView Get(Building building, Transform parent)
    {
        ShopItemView instance = UnityEngine.Object.Instantiate(_buildingViewPrefab, parent);
        instance.Initialize(building);
        return instance;
    }
}
