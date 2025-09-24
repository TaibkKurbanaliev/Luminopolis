using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Windows;

public class MovementState : State
{
    private float _minVelocityValue = 0.01f;
    private MovementStateConfig _config;
    private Vector3 _moveDir;

    public MovementState(IStateSwitcher stateMachine, Player player, StateMachineData data) : base(stateMachine, player, data)
    {
        _config = player.PlayerConfig.MovementStateConfig;
    }

    public override void Enter()
    {
        Debug.Log("Enter the MoveState");
        Data.Speed = _config.MoveSpeed;
        Data.Acceleration = _config.Acceleration;
        Data.Drag = _config.Drag;
    }

    public override void Exit()
    {
    }

    public override void FixedUpdate()
    {
        var movementDelta = _moveDir * Data.Acceleration * Time.fixedDeltaTime;
        var newVelocity = Player.CharacterController.velocity + movementDelta;
        Debug.Log(newVelocity);

        Vector3 currentDrag = newVelocity.normalized * Data.Drag;
        newVelocity = newVelocity.magnitude > Data.Drag ? newVelocity - currentDrag : Vector3.zero;
        newVelocity = Vector3.ClampMagnitude(newVelocity, Data.Speed);
        newVelocity.y = Physics.gravity.y;

        Player.CharacterController.Move(newVelocity * Time.fixedDeltaTime);
    }

    public override void HandleInput()
    {
        _moveDir = new Vector3(Player.InputManager.MoveInput.x, Player.InputManager.MoveInput.y);
    }

    public override void Update()
    {
        
    }
}
