using System;
using UnityEngine;

[Serializable]
public class MovementStateConfig 
{
    [field: SerializeField] public float MoveSpeed {  get; private set; }
    [field: SerializeField] public float Acceleration { get; private set; }
    [field: SerializeField] public float Drag { get; private set; }
}
