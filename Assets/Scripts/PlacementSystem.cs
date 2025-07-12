using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject _mouseIndicator;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Grid _grid;
    [SerializeField] private float distanceBetweenGrid;

    [SerializeField] private GameObject _gridVisualization;
    [SerializeField] private PreviewSystem _previewSystem = new();

    private Building _selectedObject;
    private GridData _gridData;

    public void Initialize()
    {
        _previewSystem.Initialize();
        StopPlacement();
        _gridData = new GridData();
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
        _previewSystem.StartShowingPlacementPreview(building.gameObject, building.BuildingData.Size);
        _inputManager.Clicked += PlaceStructure;
        _inputManager.Exit += StopPlacement;
        _inputManager.Rotate += RotateStructure;
    }

    public void StopPlacement()
    {
        _selectedObject = null;
        _gridVisualization.SetActive(false);
        _previewSystem.StopShowingPreview();
        _inputManager.Clicked -= PlaceStructure;
        _inputManager.Exit -= StopPlacement;
        _inputManager.Rotate -= RotateStructure;
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
        
        _previewSystem.UpdatePosition(_grid.CellToWorld(gridPosition), placementValidity);
    }

    private void OnBuildingBuyed(Building building)
    {
        StartPlacement(building);
    }

    private void RotateStructure()
    {
        var rotationAngle = 90f;
        _previewSystem.UpdateRotation();
        _selectedObject.transform.Rotate(0f, rotationAngle, 0f);
    }
}
