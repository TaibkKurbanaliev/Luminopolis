using UnityEngine;

public class WalkState : MovementState
{
    private WalkStateConfig _config;
    public WalkState(IStateSwitcher stateMachine, Player player, StateMachineData data, WalkStateConfig _cfg) 
        : base(stateMachine, player, data)
    {
        _config = _cfg;
    }

    public override void Enter()
    {
        base.Enter();
        Data.Acceleration = _config.Acceleration;
        Data.Drag = _config.Drag;
        Data.Speed = _config.MoveSpeed;
        Data.RotationSpeed = _config.RotationSpeed;
    }
}
