using UnityEngine;

public abstract class Stat<T>
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int UpgradeXP { get; protected set; }
    public int CurrentXP { get; protected set; }
    public float UpgradeMultiplier { get; protected set; }

    public T Value { get; protected set; }
    public T MaxValue { get; protected set; }
    public T MaxValueAddPerLevel { get; protected set; }

    protected StatType _statType { get; private set; }
    protected EventBinding<GetStatXPEvent> GetXP;

    protected Stat(string name, string description, int upgradeXP,
                   int currentXP, int upgradeMultiplier, StatType statType, T value, T maxValue, T maxValueAddPerLevel)
    {
        Name = name;
        Description = description;
        UpgradeXP = upgradeXP;
        CurrentXP = currentXP;
        UpgradeMultiplier = upgradeMultiplier;
        _statType = statType;

        GetXP = new(HandleGetStatXPEvent);
        Value = value;
        MaxValue = maxValue;
        MaxValueAddPerLevel = maxValueAddPerLevel;
    }

    ~Stat()
    {

    }

    public abstract void Upgrade();
    
    private void HandleGetStatXPEvent(GetStatXPEvent @event)
    {
        if (@event.Type != _statType)
            return;

        CurrentXP += @event.XP;

        if (CurrentXP >= UpgradeXP)
        {
            CurrentXP -= UpgradeXP;
            UpgradeXP = (int)(UpgradeXP * UpgradeMultiplier);
            Upgrade();
        }
    }
}
