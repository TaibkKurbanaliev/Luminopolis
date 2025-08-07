using Unity.Cinemachine;
using UnityEngine;
using Zenject;

public class CameraMovement : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private Transform _cameraTarget;
    [SerializeField] private CinemachineOrbitalFollow _orbitalFollow;

    [Header("Move Settings")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _acceleration = 10f;
    [SerializeField] private float _deceleration = 1f;
    [SerializeField] private AnimationCurve _moveSpeedCurve = AnimationCurve.Linear(0f, 0.5f, 1f, 1f);

    [Header("Zoom Settings")]
    [SerializeField]private float _zoomSpeed = 1f;
    [SerializeField]private float _zoomSmothing = 1f;

    [Header("Orbital Settings")]
    [SerializeField] private float _orbitSensivity = 0.5f;
    [SerializeField] private float _orbitSmoothing = 0.5f;

    [Header("EdgeScroll Settings")]
    [SerializeField] private float _edgeScrollMargin = 15f;

    private InputManager _input;
    private Vector3 _currentVelocity;
    private float _cuurentZoom;
    private Vector2 _edgeScrollInput;

    private float ZoomLevel => Mathf.InverseLerp(_orbitalFollow.RadialAxis.Range.x, _orbitalFollow.RadialAxis.Range.y, _orbitalFollow.RadialAxis.Value);

    [Inject]
    private void Constract(InputManager input)
    {
        _input = input;
    }


    private void LateUpdate()
    {
        EdgeScrolling();
        Move();
        Rotate();
        Zoom();
    }

    private void Move()
    {
        var cameraFwd = Camera.main.transform.forward;
        cameraFwd.y = 0;
        cameraFwd.Normalize();
        
        var cameraRight = Camera.main.transform.right;
        cameraRight.y = 0;
        cameraRight.Normalize();

        var playerInput = _input.MoveInput + _edgeScrollInput;
        var targetSpeed = new Vector3(playerInput.x, 0f, playerInput.y) * _moveSpeed * Time.fixedDeltaTime;
        
        float zoomMultiplier = _moveSpeedCurve.Evaluate(ZoomLevel);

        var targetVelocity =  (cameraFwd * targetSpeed.z + cameraRight * targetSpeed.x) * zoomMultiplier;


        if (playerInput.sqrMagnitude > 0.001f)
            _currentVelocity = Vector3.Lerp(_currentVelocity, targetVelocity, _acceleration * Time.fixedDeltaTime);
        else
            _currentVelocity = Vector3.Lerp(_currentVelocity, Vector3.zero, _deceleration * Time.fixedDeltaTime);

        _cameraTarget.position += _currentVelocity * Time.fixedDeltaTime;
    }
    
    private void Rotate()
    {
        if (_input.IsCameraRotating == false) 
            return;

        Vector2 orbitalRotation = _input.LookInput * _orbitSensivity;
        //_cinemachineOrbitalFollow.HorizontalAxis.Value += orbitalRotation.x;
        //_cinemachineOrbitalFollow.VerticalAxis.Value -= orbitalRotation.y;

        _orbitalFollow.HorizontalAxis.Value = Mathf.Lerp(_orbitalFollow.HorizontalAxis.Value, _orbitalFollow.HorizontalAxis.Value + orbitalRotation.x, _orbitSmoothing * Time.fixedDeltaTime);
        _orbitalFollow.VerticalAxis.Value = Mathf.Lerp(_orbitalFollow.VerticalAxis.Value, _orbitalFollow.VerticalAxis.Value + orbitalRotation.y, _orbitSmoothing * Time.fixedDeltaTime);
        _orbitalFollow.HorizontalAxis.Value = Mathf.Clamp(_orbitalFollow.HorizontalAxis.Value, _orbitalFollow.HorizontalAxis.Range.x, _orbitalFollow.HorizontalAxis.Range.y);
        _orbitalFollow.VerticalAxis.Value = Mathf.Clamp(_orbitalFollow.VerticalAxis.Value, _orbitalFollow.VerticalAxis.Range.x, _orbitalFollow.VerticalAxis.Range.y);
    }

    private void Zoom()
    {
        _cuurentZoom = Mathf.Lerp(_cuurentZoom,_zoomSpeed * _input.ZoomInput.y, _zoomSmothing * Time.fixedDeltaTime);
        _orbitalFollow.RadialAxis.Value -= _cuurentZoom;
        _orbitalFollow.RadialAxis.Value = Mathf.Clamp(_orbitalFollow.RadialAxis.Value, _orbitalFollow.RadialAxis.Range.x, _orbitalFollow.RadialAxis.Range.y);
    }

    private void EdgeScrolling()
    {
        _edgeScrollInput = Vector2.zero;

        if (_input.PointerPosition.x <= _edgeScrollMargin)
            _edgeScrollInput.x = -1f;
        else if (_input.PointerPosition.x >= Screen.width - _edgeScrollMargin)
            _edgeScrollInput.x = 1f;

        if (_input.PointerPosition.y <= _edgeScrollMargin)
            _edgeScrollInput.y = -1f;
        else if (_input.PointerPosition.y >= Screen.height - _edgeScrollMargin)
            _edgeScrollInput.y = 1f;
    }
}
