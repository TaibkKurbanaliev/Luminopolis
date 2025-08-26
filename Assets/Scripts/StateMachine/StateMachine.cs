using System;
using System.Collections.Generic;
using System.Linq;

public class StateMachine : IStateSwitcher
{
    private List<State> _states;
    private State _currentState;

    public StateMachine(List<State> states)
    {
        _states = states;
        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<T>() where T : State
    {
        State state = _states.FirstOrDefault(state => state is T);

        if (state == null)
            throw new ArgumentException();

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void HandleInput() => _currentState.HandleInput();
    public void Update() => _currentState.Update();

}
