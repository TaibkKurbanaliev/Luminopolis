using Unity.Cinemachine;
using UnityEngine;
using Zenject;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _cameraTarget;
    [SerializeField] private CinemachineOrbitalFollow _cinemachineOrbitalFollow;

    [SerializeField] private float _orbitSensivity = 0.5f;
    [SerializeField] private float _moveSpeed = 5f;

    private InputManager _input;

    [Inject]
    private void Constract(InputManager input)
    {
        _input = input;
    }


    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        var cameraFwd = Camera.main.transform.forward;
        cameraFwd.y = 0;
        cameraFwd.Normalize();
        
        var cameraRight = Camera.main.transform.right;
        cameraRight.y = 0;
        cameraRight.Normalize();

        var playerInput = _input.MoveInput;
        var targetSpeed = new Vector3(playerInput.x, 0f, playerInput.y) * _moveSpeed * Time.fixedDeltaTime;
        
        var targetDir =  cameraFwd * targetSpeed.z + cameraRight * targetSpeed.x;

        _cameraTarget.position += targetDir * Time.fixedDeltaTime;
    }
    
    private void Rotate()
    {
        if (_input.IsCameraRotating == false) 
            return;

        Vector2 orbitalRotation = _input.LookInput * _orbitSensivity;
        _cinemachineOrbitalFollow.HorizontalAxis.Value += orbitalRotation.x;
        _cinemachineOrbitalFollow.HorizontalAxis.Value = Mathf.Clamp(_cinemachineOrbitalFollow.HorizontalAxis.Value, _cinemachineOrbitalFollow.HorizontalAxis.Range.x, _cinemachineOrbitalFollow.HorizontalAxis.Range.y);
        _cinemachineOrbitalFollow.VerticalAxis.Value += orbitalRotation.y;
        _cinemachineOrbitalFollow.VerticalAxis.Value = Mathf.Clamp(_cinemachineOrbitalFollow.VerticalAxis.Value, _cinemachineOrbitalFollow.VerticalAxis.Range.x, _cinemachineOrbitalFollow.VerticalAxis.Range.y);
    }
}
