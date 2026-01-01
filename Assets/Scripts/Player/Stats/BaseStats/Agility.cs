using UnityEngine;

public class Agility : Stat<int>
{
    public Agility(string name, string description, int upgradeXP, int currentXP, int upgradeMultiplier, 
        StatType statType, int value, int maxValue, int maxValueAddPerLevel) 
        : base(name, description, upgradeXP, currentXP, upgradeMultiplier, statType, value, maxValue, maxValueAddPerLevel)
    {
    }

    public override void Upgrade()
    {
        throw new System.NotImplementedException();
    }
}
