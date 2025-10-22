using System;
using UnityEngine;

public abstract class Interactable : MonoBehaviour 
{
    public static event Action<string> InteractEntered;
    public static event Action InteractExited;

    [SerializeField] private string _actionName;

    public abstract void Interact();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            InteractEntered?.Invoke(_actionName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player _))
            InteractExited?.Invoke();
    }
}

[Serializable]
public class Trainable—haracteristic
{
    [field: SerializeField] public StatType StatType;
    [field: SerializeField] public float Value;
}