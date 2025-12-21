using UnityEngine;

public class PauseState : IState
{
    public void Enter()
    {
        EventBus<PauseEvent>.Raise(new PauseEvent { IsPaused = true });
    }

    public void Exit()
    {
        EventBus<PauseEvent>.Raise(new PauseEvent { IsPaused = false });
    }

    public void FixedUpdate()
    {
    }

    public void HandleInput()
    {
    }

    public void Update()
    {
    }
}
