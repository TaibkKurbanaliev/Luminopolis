using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridData
{
    private List<Vector3Int> _placedObjects = new();

    public GridData(List<Vector3Int> alreadyExistsObjects = default)
    {
        _placedObjects = alreadyExistsObjects ?? new List<Vector3Int>();
    }

    public void PlaceObject(Vector3Int position, Vector2Int size, Vector3 direction)
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                if (direction == Vector3.right)
                    _placedObjects.Add(new Vector3Int(position.x + i, position.y, position.z + j));
                else if (direction == Vector3.left)
                    _placedObjects.Add(new Vector3Int(position.x - i, position.y, position.z - j));
                else if (direction == Vector3.back)
                    _placedObjects.Add(new Vector3Int(position.x + j, position.y, position.z - i));
                else if (direction == Vector3.forward)
                    _placedObjects.Add(new Vector3Int(position.x - j, position.y, position.z + i));
            }
        }
    }

    public bool CanPlaceObject(Vector3Int cellPosition, Vector2Int size, Vector3 direction)
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                if (direction == Vector3.right && _placedObjects.Contains(new Vector3Int(cellPosition.x + i, cellPosition.y, cellPosition.z + j)))
                    return false;
                else if (direction == Vector3.left && _placedObjects.Contains(new Vector3Int(cellPosition.x - i, cellPosition.y, cellPosition.z - j)))
                    return false;
                else if (direction == Vector3.back && _placedObjects.Contains(new Vector3Int(cellPosition.x + j, cellPosition.y, cellPosition.z - i)))
                    return false;
                else if (direction == Vector3.forward && _placedObjects.Contains(new Vector3Int(cellPosition.x - j, cellPosition.y, cellPosition.z + i)))
                    return false;
            }
        }

        return true;
    }
}
