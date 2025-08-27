using UnityEngine;

public class MovementState : State
{
    private MovementStateConfig _config;
    public MovementState(IStateSwitcher stateMachine, Player player, StateMachineData data) : base(stateMachine, player, data)
    {
        _config = player.PlayerConfig.MovementStateConfig;
    }

    public override void Enter()
    {
        Data.Speed = _config.Speed;
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void FixedUpdate()
    {
        throw new System.NotImplementedException();
    }

    public override void HandleInput()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        throw new System.NotImplementedException();
    }
}
