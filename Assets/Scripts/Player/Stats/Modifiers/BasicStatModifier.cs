using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BasicStatModifier : StatModifier
{
    private List<StatOperation> _operations;
    public BasicStatModifier(float duration, List<StatOperation> operations) : base(duration)
    {
        _operations = operations;
    }

    public override float Perform(float value, StatType type)
    {
        var operation = _operations.FirstOrDefault(op => op.StatType == type);

        switch (operation.OperationType)
        {
            case OperationType.Add:
                return value + operation.Value;
            case OperationType.Substract:
                return value - operation.Value;
            case OperationType.Multiply:
                return value * operation.Value;
            case OperationType.Subdivide:
                return value / operation.Value;
            default:
                throw new NotImplementedException(nameof(operation.OperationType));
        }
    }

    public void IncreaseModifierValue(StatType type, float value)
    {
        if (value <= 0)
            throw new ArgumentException(nameof(value));
        
        var operation = _operations.FirstOrDefault(op => op.StatType == type);
        operation.Value += value;
    }
}
