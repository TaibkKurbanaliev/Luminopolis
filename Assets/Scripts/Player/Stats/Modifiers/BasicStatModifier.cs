using System;
using System.Collections.Generic;
using UnityEngine;

public class BasicStatModifier : StatModifier
{
    private Dictionary<StatType, Func<float, float>> _operations;
    public BasicStatModifier(float duration, Dictionary<StatType, Func<float, float>> operations) : base(duration)
    {
        _operations = operations;
    }

    public override float Perform(float value, StatType type)
    {
        return _operations[type](value);
    }
}
