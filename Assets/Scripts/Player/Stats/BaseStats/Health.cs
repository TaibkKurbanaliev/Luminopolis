using System;
using UnityEngine;

[Serializable]
public class Health : Stat<int>
{
    public Health(string name, string description, int upgradeXP, int currentXP, int upgradeMultiplier, 
        StatType statType, int value, int maxValue, int maxValueAddPerLevel) 
        : base(name, description, upgradeXP, currentXP, upgradeMultiplier, statType, value, maxValue, maxValueAddPerLevel)
    {
    }

    public override void Upgrade()
    {
        MaxValue += MaxValueAddPerLevel;
        Value = MaxValue;
    }
}
