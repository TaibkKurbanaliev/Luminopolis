using UnityEngine;
using UnityEngine.Windows;

public abstract class MovementState : State
{
    public MovementState(IStateSwitcher stateMachine, Player player, StateMachineData data) 
        : base(stateMachine, player, data)
    {
    }

    public override void Enter()
    {
        Debug.Log(GetType().Name);
    }

    public override void Exit()
    {
    }

    public override void FixedUpdate()
    {
    }

    public override void HandleInput()
    {
        Data.Input = Player.InputManager.MoveInput;
    }

    public override void Update()
    {
        Rotate();
        Move();
    }

    private void Move()
    {
        var moveDir = new Vector3(Data.Input.x, 0, Data.Input.y);
        var movementDelta = moveDir * Data.Acceleration * Time.deltaTime;
        var newVelocity = Player.CharacterController.velocity + movementDelta;
        

        Vector3 currentDrag = newVelocity.normalized * Data.Drag * Time.deltaTime;
        newVelocity = newVelocity.magnitude > Data.Drag * Time.deltaTime ? newVelocity - currentDrag : Vector3.zero;
        newVelocity = Vector3.ClampMagnitude(newVelocity, Data.Speed);
        newVelocity.y = Physics.gravity.y;

        Player.CharacterController.Move(newVelocity * Time.deltaTime);
    }

    private void Rotate()
    {
        if (Data.Input == Vector2.zero)
            return;

        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(Data.Input.x, 0, Data.Input.y), Vector3.up);

        Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, 
                                                             targetRotation, 
                                                             Data.RotationSpeed * Time.deltaTime);
    }
}
