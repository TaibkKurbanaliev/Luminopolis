using System.Collections.Generic;
using UnityEngine;

public class PunchBag : TrainingEquipment
{
    [SerializeField] private List<StatOperation> _statOperations;
    public override void Interact()
    {
        base.Interact();
    }
}
