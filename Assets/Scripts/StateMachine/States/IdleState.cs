using UnityEngine;

public class IdleState : State
{
    public IdleState(IStateSwitcher stateMachine, Player player, StateMachineData data) : base(stateMachine, player, data)
    {
    }

    public override void Enter()
    {
        Data.IsMoving = false;
    }

    public override void Exit()
    {
    }

    public override void FixedUpdate()
    {
    }

    public override void HandleInput()
    {
        if (!Player.InputManager.RightClick)
            return;

        Data.TargetPosition = Player.InputManager.GetSelectedMapPosition();
        Data.IsMoving = true;
    }

    public override void Update()
    {
        if (Data.IsMoving)
            StateMachine.SwitchState<MovementState>();
    }
}
