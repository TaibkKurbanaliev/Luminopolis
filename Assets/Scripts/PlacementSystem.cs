using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject _mouseIndicator;
    [SerializeField] private GameObject _cellIndicator;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Grid _grid;
    [SerializeField] private float distanceBetweenGrid;

    [SerializeField] private GameObject _gridVisualization;

    private Building _selectedObject;
    private GridData _gridData;
    private Renderer _previewRenderer;

    public void Initialize()
    {
        StopPlacement();
        _gridData = new GridData();
        _previewRenderer = _cellIndicator.GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        ShopItemView.Buyed += OnBuildingBuyed;
    }


    private void OnDisable()
    {
        ShopItemView.Buyed -= OnBuildingBuyed;
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

    public void StopPlacement()
    {
        _selectedObject = null;
        _gridVisualization.SetActive(false);
        _cellIndicator.SetActive(false);
        _inputManager.Clicked -= PlaceStructure;
        _inputManager.Exit -= StopPlacement;
    }

    private void PlaceStructure()
    {
        if (_inputManager.IsPointerOverUI())
        {
            return;
        } 


        Vector3 mousePosition = _inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = _grid.WorldToCell(new Vector3(mousePosition.x + _grid.cellSize.x / 2, mousePosition.y, mousePosition.z + _grid.cellSize.z / 2));

        bool placementValidity = _gridData.CanPlaceObject(gridPosition, _selectedObject.BuildingData.Size);

        if (placementValidity == false)
        {
            return;
        }

        GameObject building = Instantiate(_selectedObject.gameObject);
        building.transform.localPosition = _grid.CellToWorld(gridPosition);
        _gridData.PlaceObject(gridPosition, _selectedObject.BuildingData.Size);
    }


    private void Update()
    {
        if (_selectedObject == null)
        {
            return;
        }

        Vector3 mousePosition = _inputManager.GetSelectedMapPosition();
        _mouseIndicator.transform.position = mousePosition;
        Vector3Int gridPosition = _grid.WorldToCell(new Vector3(mousePosition.x + _grid.cellSize.x / 2, mousePosition.y, mousePosition.z + _grid.cellSize.z / 2));

        bool placementValidity = _gridData.CanPlaceObject(gridPosition, _selectedObject.BuildingData.Size);
        _previewRenderer.material.color = placementValidity ? Color.white : Color.red;

        _cellIndicator.transform.position = _grid.CellToWorld(gridPosition);
        _cellIndicator.transform.position = new Vector3(_cellIndicator.transform.position.x, _cellIndicator.transform.position.y + distanceBetweenGrid, _cellIndicator.transform.position.z);
    }

    private void OnBuildingBuyed(Building building)
    {
        StartPlacement(building);
    }
}
