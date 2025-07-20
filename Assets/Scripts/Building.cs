using System;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    [field: SerializeField] public BuildingData BuildingData {  get; private set; }
}

public enum Direction
{
    Right, Down, Left, Up
}

[Serializable]
public class BuildingData
{   
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public int Cost { get; private set; }
    [field: SerializeField] public Vector2Int Size { get; private set; }
    [field: SerializeField] public Sprite Image { get; private set; }
    [field: SerializeField] public Direction PlaceDirection { get; set; } = Direction.Right;

    public void Rotate()
    {
        PlaceDirection = 1 + (int)PlaceDirection > (int)Direction.Up ? Direction.Right : PlaceDirection+1;
    }
}