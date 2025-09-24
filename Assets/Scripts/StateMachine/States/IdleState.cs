using UnityEngine;

public class IdleState : MovementState
{
    public IdleState(IStateSwitcher stateMachine, Player player, StateMachineData data) : base(stateMachine, player, data)
    {
    }

    public override void Enter()
    {
        Debug.Log("Enter the IdleState");
        Data.Speed = 0;
        Data.Acceleration = 0;
        Data.Drag = 0;
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
        if (Data.Input != Vector2.zero)
            StateSwitcher.SwitchState<MovementState>();
    }
}
