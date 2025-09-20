using System;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSwitch : MonoBehaviour
{
    public event Action<bool> Switched;

    [SerializeField] ButtonAnimation _on;
    [SerializeField] ButtonAnimation _off;

    public bool CurrentValue { get; private set; }


    public void Initialize(bool currentValue = false)
    {
        CurrentValue = currentValue;

        if (CurrentValue)
            _on.Select();
        else
            _off.Select();
    }

    public void OnEnable()
    {
        _on.Clicked += OnTurnOn;
        _off.Clicked += OnTurnOff;
    }

    private void OnDisable()
    {
        _on.Clicked -= OnTurnOn;
        _off.Clicked -= OnTurnOff;
    }

    private void OnTurnOff()
    {
        CurrentValue = false;
        _on.DeSelect();
        Switched?.Invoke(CurrentValue);
    }

    private void OnTurnOn()
    {
        CurrentValue = true;
        _off.DeSelect();
        Switched?.Invoke(CurrentValue);
    }
}
