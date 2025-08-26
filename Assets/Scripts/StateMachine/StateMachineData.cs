using System;
using UnityEngine;

public class StateMachineData 
{
    public Vector2 Velocity;
    public Vector3 TargetPosition;
    public bool IsMoving;

    private float _speed;

    public float Speed 
    { 
        get => _speed;
        set
        {
            if (value < 0f) 
                throw new ArgumentException(nameof(value));

            _speed = value;
        }
    }
}
