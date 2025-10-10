using UnityEngine;

public class IdleState : MovementState
{
    public IdleState(IStateSwitcher stateMachine, Player player, StateMachineData data) : base(stateMachine, player, data)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Data.Speed = 0;
        Data.Acceleration = 0;
        Data.Drag = 0;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void HandleInput()
    {
        base.HandleInput();
        Data.Input = Player.InputManager.MoveInput;
    }

    public override void Update()
    {
        base.Update();
        if (Data.Input != Vector2.zero)
            StateSwitcher.SwitchState<WalkState>();
    }
}
