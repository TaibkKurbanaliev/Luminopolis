using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Modifier;

public class Modifier : MonoBehaviour
{
    public enum OperationType { Add, Substract, Multiply, Subdivide }
    [SerializeField] private List<StatOperation> _statOperations;

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
