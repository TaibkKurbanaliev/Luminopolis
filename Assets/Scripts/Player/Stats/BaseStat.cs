using UnityEngine;

public class BaseStat 
{
    public StatType Type {  get; private set; }
    public int Value { get; private set; }
    public string Description { get; private set; }

    public BaseStat(BaseStatConfig config)
    {
        Type = config.StatType;
        Value = config.BaseValue;
    }
}
