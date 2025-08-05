using UnityEngine;
using Zenject;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _cameraTarget;
    [SerializeField] private float _moveSpeed;

    private InputSystem_Actions _input;

    [Inject]
    private void Constract(InputSystem_Actions input)
    {
        _input = input;
    }


    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var cameraFwd = Camera.main.transform.forward;
        cameraFwd.y = 0;
        cameraFwd.Normalize();
        
        var cameraRight = Camera.main.transform.right;
        cameraRight.y = 0;
        cameraRight.Normalize();

        var playerInput = _input.Player.Move.ReadValue<Vector2>();
        var targetSpeed = new Vector3(playerInput.x, 0f, playerInput.y) * _moveSpeed * Time.fixedDeltaTime;
        
        var targetDir =  cameraFwd * targetSpeed.z + cameraRight * targetSpeed.x;

        _cameraTarget.position += targetDir * Time.fixedDeltaTime;
    }    
}
