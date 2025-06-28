using UnityEngine;

public class ShopItemView : MonoBehaviour
{
    [SerializeField] private Building _building;

    public void Initialize(Building building)
    {
        _building = building;
    }
}
