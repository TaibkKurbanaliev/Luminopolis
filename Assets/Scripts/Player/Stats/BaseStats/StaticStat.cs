using UnityEngine;

public class StaticStat<T> : Stat<T>
{
    public StaticStat(string name, string description, int upgradeXP, int currentXP, int upgradeMultiplier, 
        StatType statType, T value, T maxValue, T maxValueAddPerLevel) 
        : base(name, description, upgradeXP, currentXP, upgradeMultiplier, statType, value, maxValue, maxValueAddPerLevel)
    {
    }

    public override void Upgrade()
    {
        throw new System.NotImplementedException();
    }
}
