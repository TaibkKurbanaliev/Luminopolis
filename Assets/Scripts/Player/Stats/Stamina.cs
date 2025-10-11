using System;
using UnityEngine;

public class Stamina 
{
    private float _fightStamina;
    private float _dailyStamina;
    private float _currentFightStamina;
    private float _currentDailyStamina;
    private float _restoringFightStamina;

    public Stamina(float fightStamina, float dailyStamina, float currentFightStamina, float currentDailyStamina, float restoringFightStamina)
    {
        _fightStamina = fightStamina;
        _dailyStamina = dailyStamina;
        _currentFightStamina = currentFightStamina;
        _currentDailyStamina = currentDailyStamina;
        _restoringFightStamina = restoringFightStamina;
    }

    public float RestoringFightStamina
    {
        get => _restoringFightStamina;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException();

            _restoringFightStamina = value;
        }
    }

    public float FightStamina
    {
        get => _fightStamina;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException();

            _fightStamina = value;
        }
    }
    public float CurrentStamina => _currentFightStamina;
    public float DailyStamina
    {
        get => _dailyStamina;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _dailyStamina = value;
        }
    }
    public float CurrentDailyStamina => _currentDailyStamina;

    public void ResetAll()
    {
        _currentDailyStamina = DailyStamina;
        _currentFightStamina = FightStamina;
    }

    public void ReduceFightStamine(float value)
    {
        if (value < 0 || value > _currentFightStamina)
            throw new ArgumentOutOfRangeException(nameof(value));

        _currentFightStamina -= value;
    }

    public void RestoreFightStamina()
    {
        _currentFightStamina += _restoringFightStamina;

        if (_currentFightStamina > _fightStamina)
            _currentFightStamina = _fightStamina;
    }

    public void ReduceDailyStamina(float value)
    {
        if (value < 0 || value > _currentDailyStamina)
            throw new ArgumentOutOfRangeException(nameof(value));

        _currentDailyStamina -= value;
    }

    public void RestoreDailyStamina(float value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        _currentDailyStamina += value;
        
        if (_currentDailyStamina > DailyStamina)
            _currentDailyStamina = DailyStamina;
    }
}
