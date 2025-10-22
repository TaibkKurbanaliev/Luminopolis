using System;
using UnityEngine;

[Serializable]
public class Stats 
{
    public StatMediator Mediator {  get; private set; }

    // Attack Properties
    [field: SerializeField] public Attack Attack { get; private set; }

    //Defence Properties
    [field: SerializeField] public Defence Defence {  get; private set; }


    //Base Properties
    [field: SerializeField] public Health Health { get; private set; }
    [field: SerializeField] public Stamina Stamina { get; private set; }

    public Stats()
    {
        Mediator = new StatMediator();
    }
}

