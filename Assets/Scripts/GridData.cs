using System.Collections.Generic;
using UnityEngine;

public class GridData
{
    private List<Vector3Int> _placedObjects = new();

    public GridData(List<Vector3Int> alreadyExistsObjects = default)
    {
        _placedObjects = alreadyExistsObjects ?? new List<Vector3Int>();
    }

    public void PlaceObject(Vector3Int position, Vector2Int size)
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                _placedObjects.Add(new Vector3Int(position.x + i, position.y, position.z + j));
            }
        }
    }

    public bool CanPlaceObject(Vector3Int cellPosition, Vector2Int size)
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                if (_placedObjects.Contains(new Vector3Int(cellPosition.x + i, cellPosition.y, cellPosition.z + j)))
                    return false;
            }
        }

        return true;
    }
}
