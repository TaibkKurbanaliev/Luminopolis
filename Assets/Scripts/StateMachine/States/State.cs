using UnityEngine;

public abstract class State 
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly Player Player;

    protected StateMachineData Data;
    public State(IStateSwitcher stateMachine, Player player, StateMachineData data)
    {
        StateSwitcher = stateMachine;
        Player = player;
        Data = data;
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
    public abstract void FixedUpdate();
    public abstract void HandleInput();
}
