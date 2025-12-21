using UnityEngine;

public abstract class Stat
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int UpgradeXP { get; protected set; }
    public int CurrentXP { get; protected set; }
    public int UpgradeMultiplier { get; protected set; }

    protected StatType _statType { get; private set; }
    protected EventBinding<GetStatXPEvent> GetXP;

    protected Stat(string name, string description, int upgradeXP, 
                   int currentXP, int upgradeMultiplier, StatType statType)
    {
        Name = name;
        Description = description;
        UpgradeXP = upgradeXP;
        CurrentXP = currentXP;
        UpgradeMultiplier = upgradeMultiplier;
        _statType = statType;

        GetXP = new(HandleGetStatXPEvent);
    }

    ~Stat()
    {

    }

    public abstract void Upgrade();
    
    private void HandleGetStatXPEvent(GetStatXPEvent @event)
    {

    }
}
