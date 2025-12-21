using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerView))]
public class Player : Entity
{
    private StateMachineData _smData;

    [field: SerializeField] public PlayerConfig PlayerConfig { get; private set; }
    [field: SerializeField] public GameObject Target {  get; private set; }

    public InputManager InputManager { get; private set; }
    public StateMachine StateMachine { get; private set; }
    public PlayerView PlayerView { get; private set; }
    public CharacterController CharacterController { get; private set; }
    public Wallet Wallet { get; private set; }

    [Inject]
    private void Constract(InputManager input)
    {
        InputManager = input;
        Wallet = new Wallet();
        CharacterController = GetComponent<CharacterController>();
        PlayerView = GetComponent<PlayerView>();
        PlayerView.Initialize();

        _smData = new StateMachineData();
        StateMachine = new StateMachine();
        StateMachine.AddState(new WalkState(StateMachine, this, _smData, PlayerConfig.WalkStateConfig));
        StateMachine.SwitchState<WalkState>();
    }

    private void Update()
    {
        StateMachine.HandleInput();
        StateMachine.Update();
    }

    private void FixedUpdate()
    {
        StateMachine.FixedUpdate();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Interactable interactable) && InputManager.Interact)
        {
            Target = interactable.gameObject;
        }
    }
}
