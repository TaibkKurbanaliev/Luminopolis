using System;
using UnityEngine;

[Serializable]
public class Stamina 
{
    [SerializeField] private float _fightStamina;
    [SerializeField] private float _enduranceValue;
    [SerializeField] private float _dailyStamina;

    public float CurrentFightStamina { get; private set; }
    public float CurrentDailyStamina { get; private set; }
    public float FightStamina { get => _fightStamina; set => _fightStamina = value; }
    public float EnduranceValue { get => _enduranceValue; set => _enduranceValue = value; }
    public float DailyStamina { get => _dailyStamina; set => _dailyStamina = value; }

    public Stamina(float fightStamina, float dailyStamina, float currentFightStamina, float currentDailyStamina, float restoringFightStamina)
    {
        FightStamina = fightStamina;
        DailyStamina = dailyStamina;
    }
}
