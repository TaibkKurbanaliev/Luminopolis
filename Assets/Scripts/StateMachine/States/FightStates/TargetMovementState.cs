using UnityEngine;
using UnityEngine.UIElements;

public class TargetMovementState : FightState
{
    public TargetMovementState(IStateSwitcher stateMachine, Player player, StateMachineData data) : base(stateMachine, player, data)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Data.Speed = Config.Speed;
        Data.Acceleration = Config.Acceleration;
        Data.Drag = Config.Drag;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Rotate();
        Move();
    }

    public override void HandleInput()
    {
        base.HandleInput();
        Data.Input = Player.InputManager.MoveInput;
    }

    private void Move()
    {
        var moveDir = new Vector3(Data.Input.x, 0, Data.Input.y);
        var movementDelta = Player.transform.forward * moveDir.z * Data.Acceleration * Time.fixedDeltaTime + 
                            Player.transform.right * moveDir.x * Data.Acceleration * Time.fixedDeltaTime;
        var newVelocity = Player.CharacterController.velocity + movementDelta;
        

        Vector3 currentDrag = newVelocity.normalized * Data.Drag;
        newVelocity = newVelocity.magnitude > Data.Drag ? newVelocity - currentDrag : Vector3.zero;
        newVelocity = Vector3.ClampMagnitude(newVelocity, Data.Speed);
        newVelocity.y = Physics.gravity.y;

        Player.CharacterController.Move(newVelocity * Time.fixedDeltaTime);
    }

    private void Rotate()
    {
        Player.transform.LookAt(Player.Target.transform);
        Player.transform.rotation = new Quaternion(0, Player.transform.rotation.y, 0, Player.transform.rotation.w);
    }
}
