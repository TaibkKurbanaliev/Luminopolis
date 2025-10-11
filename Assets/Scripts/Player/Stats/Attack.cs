using System;
using UnityEngine;

public class Attack
{
    public float HookDamage { get; private set; }
    public float JabDamage { get; private set; }
    public float UppercutDamage { get; private set; }
    public float PunchSpeed { get; private set; }
    public float PunchPrice { get; private set; }

    private readonly float _maxCharacteristicsValue;

    public Attack(float hookDamage, float jabDamage, float uppercutDamage, float punchSpeed, float punchPrice, float maxCharacteristicsValue)
    {
        HookDamage = hookDamage;
        JabDamage = jabDamage;
        UppercutDamage = uppercutDamage;
        PunchSpeed = punchSpeed;
        PunchPrice = punchPrice;
        _maxCharacteristicsValue = maxCharacteristicsValue;
    }

    public void UpgradeJabDamage(float addValue)
    {
        if (addValue < 0)
            throw new ArgumentOutOfRangeException(nameof(addValue));

        JabDamage = Mathf.Clamp(JabDamage + addValue, 0, _maxCharacteristicsValue);
    }

    public void UpgradeHookDamage(float addValue)
    {
        if (addValue < 0)
            throw new ArgumentOutOfRangeException(nameof(addValue));

        HookDamage = Mathf.Clamp(HookDamage + addValue, 0, _maxCharacteristicsValue);
    }

    public void UpgradeUppercutDamage(float addValue)
    {
        if (addValue < 0)
            throw new ArgumentOutOfRangeException(nameof(addValue));

        UppercutDamage = Mathf.Clamp(UppercutDamage + addValue, 0, _maxCharacteristicsValue);
    }

    public void UpgradePunchSpeed(float addValue)
    {
        if (addValue < 0)
            throw new ArgumentOutOfRangeException(nameof(addValue));

        PunchSpeed = Mathf.Clamp(PunchSpeed + addValue, 0, _maxCharacteristicsValue);
    }
    
    public void SetPunchPrice(float value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        PunchPrice = value;
    }
}
