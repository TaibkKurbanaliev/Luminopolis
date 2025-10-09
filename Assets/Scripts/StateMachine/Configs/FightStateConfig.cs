using System;
using UnityEngine;

[Serializable]
public class FightStateConfig 
{
    [field: SerializeField] public float Speed {  get; private set; }
    [field: SerializeField] public float Drag { get; private set; }
    [field: SerializeField] public float Acceleration { get; private set; }

    
}
