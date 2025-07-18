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

        bool placementValidity = _gridData.CanPlaceObject(gridPosition, _selectedObject.BuildingData.Size, _selectedObject.transform.right);

        if (placementValidity == false)
        {
            return;
        }

        GameObject building = Instantiate(_selectedObject.gameObject);
        building.transform.localPosition = _grid.CellToWorld(gridPosition);
        _gridData.PlaceObject(gridPosition, _selectedObject.BuildingData.Size, _selectedObject.transform.right);
    }


    private void Update()
    {
        if (_selectedObject == null || _inputManager.IsPlayerInputDisabled())
        {
            return;
        }

        Vector3 mousePosition = _inputManager.GetSelectedMapPosition();
        _mouseIndicator.transform.position = mousePosition;
        var gridOffset = _grid.cellSize.z / 2;
        Vector3Int gridPosition = _grid.WorldToCell(new Vector3(mousePosition.x + gridOffset, mousePosition.y, mousePosition.z + gridOffset));

        bool placementValidity = _gridData.CanPlaceObject(gridPosition, _selectedObject.BuildingData.Size, _selectedObject.transform.right);

        var previewPosition = _grid.CellToWorld(gridPosition);
        previewPosition.x += gridOffset;
        previewPosition.z += gridOffset;
        _previewSystem.UpdatePosition(previewPosition, placementValidity);
    }

    private void OnBuildingBuyed(Building building)
    {
        StartPlacement(building);
    }

    private void RotateStructure()
    {
        Debug.Log("Kek");
        var rotationAngle = 90f;
        _previewSystem.UpdateRotation();
        _selectedObject.transform.Rotate(0f, rotationAngle, 0f);
    }
}
