using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Windows;

public class MovementState : State
{
    private Vector3 _moveDir;

    public MovementState(IStateSwitcher stateMachine, Player player, StateMachineData data) : base(stateMachine, player, data)
    {
        
    }

    public override void Enter()
    {
    }


    public override void Exit()
    {
    }

    public override void FixedUpdate()
    {
        Rotate();
        Move();
    }

    public override void HandleInput()
    {
    }

    public override void Update()
    {
        
    }
    private void Move()
    {
        _moveDir = new Vector3(Data.Input.x, 0, Data.Input.y);
        var movementDelta = _moveDir * Data.Acceleration * Time.fixedDeltaTime;
        var newVelocity = Player.CharacterController.velocity + movementDelta;
        Debug.Log(newVelocity);

        Vector3 currentDrag = newVelocity.normalized * Data.Drag;
        newVelocity = newVelocity.magnitude > Data.Drag ? newVelocity - currentDrag : Vector3.zero;
        newVelocity = Vector3.ClampMagnitude(newVelocity, Data.Speed);
        newVelocity.y = Physics.gravity.y;

        Player.CharacterController.Move(newVelocity * Time.fixedDeltaTime);
    }

    private void Rotate()
    {
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(Data.Input.x, 0, Data.Input.y));

        // Плавный поворот
        Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, targetRotation, Data.RotationSpeed * Time.deltaTime);
    }
}
