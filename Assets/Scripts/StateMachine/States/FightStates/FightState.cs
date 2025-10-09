using UnityEngine;

public class FightState : State
{
    protected FightStateConfig Config { get; private set; }

    public FightState(IStateSwitcher stateMachine, Player player, StateMachineData data) : base(stateMachine, player, data)
    {
        Config = Player.PlayerConfig.FightStateConfig;
    }

    public override void Enter()
    {
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
        //StateSwitcher.SwitchState<MovementState>();
    }
}
