using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject _mouseIndicator;
    [SerializeField] private GameObject _cellIndicator;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Grid _grid;
    [SerializeField] private float distanceBetweenGrid;

    [SerializeField] private GameObject _gridVisualization;

    private Building _selectedObject;

    public void Initialize()
    {
        StopPlacement();

    }

    public void StartPlacement(Building building)
    {
        StopPlacement();
        _selectedObject = building;
        _gridVisualization.SetActive(true);
        _cellIndicator.SetActive(true);
        _inputManager.Clicked += PlaceStructure;
        _inputManager.Exit += StopPlacement;
    }

    private void PlaceStructure()
    {
        if (_inputManager.IsPointerOverUI())
        {
            return;
        }

        Vector3 mousePosition = _inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = _grid.WorldToCell(mousePosition);
        GameObject building = Instantiate(_selectedObject.gameObject);
        building.transform.localPosition = _grid.CellToWorld(gridPosition);
    }

    public void StopPlacement()
    {
        _selectedObject = null;
        _gridVisualization.SetActive(false);
        _cellIndicator.SetActive(false);
        _inputManager.Clicked -= PlaceStructure;
        _inputManager.Exit -= StopPlacement;
    }

    private void Update()
    {
        if (_selectedObject == null)
            return;

        Vector3 mousePosition = _inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = _grid.WorldToCell(mousePosition);
        _mouseIndicator.transform.position = mousePosition;
        _cellIndicator.transform.position = _grid.CellToWorld(gridPosition);
        _cellIndicator.transform.position = new Vector3(_cellIndicator.transform.position.x, _cellIndicator.transform.position.y + distanceBetweenGrid, _cellIndicator.transform.position.z);
    }
}
