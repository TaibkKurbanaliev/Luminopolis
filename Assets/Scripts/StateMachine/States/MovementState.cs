using UnityEngine;
using UnityEngine.AI;

public class MovementState : State
{
    private float _minVelocityValue = 0.01f;
    private MovementStateConfig _config;
    public MovementState(IStateSwitcher stateMachine, Player player, StateMachineData data) : base(stateMachine, player, data)
    {
        _config = player.PlayerConfig.MovementStateConfig;
    }

    public override void Enter()
    {
        Debug.Log("Enter the MoveState");
        Data.Speed = _config.Speed;
        Player.Agent.speed = Data.Speed;
        Player.Agent.SetDestination(Data.TargetPosition);
    }

    public override void Exit()
    {
    }

    public override void FixedUpdate()
    {
    }

    public override void HandleInput()
    {
    }

    public override void Update()
    {
        if (!Player.Agent.hasPath && Player.Agent.velocity.sqrMagnitude == 0f)
        {
            Data.IsMoving = false;
            StateMachine.SwitchState<IdleState>();
        }

        Player.Agent.SetDestination(Data.TargetPosition);

        Player.View.SetSpeed(Player.Agent.velocity.magnitude);
    }
}
