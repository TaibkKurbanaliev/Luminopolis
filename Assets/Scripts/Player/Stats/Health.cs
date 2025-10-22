using System;
using UnityEngine;

public class Health
{
    public event Action HealthDepleted;

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _heart;

    public float CurrentHealth { get; private set; }

    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public float Heart { get => _heart; set => _heart = value; }

    public void ReduceHealth(float value)
    {
        if (CurrentHealth <= 0)
            return;

        CurrentHealth -= value;

        if (CurrentHealth <= 0)
            HealthDepleted?.Invoke();
    }
}
