using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Zenject;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera _sceneCamera;
    [SerializeField] private LayerMask _placementLayerMask;
    private InputSystem_Actions _input;
    
    private Vector3 _lastPosition;
    public event Action Clicked;
    public event Action Exit;

    [Inject]
    private void Constract(InputSystem_Actions input)
    {
        _input = input;
        _input.Player.Attack.started += OnClick;
        _input.UI.Cancel.started += OnExit;
    }

    public bool IsPointerOverUI() => EventSystem.current.IsPointerOverGameObject();

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

    private void OnClick(InputAction.CallbackContext context)
    {
        Clicked?.Invoke();
    }

    private void OnExit(InputAction.CallbackContext context)
    {
        Exit?.Invoke();
    }
}
