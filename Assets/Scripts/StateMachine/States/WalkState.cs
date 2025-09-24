using UnityEngine;

public class WalkState : MovementState
{
    private float _minVelocityValue = 0.01f;
    private WalkStateConfig _config;

    public WalkState(IStateSwitcher stateMachine, Player player, StateMachineData data) : base(stateMachine, player, data)
    {
        _config = player.PlayerConfig.WalkStateConfig;
    }

    public override void Enter()
    {
        Debug.Log("Enter the WalkState");
        Data.Speed = _config.MoveSpeed;
        Data.Acceleration = _config.Acceleration;
        Data.Drag = _config.Drag;
        Data.RotationSpeed = _config.RotationSpeed;
    }

    public override void Exit()
    {
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void HandleInput()
    {
        Data.Input = Player.InputManager.MoveInput;
    }

    public override void Update()
    {
        base.Update();
    }
}
