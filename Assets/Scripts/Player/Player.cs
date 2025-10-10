using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerView))]
public class Player : MonoBehaviour
{
    private StateMachine _stateMachine;
    private InputManager _inputManager;
    private StateMachineData _smData;
    private PlayerView _playerView;
    private Wallet _wallet;

    [field: SerializeField] public PlayerConfig PlayerConfig { get; private set; }
    [field: SerializeField] public CharacterController CharacterController { get; private set; }
    [field: SerializeField] public GameObject Target {  get; private set; }

    public StateMachine StateMachine => _stateMachine;
    public InputManager InputManager => _inputManager;
    public PlayerView View  => _playerView;
    public Wallet Wallet => _wallet;

    [Inject]
    private void Constract(InputManager input)
    {
        CharacterController = GetComponent<CharacterController>();
        _inputManager = input;
        _wallet = new Wallet();
        _playerView = GetComponent<PlayerView>();
        _playerView.Initialize();
        _smData = new StateMachineData();
        _stateMachine = new StateMachine();

        _stateMachine.Init(new()
        {
            new IdleState(_stateMachine, this, _smData),
            new WalkState(_stateMachine, this, _smData),
            new TargetMovementState(_stateMachine, this, _smData),
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

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Interactable interactable) && InputManager.Interact)
        {
            Target = interactable.gameObject;
            StateMachine.SwitchState<TargetMovementState>();
        }
    }
}
