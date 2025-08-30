using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(PlayerView))]
public class Player : MonoBehaviour
{
    private StateMachine _stateMachine;
    private InputManager _inputManager;
    private NavMeshAgent _agent;
    private StateMachineData _smData;
    private PlayerView _playerView;

    [field: SerializeField] public PlayerConfig PlayerConfig { get; private set; }

    public StateMachine StateMachine => _stateMachine;
    public InputManager InputManager => _inputManager;
    public NavMeshAgent Agent => _agent;
    public PlayerView View  => _playerView;

    [Inject]
    private void Constract(InputManager input)
    {
        _inputManager = input;
        _agent = GetComponent<NavMeshAgent>();
        _playerView = GetComponent<PlayerView>();
        _playerView.Initialize();
        _smData = new StateMachineData();
        _stateMachine = new StateMachine();
        _stateMachine.Init(new()
        {
            new IdleState(_stateMachine, this, _smData),
            new MovementState(_stateMachine, this, _smData),
        });
    }

    private void Update()
    {
        _stateMachine.HandleInput();
        _stateMachine.Update();
    }

    private void FixedUpdate()
    {
        _stateMachine.FixedUpdate();
    }
}
