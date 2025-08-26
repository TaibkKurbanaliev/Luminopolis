using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Zenject;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera _sceneCamera;
    [SerializeField] private LayerMask _placementLayerMask;
    [Header("GUI Buttons")]
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _rotateButton;
    [SerializeField] private Button _placeButton;

    private InputSystem_Actions _input;

    private Vector3 _lastPosition;

    public event Action Clicked;
    public event Action Exit;
    public event Action Rotate;
    public event Action ShopOpened;

    public Vector2 MoveInput => _input.Player.Move.ReadValue<Vector2>();
    public Vector2 LookInput => _input.Player.Look.ReadValue<Vector2>();
    public Vector2 ZoomInput => _input.Player.Zoom.ReadValue<Vector2>();
    public Vector2 PointerPosition => _input.Player.Position.ReadValue<Vector2>();
    public bool IsCameraRotating => _input.Player.RotateCamera.IsPressed();
    public bool RightClick => _input.Player.MoveToMousePos.triggered;

    [Inject]
    private void Constract(InputSystem_Actions input)
    {
        _input = input;
        _input.Player.Place.started += OnClick;
        _input.Player.Rotate.started += OnRotate;

        _input.UI.Cancel.started += OnExit;
        _input.UI.OpenShop.started += OnShopOpened;

        _shopButton.onClick.AddListener(OnShopOpened);
        _rotateButton.onClick.AddListener(OnRotate);
        _placeButton.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _input.Player.Place.started -= OnClick;
        _input.Player.Rotate.started -= OnRotate;

        _input.UI.Cancel.started -= OnExit;
        _input.UI.OpenShop.started -= OnShopOpened;

        _shopButton.onClick.RemoveListener(OnShopOpened);
        _rotateButton.onClick.RemoveListener(OnRotate);
        _placeButton.onClick.RemoveListener(OnClick);
    }

    public bool IsPointerOverUI() => EventSystem.current.IsPointerOverGameObject();
    
    public bool IsPlayerInputDisabled() => !_input.Player.enabled;

    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = _input.UI.Point.ReadValue<Vector2>();
        mousePos.z = _sceneCamera.nearClipPlane;
        Ray ray = _sceneCamera.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, _placementLayerMask))
        {
            _lastPosition = hitInfo.point;
        }

        return _lastPosition;
    }

    public void SetPlayerMap(bool isEnabled)
    {
        if (isEnabled)
            _input.Player.Enable();
        else
            _input.Player.Disable();
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        Clicked?.Invoke();
    }
    private void OnClick()
    {
        Clicked?.Invoke();
        Debug.Log("Kek");
    }

    private void OnExit(InputAction.CallbackContext context)
    {
        Exit?.Invoke();
    }

    private void OnRotate(InputAction.CallbackContext context)
    {
        Rotate?.Invoke();
    }
    private void OnRotate()
    {
        Rotate?.Invoke();
    }

    private void OnShopOpened(InputAction.CallbackContext context)
    {
        ShopOpened?.Invoke();
    }
    private void OnShopOpened()
    {
        ShopOpened?.Invoke();
    }

}
