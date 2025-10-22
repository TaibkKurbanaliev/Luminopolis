using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public enum OperationType { Add, Substract, Multiply, Subdivide }

public class Modifier : MonoBehaviour
{
    [SerializeField] private Sprite icon;
    [SerializeField] private List<StatOperation> _statOperations;
    [SerializeField] private float _duration = 0f;

    private BasicStatModifier _modifier;

    public void ApplyModifier(Entity entity)
    {
        _modifier = new BasicStatModifier(_duration, _statOperations);
        entity.Stats.Mediator.AddModifier(_modifier);
    }

    private void OnValidate()
    {
        var count = _statOperations.GroupBy(oper => oper.OperationType).Where(array => array.Count() > 1);

        if (count.Count() > 0)
            throw new InvalidOperationException(nameof(_statOperations));
    }
}

[Serializable]
public class StatOperation
{
    public OperationType OperationType;
    public StatType StatType;
    public float Value;
}
