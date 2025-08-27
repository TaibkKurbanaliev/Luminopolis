using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour
{
    private StateMachine _stateMachine;
    private InputManager _inputManager;
    private NavMeshAgent _agent;
    private StateMachineData _smData;

    [field: SerializeField] public PlayerConfig PlayerConfig { get; private set; }

    public StateMachine StateMachine => _stateMachine;
    public InputManager InputManager => _inputManager;
    public NavMeshAgent Agent => _agent;

    [Inject]
    private void Contract(InputManager input)
    {
        _inputManager = input;
        _agent = GetComponent<NavMeshAgent>();
        _smData = new StateMachineData();
        _stateMachine = new StateMachine(new()
        {
            new IdleState(_stateMachine, this, _smData)
        });
    }

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }
}
