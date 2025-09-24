using System;
using UnityEngine;

[Serializable]
public class WalkStateConfig 
{
    [field: SerializeField] public float MoveSpeed {  get; private set; }
    [field: SerializeField] public float Acceleration { get; private set; }
    [field: SerializeField] public float Drag { get; private set; }
    [field: SerializeField] public float RotationSpeed { get; private set; }
}
