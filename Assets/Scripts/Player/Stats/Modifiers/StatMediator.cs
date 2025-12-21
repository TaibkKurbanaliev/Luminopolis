using System.Collections.Generic;
using UnityEngine;

public class StatMediator
{
    private LinkedList<StatModifier> _modifiers;

    public void AddModifier(StatModifier modifier)
    {
        _modifiers.AddLast(modifier);
    }

    public int PerformModifier(int value, StatType type)
    {
        int result = value;

        foreach(StatModifier modifier in _modifiers)
        {
        }

        return result;
    }

    public void Update(float deltaTime)
    {
        var node = _modifiers.First;

        while (node != null)
        {
            var nextNode = node.Next;

            if (node.Value.MarkedForRemoval)
            {
                node.Value.Dispose();
                _modifiers.Remove(nextNode);
            }

            node = nextNode.Next;
        }
    }
}
