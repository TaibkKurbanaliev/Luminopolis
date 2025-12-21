using UnityEngine;

public abstract class State : IState
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

    public virtual void OnTriggerEnter() { }
    public virtual void OnTriggerExit() { }
    public virtual void OnTriggerStay() { }
    public virtual void OnCollisionEnter() { }
    public virtual void OnCollisionExit() { }
    public virtual void OnCollisionStay() { }
}
